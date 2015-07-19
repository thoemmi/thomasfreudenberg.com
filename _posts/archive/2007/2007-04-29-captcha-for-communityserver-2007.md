---
layout: post
title: 'CAPTCHA for CommunityServer 2007'
date: 2007-04-29 07:50:00 +02
comments: true
disqus_identifier: 28232
categories: [Site news, Community Server]
redirect_from:
  - /blog/archive/2007/04/29/captcha-for-communityserver-2007.aspx/
---

Brendan Tompkins released [CAPTCHA for CommunityServer 2007](http://codebetter.com/blogs/brendan.tompkins/archive/2007/04/27/captcha-for-community-server-2007.aspx):

> I'm happy to announce that CodeBetter.Com is carrying on the legacy of CAPTCHA for [Community Server](http://codebetter.com/controlpanel/blogs/www.communityserver.org).  CAPTCHA for CS2007 is the next generation of [CS Guru Dave Burke's](http://codebetter.com/controlpanel/blogs/www.dbvt.com) most excellent [CAPTCHA control for Community Server 2.1](http://dbvt.com/files/folders/addons/entry5198.aspx).  [This version is implemented as a Control Adapter](http://weblogs.asp.net/scottgu/archive/2005/12/21/asp-net-2-0-control-adapter-architecture.aspx) which allows CAPTCHA to be added to Community Server site-wide without touching any ASPX or ASCX markup code.
>
> [You can get the dll and source code here.](http://codebetter.com/files/folders/community_server_add-ons/entry162534.aspx)

The installation is pretty easy since Brendan leverages the same technique as I did for my [CS2007 coComment support](/archive/2007/04/24/cocomment-for-cs-2007-updated/): by using ControlAdapters not a single page or control must be touched.

In the past I always hesitated to use [CAPTCHA](http://en.wikipedia.org/wiki/CAPTCHA) on my blog because it´s an additional obstacle a commenter must overcome. Adding this hurdle seemed like a capitulation. But because spam has taken the upper hand over all comments I get, and CAPTCHAs are commonly used everywhere so the regular visitor is used to them, I´ll give it try and add Brendan´s CAPTCHA to my blog.

 

