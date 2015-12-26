---
layout: post
title: 'NuGet package for 7Zip4Powershell'
date: 2013-04-19 18:06:19 +02
comments: true
disqus_identifier: 458166
tags: [7-zip, Powershell, NuGet]
redirect_from:
  - /blog/archive/2013/04/19/nuget-package-for-7zip4powershell.aspx
---

![nuget](/files/archive/nuget.png "nuget")

A few days ago I mentioned [7-Zip for Powershell](/archive/2013/04/07/7-zip-for-powershell/). I’ve now created a NuGet package and published it at [NuGet.org](https://nuget.org/packages/7Zip4Powershell/).

It took me a while to figure it out, but finally it’s a “tools only” package, i.e. it adds no references to your project.

To use the new commands just add the package to your solution and import it in your Powershell script:

    $SolutionDir = split-path -parent $PSCommandPath
    Import-Module (Join-Path $SolutionDir "packages\7Zip4Powershell.1.0\tools\7Zip4Powershell.dll")

