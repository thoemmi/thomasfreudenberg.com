---
layout: post
title: 'Auto-attaching to aspnet_wp.exe'
date: 2006-11-13 13:58:00 +01
comments: true
disqus_identifier: 18196
categories: [Community Server, Development, ASP.NET]
redirect_from:
  - /blog/archive/2006/11/13/Auto_2D00_attaching-to-aspnet_5F00_wp.exe.aspx
---

[Dennis van der Stelt](http://bloggingabout.net/blogs/dennis/) asked me how to debug CSModules without using the Community Server SDK. Ok, so here's how **I** debug my modules.

First I set the output directory of my projects to CS' bin folder. To debug the module, I attach the debugger manually to ASP.NET worker process, **aspnet\_wp.exe**. However, that's not very ergonomic, because you have to go to *Debug* → *Attach To Process*, select *aspnet\_wp.exe* (fortunately, processes are sorted by their name) and click *OK*.

However, after a while that gets really annoying.

Therefore I searched for a simpler solution, e.g. an add-in. I stumbled over this nice and short macro, [published by Roy Osherove](http://weblogs.asp.net/rosherove/archive/2003/09/22/28532.aspx) (who else? [;)]):

> This was on the win-tech-off-topic mailing list:
>
> A macro to automatically attach to **aspnet\_wp.exe**, written by [Kevin Dente](http://weblogs.asp.net/kdente/) can save lots of clicking around time:
>
> ``` vbnet
> Sub AttachAspNet()
>     Dim process As EnvDTE.Process
>     If Not (DTE.Debugger.DebuggedProcesses Is Nothing) Then
>         For Each process In DTE.Debugger.DebuggedProcesses
>             If (process.Name.IndexOf("aspnet\_wp.exe") \<\> -1) Then
>                 Exit Sub
>             End If
>         Next
>     End If
>     For Each process In DTE.Debugger.LocalProcesses
>         If (process.Name.IndexOf("aspnet\_wp.exe") \<\> -1) Then
>             process.Attach()
>             Exit Sub
>         End If
>     Next
> End Sub
> ```
>
> Unfortunately, it's not perfect. Process.Attach doesn't let you
> specify the program type (CLR, Script, native, etc). I think that it
> uses whatever your last selection was in the UI. But don't quote me
> on that, it's been a while.

I added the macro to a toolbar, so debugging my modules is only one click far. [:)]

