---
layout: post
title: '[TLS347] Introducing MSBuild&#58; The Universal Build Engine for Visual Studio &quot;Whidbey&quot; and &quot;Longhorn&quot;'
date: 2003-10-27 10:59:00 +01
comments: true
disqus_identifier: 246
tags: [PDC '03, MSBuild]
redirect_from:
  - /blog/archive/2003/10/27/_5B00_TLS347_5D00_-Introducing-MSBuild_3A00_-The-Universal-Build-Engine-for-Visual-Studio-_2600_quot_3B00_Whidbey_2600_quot_3B00_-and-_2600_quot_3B00_Longhorn_2600_quot_3B00_.aspx
  - /blog/archive/2003/10/27/246.aspx
  - /blog/posts/246.aspx
---

Several weeks ago I played around with NAnt, since we need a decent build environment for our new software. I've read about MSBuild a.k.a. XBuild before, but no information was available (at least outside Microsoft).

Today I attended the session about MSBuild. It bases on XML files, which are -- suprise, suprise -- similar to the build files of [NAnt](http://nant.sourceforge.com/). As far as I can see they have mainly the same feature set. However, the big advantage of MSBuild compared to NAnt is its integration and support by Whidbey. For NAnt you have to either maintain a *.build* and a *.vcproj* files, or use the new *solution* task, which is still a little bit buggy. For Whidbey, they have (once again ![sigh](/files/archive/smiley_sigh.gif)) changed the format of the *.vcproj* file, so it's the single place to edit your project.
