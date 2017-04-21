---
layout: post
title: 'Cleaning NuGet''s cache'
comments: true
tags: [NuGet,PowerShell]
keywords: [NuGet,PowerShell,Cache,Clean]
disqus_identifier: 50006
---

From the beginning NuGet used a per-solution folder `packages` to store all packages for
the projects in a solution. (Does anyone else remember the numerous discussion whether
that folder belongs into the VCS or not?).

[That changed](http://blog.nuget.org/20151008/NuGet-3-What-and-Why.html) with NuGet 3 and
`project.json`-based projects:

> ### Global Packages Folder
>
> With Project.JSON managed projects, there is now a packages folder that is shared for
> all projects that you work with. Packages are downloaded and stored in the
> `%userprofile%\.nuget\packages` folder. This means that if you are working on multiple
> UWP projects on your workstation, you only have one copy of the EntityFramework package
> and its dependencies on your machine. All .NET projects will acquire package references
> from this global shared folder. This also means that when you need to configure a new
> project, your project will not take time starting so that it can download a fresh copy
> of `EntityFramework.nupkg` Instead, it will simply and quickly reference the files you
> have already downloaded. ASP.NET 5 uses the `%userprofile%\.dnx\packages` folder and as
> that framework nears completion it will use the `%userprofile%\.nuget\packages` folder
> as well.

Well, I didn't pay much attention to that change, until I ran out of disk space last
week and used [WinDirTree](https://windirstat.net/) to find the culprit. Indeed, the size
of my packages folder was more than 6 GB.

Therefore I wrote a small PowerShell script which deletes all packages which haven't
been accessed for a configurable number of days (150 by default):

{% gist c76f1a5533fa86e631b2ed9bbc43c412 Clear-NuGetCache.ps1 %}

Don't worry that you could delete a package which you would need later again. NuGet will
just download the missing package again.

The script support the `-WhatIf` parameter, so calling

```powershell
.\Clear-NuGetCache.ps1 -CutOffDays 90 -WhatIf
```
wouldn't delete a single byte but log which folders the script would remove.