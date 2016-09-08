---
layout: post
title: 'Password support in 7Zip4Powershell'
comments: true
disqus_identifier: http://thomasfreudenberg.com/archive/2016/03/31/7zip4powershell-with-password-support/
tags: [7-zip, Powershell]
keywords: [7-zip, PowerShell, Gallery, 7Zip4PowerShell]
og_image: /files/archive/7zip4powershell-logo_big.png
---

::: image-right
![PowerShell Gallery Logo](/files/archive/7zip4powershell-logo.png)
:::

A few minutes ago I published the new version 1.3 of [7Zip4PowerShell](https://github.com/thoemmi/7Zip4Powershell).
[Isaac Springer](http://blog.onyxhat.com/) [asked](https://github.com/thoemmi/7Zip4Powershell/issues/8) for password support when creating or extracting archives, so I
added the optional parameter `-Password` to both `Compress-7Zip` and `Expand-7Zip`.

You can get the new version at [NuGet](https://www.nuget.org/packages/7Zip4Powershell/1.3.0) as well as
[PowerShell Gallery](https://www.powershellgallery.com/packages/7Zip4Powershell/1.3.0).