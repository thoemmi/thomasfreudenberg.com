---
layout: post
title: 'Enable shutdown button in Windows 2003''s login dialog '
date: 2004-04-06 22:40:00 +02
comments: true
disqus_identifier: 376
categories: [Software]
redirect_from:
  - /blog/archive/2004/04/07/EnableShutdownInLoginDialog.aspx
  - /blog/archive/2004/04/07/376.aspx
---

After I got rid of this [annoying shutdown dialog](/archive/2004/04/06/shut-down-windows-2003-without-being-hassled/), I have another tip for you. There's a shutdown button on the Windows 2003's login dialog, which is diabled all the time (at least on my machine). Google led me to [Brad Wilson](http://dotnetguy.techieswithcats.com/)'s [Windows Server 2003 Tip of the Day](http://dotnetguy.techieswithcats.com/archives/003718.shtml):

> Two of the most annoying things about being a developer using Windows 2003 in my mind are: (1) the shutdown dialog which forces you to fill out why you're shutting down, and (2) the lack of the shutdown button on the login dialog. Fortunately, remedying both is pretty simple.
>
> 1.  Start / Run / gpedit.msc
> 2.  Drill into Computer Configuration / Windows Settings / Security Settings / Local Policies / Security Options. Find the entry named "Shutdown: Allow system to be shut down without having to log on". Double click on it, change it to "Enabled".
> 3.  Drill into Computer Configuration / Administrative Templates / System. Find the entry named "Display Shutdown Event Tracker". Double click on it, change it to "Disabled".

Again, here's a screenshot:
 ![Enable shutdown button in Windows 2003s login dialog](/files/archive/gpedit2.png)


