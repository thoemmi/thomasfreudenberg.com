---
layout: post
title: 'Shut down Windows 2003 without being hassled'
date: 2004-04-06 04:18:00 +02
comments: true
disqus_identifier: 373
categories: [Software]
redirect_from:
  - /blog/archive/2004/04/06/Shut-down-Windows-2003-without-being-hassled.aspx
  - /blog/archive/2004/04/06/373.aspx
---

[Jeff Key](http://weblogs.asp.net/jkey/) [describes](http://weblogs.asp.net/jkey/archive/2003/12/22/45300.aspx), how to disable this annoying dialog when shutting down a Windows 2003 server:

> If you're like me, every time you shut down or reboot Win2003 and are faced with the dialog asking why you're shutting down, you think “bloody hell, when I log back in I'm going to remove that dialog for good!”. While it's rebooting/shutting down, you grab a beverage, chat with your coworkers and possibly even play Halo if you're one of the eight people still employed by an “internet startup company”. By the time the OS is done shutting down/rebooting, the offending dialog box is a long-lost memory. ..Until you need to shut down again and the nightmare returns.
>
> This is my reminder to you. Do it now. You deserve it!
>
> The tip below is from one of my favorite email newsletters, [Windows Tips & Tricks UPDATE](http://www.winnetmag.com/email):
>
> Q. How can I use Group Policy to disable the Windows Server 2003 Shutdown Event Tracker?
>
> A. Like Windows 2000, Windows 2003 has an event tracker that prompts you to enter a reason for shutting down a server. To disable this feature, perform the following steps:
>
> 1.  Open the Microsoft Management Console (MMC) Group Policy Editor (GPE) snap-in or use Windows 2003 Group Policy Management Console (GPMC) to load the Group Policy Object (GPO) that you want to modify (e.g., the Default Domain Controllers policy).
> 2.  Navigate to Computer Configuration, Administrative Templates, System.
> 3.  Double-click Display Shutdown Event Tracker.
> 4.  Select Disabled, then click OK.
> 5.  Use the Gpupdate command to force the policy to refresh.

**Update:** I've made a screenshot where to find the setting:

![Shut down Windows 2003 without being hassled](/files/archive/gpedit.png)

