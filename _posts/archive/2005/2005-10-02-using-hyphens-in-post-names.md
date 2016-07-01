---
layout: post
title: 'Using Hyphens In Post Names'
date: 2005-10-02 23:21:00 +02
comments: true
disqus_identifier: 12540
tags: [Community Server]
redirect_from:
  - /blog/archive/2005/10/03/using-hyphens-in-post-names.aspx
---

There was a discussion [regarding naming of posts](http://communityserver.org/forums/498215/ShowPost.aspx) in a CommunityServer forum (a surprisingly unknown feature of CS::Blogs, though even dotText .96 supported it). CS replaces spaces with underscores. However, Jonathan stated that Google prefers hyphens to underscores. So I tried to use hyphens in the post name, but I've stumbled over two issues:

1.  You cannot enter hyphens in the post's name edit box because the field validator won't accept it. The regular expression is defined in the code as `[a-zA-Z][1234567890a-zA-Z_\\s]{4,250}`, i.e. only letters, digits, underscores, and white-spaces are allowed. To enable hyphens as well, you have to change line 155 in `Blogs\WeblogPosts.cs` to

    ``` csharp
    public static readonly string PostNamePattern = "^[a-zA-Z][1234567890a-zA-Z\\-_\\s]{4,250}$";
    ```

    and re-compile `CommunityServer.Blogs.dll`.

2.  When you want to visit the post using the named url, you'll get a 404 error. That's because the regular expression in `SiteUrls.config` is defined as ``\w+`, i.e. only letters, digits, and underscores. Again no underscores. Fortunately, there's no compilation required, instead change the regular expressions for `weblogpostName` and `weblogarticleName` to:

    ``` aspnet
    <url name="weblogpostName"
        location="weblogs" path="{0}/archive/{1}/{2}/{3}/{4}.aspx"
        pattern="([\w\.-]+)/archive/(\d{4})/(\d{1,2})/(\d{1,2})/([a-zA-Z][1234567890a-zA-Z\-_]*)\.aspx"
        vanity="post.aspx?App=$1&amp;y=$2&amp;m=$3&amp;d=$4&amp;PostName=$5" />
    <url name="weblogarticleName"
        location="weblogs" path="{0}/articles/{1}.aspx"
        pattern="([\w\.-]+)/articles/([a-zA-Z][1234567890a-zA-Z\-_]*)\.aspx"
        vanity="post.aspx?App=$1&amp;PostName=$2" />
    ```

    (Be careful if your `SiteUrls.config` differs from the default configuration, e.g. if you have used Ken Robertson's [SiteUrls Generator](http://www.qgyen.net/csaddins/singlesite/).)

If you're using ScottW's [auto-naming module](http://scottwater.com/blog/archive/2005/09/23/Auto_Name_Your_CS_Posts.aspx), you can skip step one including the re-compilation and just edit your `SiteUrls.config`.


