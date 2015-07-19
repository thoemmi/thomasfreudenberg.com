---
layout: post
title: 'FeedBurner Site Statistics for CommunityServer'
date: 2007-01-04 13:27:00 +01
comments: true
disqus_identifier: 18930
categories: [Site news, Community Server, FeedBurner]
redirect_from:
  - /blog/archive/2007/01/04/feedburner-site-statistics-for-communityserver.aspx/
---

Today [Nick Bradbury wrote](http://nick.typepad.com/blog/2007/01/feedburner_site.html):

> The statistics packages offered by most popular blogging services are either limited or non-existent, leaving many bloggers struggling to get good information on traffic to their blog.  Those of us who use FeedBurner have long had good feed-related statistics, but we've had to rely on other services to get information on blog traffic.
>
> In my case, I've been using [Google Analytics](http://www.google.com/analytics/) for blog stats, and while it's a good service I've found it awkward to have my feed stats and blog stats in different places.  So when I was offered an early look at FeedBurner's [site statistics service](http://blogs.feedburner.com/feedburner/archives/2007/01/a_360_degree_view_of_audience_1.php) (announced earlier today), I jumped at the chance.
>
> I've been using FeedBurner's site stats for several days now, and overall they've done a great job of providing a lot of information in a very friendly way.  Now in addition to seeing information about my feed subscribers, I can also see things like:
>
> -   Which searches lead people to my blog
> -   Which external links are bringing visitors to my blog
> -   Which pages are being viewed the most
> -   What browsers, operating systems and screen resolutions my visitors are using
>
> In other words, I can see the sort of information you'd expect from a site statistics service, except that it's integrated with my feed stats.

I share the same history, been using Google Analytics and FeedBurner's Feed Stats for several month. Though Analytics is a nice service, it's mainly targeted at marketing. Too much for me simple guy, how only wants to know if the number of his readers becomes two-digit.

However, as Nick said FeedBurner announced their **site** statistic service, based on the acquired Blogbeat. I set it up for my blog two hours ago, and I already like it. Though not as sophisticated as Google Analytics, its interface is much cleaner and more appropriate for my simple needs.

But how do I come into play? Well, I was promoted a CommunityServer MVP more than two month ago, and since then I never gave back anything to the community.

Till now.

In the simplest case you only have to insert one line of HTML code to the page displaying your blog posts. However, since FeedBurner Site Stats can track your entire site, I developed a more generic implementation for CommunityServer:

-   You only have to change one file (at least one per blog theme)
-   It distinguishes blog posts from other pages automatically
-   It disables tracking if you are an owner of a particular blog
-   last but not least enable site stats only if the blog uses FeedBurner Feed stats, i.e. FeedBurner is configured as the External Feed URL

Anyway, here are the instructions. For each theme you have to make following changes in *LayoutTemplate.ascx*:

Add these two lines right after the *\<%@ Register* directives at the top:

``` aspx-cs
<%@ Import Namespace="CommunityServer.Components" %>
<%@ Import Namespace="CommunityServer.Blogs.Components" %>
```

Add following block right before the closing *\</body\>* tag:

``` aspx-cs
<% CSContext context = CSContext.Current; %>
<% Weblog currentBlog = Weblogs.GetWeblog(context.ApplicationKey); %>
<% if (!Globals.IsNullorEmpty(currentBlog.ExternalFeedUrl) && currentBlog.ExternalFeedUrl.StartsWith("http://feeds.feedburner.com/")) { %>
<% if (!context.IsAuthenticated || !Permissions.ValidatePermissions(currentBlog, Permission.Post, context.User)) { %>
<%     string feedBurnerAccount = currentBlog.ExternalFeedUrl.Substring("http://feeds.feedburner.com/".Length); %>
<%     BlogThreadQuery query = new BlogThreadQuery(); %>
<%     query.PostID = context.PostID; %>
<%     if (context.PostName != null) { %>
<%     query.PostName = context.PostName; %>
<%     } %>
<%     query.IncludeCategories = false; %>
<%     query.ReturnFullThread = false; %>
<%     query.SectionID = currentBlog.SectionID; %>
<%     PostSet postSet = WeblogPosts.GetPosts(query, true); %>
<%     WeblogPost blogPost = postSet.ThreadStarter as WeblogPost; %>
<%     if (blogPost != null) { %>
<script src="http://feeds.feedburner.com/~s/<%= feedBurnerAccount %>?i=<%= Globals.FullPath(BlogUrls.Instance().Post(blogPost)) %>" type="text/javascript" charset="utf-8"></script>
<%     } else { %>
<script src="http://feeds.feedburner.com/~s/<%= feedBurnerAccount %>" type="text/javascript" charset="utf-8"></script>
<%     } %>
<%   } %>
<% } %>
```

That's all.

