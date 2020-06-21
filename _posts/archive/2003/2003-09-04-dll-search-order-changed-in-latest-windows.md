---
layout: post
title: 'DLL Search Order Changed in Latest Windows'
date: 2003-09-04 17:33:00 +02
comments: true
disqus_identifier: 162
tags: [Development]
redirect_from:
  - /blog/archive/2003/09/04/162.aspx
---

I found the following breaking change in the MSDN article "[Development Impacts of Security Changes in Windows Server 2003](http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncode/html/secure06122003.asp)" by Michael Howard:

> **DLL Search Order Has Changed**
>
> No longer is the current directory searched first when loading DLLs! This change was also made in Windows XP SP1. The default behavior now is to look in all the system locations first, then the current directory, and finally any user-defined paths. This will have an impact on your code if you install a DLL in the application's directory because Windows Server 2003 no longer loads the 'local' DLL if a DLL of the same name is in the system directory. A common example is if an application won't run with a specific version of a DLL, an older version is installed that does work in the application directory. This scenario will fail in Windows Server 2003.
>
> The reason this change was made was to mitigate some kinds of trojaning attacks. An attacker may be able to sneak a bad DLL into your application directory or a directory that has files associated with your application. The DLL search order change removes this attack vector.
>
> The `SetDllDirectory` function, also available in Windows XP SP1, modifies the search path used to locate DLLs for the application and affects all subsequent calls to the `LoadLibrary` and `LoadLibraryEx` functions by the application.

via [Paul Wilson](http://weblogs.asp.net/pwilson/posts/9214.aspx).
