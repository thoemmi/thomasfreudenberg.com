---
layout: post
title: 'Windows Server 2003 Password Manager and XP'
date: 2003-09-18 09:04:00 +02
comments: true
disqus_identifier: 197
categories: [Software]
redirect_from:
  - /blog/archive/2003/09/18/197.aspx/
---

Are you working with Windows Server 2003? Maybe you have noticed that *Stored User Names and Passwords* control panel applet:

![Stored User Names and Passwords](/files/archive/keymgr.png)

No more `net use /user:`. I wish Microsoft would have included it in XP already.

But wait... Maybe we can use that applet on Windows XP as well. In fact, the control panel applet's executable is `%SystemRoot%\System32\keymgr.cpl`. So if you have access to a Windows Server 2003 installation, just copy that file to your Windows XP box and open your control panel. Viola.

