---
layout: post
title: 'Hot to make APIs obsolete'
date: 2004-05-03 05:31:00 +02
comments: true
disqus_identifier: 391
tags: [Development]
redirect_from:
  - /blog/archive/2004/05/03/Obsoleting.aspx
  - /blog/archive/2004/05/03/391.aspx
---

[Brad Abrams](http://blogs.msdn.com/brada/) [points](http://blogs.msdn.com/brada/archive/2004/05/01/124548.aspx) to a document at GotDotNet explaining Micosoft's process to [make API's obsolete](http://www.gotdotnet.com/team/changeinfo/V2.0/obsoletefaq.aspx).

Interesting, how long it takes from making an API obsolete to finally removing it:

> **An API I was using is now marked obsolete, and gives me a warning. What will happen to it next?**
>
> The process for making an API obsolete is phased over time. Once an API is marked obsolete-as-warning, a full release must pass, at which point it will be marked obsolete-as-error. At this point, an attempt to recompile using the API will fail. Marking something as deprecation-as-error can only be performed during a standard release, never during a servicing release.
> The API will remain in this state for a minimum period of the servicing lifecycle for the release in which it was marked as an error to use. This is typically 7 years. Once that period is over, the API will be removed. At this point, applications attempting to bind or use a version of the library with the API, will fail.
