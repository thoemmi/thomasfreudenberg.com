---
layout: post
title: 'Moved Permanently'
date: 2003-10-25 12:36:00 +02
comments: true
disqus_identifier: 236
categories: [Site news]
redirect_from:
  - /blog/archive/2003/10/25/236.aspx
---

I just finished the [relocation](/archive/2003/10/23/this-moveto-thomasfreudenberg-com/) of my site.

I wanted to redirect all request to my old site to the new one. However, though I did know about the HTTP status codes 301 (moved permanently) and 302 (found respectively moved temporarily), I didn't know how to implement that in ASP.NET, since I'm not a web developer. Unfortunately, I wasn't able to find any hints with [Google](http://www.google.com).

But then I reviewed the [.Text](http://www.gotdotnet.com/Community/Workspaces/workspace.aspx?id=e99fccb3-1a8c-42b5-90ee-348f6b77c407) sources to see, how [Scott](http://scottwater.com/) has done all the http handlers. From that it was pretty easy to do that. By now, my old server redirect all requests to the new site permanently. On the other hand, on the new server all accesses to the root are directed to the sub-folder [*blog*](/) temporary.

I think I'm going to write a article about it (maybe at [CodeProject](http://www.CodeProject.com/)?), but not before the PDC has finished... ![Big Smile](/files/archive/smiley_biggrin.gif)

