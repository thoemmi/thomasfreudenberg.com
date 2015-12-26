---
layout: post
title: 'VC Build included in Visual Studio 2005 Beta 1'
date: 2004-07-09 14:09:00 +02
comments: true
disqus_identifier: 421
tags: [Development, Whidbey]
redirect_from:
  - /blog/archive/2004/07/09/VCBuild.aspx
  - /blog/archive/2004/07/09/421.aspx
---

Several month ago, [Peter Huene](http://weblogs.asp.net/peterhu/) introduced [VC Build](http://weblogs.asp.net/peterhu/archive/2004/02/10/71133.aspx), a command line tool to build C++ projects and solutions. For building our product, we have a huge batch file, which spawns devenv for every project. You have to know that devenv loads lots of DLLs and consumes much memory, even if you're just building a project from the command line. The number of our projects is triple-digit, so devenv is started more than a hundred times. The entire build of our software took on my machine 1 1/4 hours.

Then I changed our build scripts to use VC Build instead of devenv. Now the build takes about 45 minutes, i.e. it's reduced to 60%!

(First it didn't work properly, because VC Build didn't return an error code of the build failed. Peter [posted an update](http://weblogs.asp.net/peterhu/archive/2004/03/25/96235.aspx) after I and someone else reported some bugs)

Today I discovered that VC Build is not a nice tool hidden in the 'net anymore. Now it's part of Visual Studio 2005, at least part of Beta 1. You can find it in *\<whidbey installation path\>\\VC\\VCpackages\\*.

(I planned to post about VC Build for long time, but I've forgotten. Funny incidence that today I found VC Build in Whidbey, and [Jamie "NUnitAddin" Cansdale](http://weblogs.asp.net/nunitaddin/) [mentioned VC Build in his blog](http://weblogs.asp.net/nunitaddin/archive/2004/07/09/178378.aspx)).

