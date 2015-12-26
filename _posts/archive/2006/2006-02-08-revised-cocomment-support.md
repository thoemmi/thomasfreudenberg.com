---
layout: post
title: 'Revised coComment support'
date: 2006-02-08 14:05:00 +01
comments: true
disqus_identifier: 13631
tags: [Site news, Community Server, coComment]
redirect_from:
  - /blog/archive/2006/02/09/adding-coComment-support-to-CommunityServer.aspx
---

Yesterday Jayson Knight [described](http://jaysonknight.com/blog/archive/2006/02/08/7008.aspx) how to add [**coComment**](http://cocomment.com/) support to **CommunityServer**. I'm a user of coComment too, therefore I added Jayson's hack to my blog.

However, I don't like how the URL to the blog post is rendered (it's the rewritten URL, not the friendly one), so I decided to fix that. Furthermore, his solution does not work if you're logged in in CommunityServer, because in this case there's no field for the comment author's name. No offense, Jayson, since you admitting that your implemention is only a quick hack ;)

Anyway, here's what I came up with:

``` aspx-cs
<%@ Import Namespace="CommunityServer.Components" %>
<%@ Import Namespace="CommunityServer.Blogs.Components" %>
<% WeblogPost currentPost = WeblogPosts.GetWeblogEntry(CSContext.Current.BlogGroupID, CSContext.Current.PostID); %>
<% bool isAuthor = CSContext.Current.IsAuthenticated && CSContext.Current.User.UserID == currentPost.AuthorID; %>
<script type="text/javascript">
    var blogTool                = "<%=SiteStatistics.CommunityServerVersionVersionInfo %>";
    var blogURL                 = "<%=Globals.FullPath(currentPost.Weblog.HomePage) %>";
    var blogTitle               = "<%=currentPost.Weblog.Name %>";
    var postURL                 = "<%=Globals.FullPath(BlogUrls.Instance().Post(currentPost)) %>";
    var postTitle               = "<%=currentPost.Subject %>";
    var commentAuthorLoggedIn   = <%=Convert.ToString(isAuthor).ToLower() %>;
<% if (isAuthor) { %>
    var commentAuthor           = "<%=CSContext.Current.User.DisplayName %>";
<% } else{ %>
    var commentAuthorFieldName  = "<%=tbName.UniqueID %>";
<% } %>
    var commentFormName         = "__aspnetForm";
    var commentTextFieldName    = "<%=tbComment.UniqueID %>";
    var commentButtonName       = "<%=btnSubmit.UniqueID %>";
</script>
```

**Update:** There were two bugs: the value for `commentAuthorLoggedIn` was quoted and must be lower cased, and `commentButtonID` must be `commentButtonName`. I updated the script above.


