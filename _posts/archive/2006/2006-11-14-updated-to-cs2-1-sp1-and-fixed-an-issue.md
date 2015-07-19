---
layout: post
title: 'Updated to CS2.1 SP1 and fixed an issue'
date: 2006-11-14 15:17:00 +01
comments: true
disqus_identifier: 18202
categories: [Site news, Community Server, coComment]
redirect_from:
  - /blog/archive/2006/11/15/updated-to-cs2-1-sp1-and-fixed-an-issue.aspx/
---

I just upgraded my site to Community Server 2.1 SP1. I wouldn't post this if I did not encounter an issue, though you may experience this error only if you use [my coComment support for CS](/archive/2006/09/19/updated-cocomment-support-for-community-server-2-1/). In fact, it occurs only if you use [BlogThreadQuery](http://code.communityserver.org/?path=CS+Tree%5cCS+2.1%5cBlogs%5cComponents%5cBlogThreadQuery.cs) and set `ReturnFullThread` to `false`. In this case, the stored procedure `cs_weblog_PostSet` does not return `ApplicationPostType` for found posts, but the code tries to retrieve it from the `IDataReader`.

I attached a corrected version of that SP to this post. In fact, I only added `P.ApplicationPostType,` in line 128.

