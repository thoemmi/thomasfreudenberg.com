---
layout: post
title: 'Microsoft''s Giving Away Its Most Prized Tools'
date: 2004-05-27 09:22:00 +02
comments: true
disqus_identifier: 404
tags: [Development]
redirect_from:
  - /blog/archive/2004/05/27/ToolsInWhidbey.aspx
  - /blog/archive/2004/05/27/404.aspx
---

While downloading [Whidbey CTP May 04](/archive/2004/05/27/visual-studio-2005-community-technology-preview-may-2004/), I'm just reading [Wesner Moise](http://wesnerm.blogs.com/net_undocumented/)'s *[Microsoft's Giving Away Its Most Prized Tools](http://wesnerm.blogs.com/net_undocumented/2004/05/microsofts_givi.html)*:

> Microsoft is *finally* releasing many of its prized tools into the [next version of Visual Studio](http://msdn.microsoft.com/vstudio/productinfo/roadmap.aspx).
>
> - ***POGO***. This is the profile guided optimizations available in Visual C++ 2005. POGO rearranges code to shift out rarely used code and cluster together related code, resulting in reduced working set and substantially improved performance for common application scenarious. This tool alone can potentially double the performance of your app. This has been MS's secret weapon for ages, and now MS is arming the masses.
> - ***PREfast***. This is an extremely intelligent code analyzer, produced by one of PhDs in Microsoft Research, that scans machine level instructions in the binary executable, follows multiple code paths and traverses function calls, all to locate extremely hard to find programming errors. How intelligent is PREFast, you ask? It had to be written in Prolog, the logic programming language, instead of C++. At least one [MS developer](http://rob.crabapples.net/archive/2004_05_23_default.htm#108559022050978424)is shocked at its release. Check out this [MS Research PREFast presentation](http://research.microsoft.com/specncheck/docs/pincus.ppt)on the Web. Unfortunately, PREfast only works in C++.
> - ***FXCop***. This product has been [available for some time](http://www.gotdotnet.com/team/fxcop/), but Microsoft developers use it religiously for ensure that all new managed APIs conform to .NET Framework guidelines and does not contain potential errors.
> - ***VS Team Foundation source code control system?*** Though the team is lead by the original developer of SourceSafe, this SCM is an entirely different product from SourceSafe, and both this and SourceSafe 2005 will simultaneously ship with Whidbey. Now, I don't know if this is the same source code control that Microsoft is currently using internally for Windows and Office to manage code changes by, literally, thousands of developers. But if it is, this would be a truly amazing addition.
