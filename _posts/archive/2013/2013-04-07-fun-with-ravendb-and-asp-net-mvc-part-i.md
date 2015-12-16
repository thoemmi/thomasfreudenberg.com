---
layout: post
title: 'Fun with RavenDB and ASP.NET MVC&#58; part I'
date: 2013-04-07 22:09:55 +02
comments: true
disqus_identifier: 458164
categories: [RavenDB, aspnetmvc]
redirect_from:
  - /blog/archive/2013/04/08/fun-with-ravendb-and-asp-net-mvc-part-i.aspx
---

I’m working on a small pet project with ASP.NET MVC, where hierarchical structured documents are stored in [RavenDB](http://ravendb.net/). These documents can be retrieved by their unique URL, which is also stored in the document. Because there are different kinds of document class, they all derive from the common interface `IRoutable`. This interface defines a property `Path`, by which the document can be accessed.

``` csharp
public interface IRoutable {
    string Id { get; set; }
    string Path { get; set; }
}

public class Document : IRoutable {
    public string Id { get; set; }
    public string Path { get; set; }
}

using (var session = _store.OpenSession()) {
    session.Store(new Document { Path = "a" });
    session.Store(new Document { Path = "a/b" });
    session.Store(new Document { Path = "a/b/c" });
    session.Store(new Document { Path = "a/d" });
    session.Store(new Document { Path = "a/d/e" });
    session.Store(new Document { Path = "a/f" });
    session.SaveChanges();
}
```

Additionally there’s the requirement, that the incoming URL may consist of more parts than the document’s path, carrying some additional information about the request. Here are some examples of possible requests, and which document should match:

| Request   | Found document |
|-----------|----------------|
| a/x       | a              |
| a/b/c/y/z | a/b/c          |

So, given the path, how can you find the correct document?

The solution to this consists of three parts:

1.  Identify documents in the database which can be accessed via their path
2.  Index those documents
3.  Find the document which matches best a given URL

### Marking routable documents

Because there’s not a single class for pages stored in the database, I mark all documents implementing `IRoutable` by adding a flag `IsRoutable` to the document’s metadata. This is done by implementing [`IDocumentStoreListener`](http://ravendb.net/docs/2.0/client-api/advanced/client-side-listeners), so the code is called by RavenDB whenever a document is stored:

``` csharp
public class DocumentStoreListener : IDocumentStoreListener {
    public const string IS_ROUTABLE = "IsRoutable";

    public bool BeforeStore(string key, object entityInstance, RavenJObject metadata, RavenJObject original) {
        var document = entityInstance as IRoutable;
        if (document == null) {
            return false;
        }
        if (metadata.ContainsKey(IS_ROUTABLE) && metadata.Value<bool>(IS_ROUTABLE)) {
            return false;
        }
        metadata.Add(IS_ROUTABLE, true);
        return true;
    }

    public void AfterStore(string key, object entityInstance, RavenJObject metadata) {
    }
}
```

### Indexing routable documents

The next step is to create an index for all documents with the proper flag in their metadata:

``` csharp
public class IRoutable_ByPath : AbstractIndexCreationTask {
    public override IndexDefinition CreateIndexDefinition() {
        return new IndexDefinition {
            Map = @"from doc in docs where doc[""@metadata""][""" + DocumentStoreListener.IS_ROUTABLE + @"""].ToString() == ""True"" select new { doc.Path }"
        };
    }
}
```

### Searching for documents

Ok, so much for the preparation. The interesting part starts when a request comes in. Here RavenDB’s [boosting](http://ravendb.net/docs/2.0/client-api/querying/static-indexes/searching#boosting) feature is quite handy. The more parts of the path match, the higher score the document will get. E.g. if the requested path is `a/b/c/d/e`, following RavenDB search will be queried:

| search term | boost |
|-------------|-------|
| a/b/c/d/e   | 5     |
| a/b/c/d     | 4     |
| a/b/c       | 3     |
| a/b         | 2     |
| a           | 1     |

The code to create such a query looks like this:

``` csharp
public IRoutable GetRoutable(string path) {
    var query = _documentSession
        .Query<IRoutable, IRoutable_ByPath>();

    if (!String.IsNullOrEmpty(path)) {
        var pathParts = path.Split('/');
        for (var i = 1; i <= pathParts.Length; ++i) {
            var shortenedPath = String.Join("/", pathParts, startIndex: 0, count: i);
            query = query.Search(doc => doc.Path, shortenedPath, boost: i, options: SearchOptions.Or);
        }
    } else {
        query = query.Where(doc => doc.Path == String.Empty);
    }

    var document = query.Take(1).FirstOrDefault();
    return document;
}
```

This method will finally return the document with the longest matching path.

Based on the incoming request we have found a matching document. What we can do with the remaining part of the URL I’ll leave for the next installment.

I published the complete code with unit tests in this [Github repository](https://github.com/thoemmi/FunWithRavenDB).

