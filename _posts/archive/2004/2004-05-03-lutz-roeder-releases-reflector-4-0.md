---
layout: post
title: 'Lutz Roeder releases Reflector 4.0'
date: 2004-05-03 07:52:00 +02
comments: true
disqus_identifier: 392
categories: [Development, Tools]
redirect_from:
  - /blog/archive/2004/05/03/Reflector40.aspx
---

[Chris Sells wrote](http://www.sellsbrothers.com/news/showTopic.aspx?ixTopic=1314):

> It has been hell keeping this to myself as Lutz has been sending me beta drops for the last coupla months for the completely reworked Reflector 4.0. Two very cool things about this release of Reflector:
>
> 1.  It supports any version of the .NET Framework, so it works great on Longhorn and Whidbey
> 2.  It has a replacement for the Class Viewer tools in the .NET SDK (wincv.exe) that I came to depend on in my writing and that hasn't been updated for WinFX, so Reflector 4.0 is even more important to me than it would normally be
>
> If you're a .NET developer, you must use Reflector and if you use Reflector, [you must use Reflector 4.0](http://www.aisto.com/roeder/DotNet/). Thanks, Lutz! We love you, man!
>
> BTW, Lutz has set up [a workspace for the Reflector 4.0 add-ins](http://www.gotdotnet.com/community/workspaces/workspace.aspx?ID=0F5846C3-C7AA-4879-8043-E0F4FC233ADE).

Here're the release notes:

> Reflector is a class browser for .NET components. It allows browsing and searching the meta data, IL instructions, resources and XML documentation stored in a .NET assembly. Reflector was first released in October 2000 running on .NET Framework 1.0 Beta 2.
>
> **Code Model:** While previous versions of Reflector partly used the CLR Reflection infrastructure, the new version 4.0 has changed to use a code model library for reading assembly files into memory. As a result Unload and Refresh operations really unload files from memory and Reflector is no longer locking files on disk.
>
> **Reflector and .NET Framework 2.0:** Reflector.exe runs on all .NET Framework versions. The new code model library loads .NET Framework 2.0 assemblies with no .NET Framework 2.0 installed. However, a [Reflector.exe.config](http://www.aisto.com/roeder/dotnet/Reflector.exe.config) file is still going to make Reflector run faster on .NET Framework 2.0.
>
> **Assembly Cache:** When resolving an assembly reference, Reflector will first search the local path and then falls back to the cache directories defined in the Reflector.cfg file. Reflector doesn't search the GAC unless you add "%SystemRoot%\\Assembly" to the cache directories list.
>
> **Search and Callee Graph:** There is now only one search window (F3). You can click on the icon on the top-right to switch to search members (this was previously called member search). The reference search windows are replaced with a callee graph window that shows any kind of dependencies of a type or member.
>
> **Command Line:** The /configuration switch allows you to specify a config file different from Reflector.cfg. The /fontsize and /fontname switches can be used to increase the font size for overhead demos.
>
> **Assembly Versioning:** By default, assembly version numbers are ignored when resolving type and member references. You can enable side-by-side versioning in the options dialog but it is suggested to avoid this if possible.
>
> **Add-Ins:** Reflector add-ins and hosting projects can be found [here](http://workspaces.gotdotnet.com/reflector). An introduction to the add-in model is available [here](http://www.gotdotnet.com/Community/Workspaces/UploadedHtmlPage.aspx?FileID=f1751793-88aa-4c36-935d-3d4c654d9300).
>
> **WinFX Help:** To view the Longhorn MSDN documentation instead of the .NET Framework MSDN documentation add a [WebSearch] section to your Reflector.cfg file with Msdn=<http://longhorn.msdn.microsoft.com>.

I still don't know, why you're asked for your name and email address before you can download it.

