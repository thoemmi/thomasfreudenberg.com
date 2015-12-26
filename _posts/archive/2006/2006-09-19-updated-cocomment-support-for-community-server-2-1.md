---
layout: post
title: 'Updated coComment support for Community Server 2.1'
date: 2006-09-19 12:47:00 +02
comments: true
disqus_identifier: 17777
tags: [Community Server, Development, coComment]
redirect_from:
  - /blog/archive/2006/09/19/Updated-coComment-support-for-Community-Server-2.1.aspx
---

Yesterday the guys at coComment [updated their scripts](http://www.cocomment.com/teamblog/?p=117). They also refreshed the example for Community Server, but that's targetting CS 2.0. There are some breaking changes in the API of CS 2.1, so that code won't work with Telligent's latest release. Keyvan Nayyeri [updated the code](http://nayyeri.net/archive/2006/07/21/Adding-CoComment-support-to-Community-Server-2.1.aspx) some time ago. I polished it a little bit and incorporated the latest changes from coComment:

``` aspx-cs        
<%@ Import Namespace="CommunityServer.Components" %>
<%@ Import Namespace="CommunityServer.Blogs.Components" %>

<% CSContext context = CSContext.Current; %>
<% Weblog currentBlog = Weblogs.GetWeblog(context.ApplicationKey); %>
<% BlogThreadQuery query = new BlogThreadQuery(); %>
<% query.PostID = context.PostID; %>
<% if (context.PostName != null) { %>
<%   query.PostName = context.PostName; %>
<% } %>
<% query.IncludeCategories = false; %>
<% query.ReturnFullThread = false; %>
<% query.SectionID = currentBlog.SectionID; %>
<% PostSet postSet = WeblogPosts.GetPosts(query, true); %>
<% postSet.Organize(); %>
<% WeblogPost blogPost = postSet.ThreadStarter as WeblogPost; %>
<% bool isAuthor = context.IsAuthenticated; %>

<script type="text/javascript">
coco =
{
    tool       : "<%= SiteStatistics.CommunityServerVersionVersionInfo %>",
    siteurl    : "<%= Globals.FullPath(currentBlog.Url) %>",
    sitetitle  : "<%= currentBlog.Name %>",
    pageurl    : "<%= Globals.FullPath(BlogUrls.Instance().Post(blogPost)) %>",
    pagetitle  : "<%= blogPost.Subject %>",<% if (isAuthor) { %>
    author     : "<%= context.User.DisplayName %>",<% } else{ %>
    authorID   : "<%= tbName.UniqueID %>",<% } %>
    formID     : "aspnetForm",
    textareaID : "<%= tbComment.UniqueID %>",
    buttonID   : "<%= btnSubmit.UniqueID %>"
}
</script>
<script id="cocomment-fetchlet" src="http://www.cocomment.com/js/enabler.js"
    type="text/javascript">
</script>
```        

If you run CS 2.1 on ASP.NET 1.1, you have to change `formID` from `aspnetForm` to `__aspnetForm`.

What I don't understand however is why the `xxxID` variables require the name of the related control instead of the ID.
