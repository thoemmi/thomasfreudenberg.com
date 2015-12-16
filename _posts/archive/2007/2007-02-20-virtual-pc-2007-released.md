---
layout: post
title: 'Virtual PC 2007 released'
date: 2007-02-20 12:07:00 +01
comments: true
disqus_identifier: 22666
categories: [Software, Tips 'n Tricks, Virtual PC]
redirect_from:
  - /blog/archive/2007/02/20/virtual-pc-2007-released.aspx
---

![myvirtualmachines Environment variable](/files/archive/MyVirtualMaschines.png "myvirtualmachines Environment variable")

Earlier today Microsoft released [Virtual PC 2007](http://www.microsoft.com/windows/products/winfamily/virtualpc/default.mspx). Generally this wouldn't be worthwhile to be mentioned on my blog. However, I'll write this nevertheless because whenever I install Virtual PC, I want to customize the path where the files for the virtual machines are stored, and each time I have look up the information how to accomplish that.

By default, Virtual PC's setup creates a *My Virtual Machines* folder in *My Documents*. Though the primary HDD of my machine is a 10.000 RMP beast, I have two additional 10.000s combined to a RAID0, and that's a **perfect** host for my virtual machines.

Luckily, you are able to customize where Virtual PC stores that files. You only have to specify your desired path in an environment variable named *myvirtualmachines*.

Though it's even documented in a [knowledge base article](http://support.microsoft.com/kb/831506 "The My Virtual Machines folder and virtual machine performance issues"), I know my blog better than the knowledge base so I post it here [;)]


