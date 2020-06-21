---
layout: post
title: 'What''s new in Whidbey for VC++ IDE'
date: 2004-05-06 06:31:00 +02
comments: true
disqus_identifier: 393
tags: [Development, Whidbey]
redirect_from:
  - /blog/archive/2004/05/06/WhidbeyCppFeatures.aspx
  - /blog/archive/2004/05/06/393.aspx
---

[Peter Huene](http://weblogs.asp.net/peterhu/) has [compiled a list of new features](http://weblogs.asp.net/peterhu/archive/2004/05/05/126767.aspx) in Whidbey related to C++.

The two features I like most are:

- Multi-proc builds: if you have multiple processors in your machine, you can build your projects in parallel.
  This works through utilizing project dependencies.
  So projects that don’t depend on one another (directly or indirectly) can build on different processors at the same time.
  This greatly reduces build times for large solutions that don’t have a lot of linear dependencies.
- Custom build rules: unlike custom build steps, which operate on a per-file basis, custom build rules allow you to specify how to build files of a particular type.
  So when you add a file of a matching extension to the project, the project system automatically associates the build rule with the file.
  Custom build rules are defined in XML files external to the project, so they can be applied to multiple projects easily.
  The best part of custom build rules is their ability to integrate into the project property pages like any of the other “built-in” tools (like the C/C++ compiler, the linker, etc).
  This means you can have friendly properties like “Include Directories” or “Warning Level” that gets translated into switches that appear on the command line.
  The look and feel of the integration into the property pages is completely configurable (from what appears in the property grid to what help the user gets when they hit F1 on each property in the property grid).
  I’ll go into this in more depth in my next post.

The first is great, because we have many multi-processor machines here at my company.

The second is even better. You know, we have developed our own programming language named *E*, which is a derivate of C. However, instead of *classes* we have *states*, i.e. each object is a state-machine. Having said that, in all our E-projects we have custom build steps to call our compiler. With the new Custom Build Rules, we are now able to configure only once how to handle the *\*.e* files.
