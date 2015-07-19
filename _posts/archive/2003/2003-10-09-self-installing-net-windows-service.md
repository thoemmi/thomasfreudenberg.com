---
layout: post
title: 'Self-Installing .NET Windows Service'
date: 2003-10-09 16:57:00 +02
comments: true
disqus_identifier: 218
categories: [Development]
redirect_from:
  - /blog/archive/2003/10/09/218.aspx/
---

Did you ever write a .NET Windows service? What I really dislike about it is that though the framework provides the [`System.ServiceProcess.ServiceInstaller`](http://msdn.microsoft.com/library/en-us/cpref/html/frlrfSystemServiceProcessServiceInstallerClassTopic.asp) class, you still have to use the external [installutil](http://msdn.microsoft.com/library/en-us/cptools/html/cpconinstallerutilityinstallutilexe.asp) tool.

Well, at least until today.

After some googling I found [Craig Andera](http://staff.develop.com/candera/weblog2/)'s article [HowTo: Write a Self-Installing Service](http://staff.develop.com/candera/selfinstall.htm). Only a few lines of code are needed to get your service registering itself. ![Cool](/files/archive/smiley_cool.gif) Awesome, Craig.

Why didn't Microsoft document that way? (Ok, they doc'd [`TransactedInstaller`](http://msdn.microsoft.com/library/en-us/cpref/html/frlrfsystemconfigurationinstalltransactedinstallerclasstopic.asp), but if you don't know where to search... ![sigh](/files/archive/smiley_sigh.gif))

