---
layout: post
title: '7Zip4Powershell in PowerShell Gallery'
comments: true
disqus_identifier: http://thomasfreudenberg.com/archive/2016/02/28/7zip4powershell-in-powershell-gallery/
tags: [7-zip, Powershell]
keywords: [7-zip, PowerShell, Gallery, 7Zip4PowerShell]
og_image: /files/archive/powershell-gallery_big.png
---

::: image-right
![PowerShell Gallery Logo](/files/archive/powershell-gallery.png)
:::

A few days ago the *Preview* suffix was removed from **PowerShell
Gallery**. This gallery is a central repository for PowerShell content
such as modules and scripts. You can read the [public
announcement](https://blogs.msdn.microsoft.com/powershell/2016/02/25/the-powershell-gallery-is-public/)
in the Windows PowerShell Blog. You can find instruction how to take
advantage of the gallery on its
[homepage](https://www.powershellgallery.com/), and more details on the [Get Started page](https://www.powershellgallery.com/GettingStarted?section=Get%20Started).

Until now I published
**[7Zip4PowerShell](https://github.com/thoemmi/7Zip4Powershell)**, my
PowerShell commands to compress and expand files with 7-Zip, as a plain
assembly. However, several users asked for a "real" PowerShell module. I took
the public release of the PowerShell gallery as an opportunity to
accommondate that demand. The 7Zip4PowerShell module is now [available
in the
gallery](https://www.powershellgallery.com/packages/7Zip4Powershell/1.2.0),
and installing it is as simple as invoking

``` powershell
Install-Module -Name 7Zip4Powershell
```

I'm very happy that the folks at Microsoft created that gallery, because it makes the discovery of interesting modules so much easier.