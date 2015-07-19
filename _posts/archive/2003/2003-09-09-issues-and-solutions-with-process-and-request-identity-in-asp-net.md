---
layout: post
title: 'Issues and solutions with Process and Request Identity in ASP.NET '
date: 2003-09-09 08:31:00 +02
comments: true
disqus_identifier: 181
categories: [Development]
redirect_from:
  - /blog/archive/2003/09/09/181.aspx/
---

> Just found a great KB article that explains how deal with all kinds of permission and identity issues when doing stuff from ASP.NET. I've highlighted the sections so you can see all the tasks that could use configurations:
>
> [INFO: Process and Request Identity in ASP.NET](http://support.microsoft.com/default.aspx?scid=http://support.microsoft.com:80/support/kb/articles/q317/0/12.asp&NoWebContent=1)
>
> -   [SUMMARY](http://support.microsoft.com/default.aspx?scid=http://support.microsoft.com:80/support/kb/articles/q317/0/12.asp&NoWebContent=1#1)
> -   [MORE INFORMATION](http://support.microsoft.com/default.aspx?scid=http://support.microsoft.com:80/support/kb/articles/q317/0/12.asp&NoWebContent=1#2)
>     -   [Configure the Process Identity](http://support.microsoft.com/default.aspx?scid=http://support.microsoft.com:80/support/kb/articles/q317/0/12.asp&NoWebContent=1#3)
>     -   [Default Permissions for the ASPNET Account](http://support.microsoft.com/default.aspx?scid=http://support.microsoft.com:80/support/kb/articles/q317/0/12.asp&NoWebContent=1#4)
>     -   [Accessing Resources](http://support.microsoft.com/default.aspx?scid=http://support.microsoft.com:80/support/kb/articles/q317/0/12.asp&NoWebContent=1#5)
>         -   [Using File Resources](http://support.microsoft.com/default.aspx?scid=http://support.microsoft.com:80/support/kb/articles/q317/0/12.asp&NoWebContent=1#5a)
>         -   [Enabling Impersonation](http://support.microsoft.com/default.aspx?scid=http://support.microsoft.com:80/support/kb/articles/q317/0/12.asp&NoWebContent=1#5b)
>         -   [Using Databases](http://support.microsoft.com/default.aspx?scid=http://support.microsoft.com:80/support/kb/articles/q317/0/12.asp&NoWebContent=1#5c)
>         -   [Using the Event Log](http://support.microsoft.com/default.aspx?scid=http://support.microsoft.com:80/support/kb/articles/q317/0/12.asp&NoWebContent=1#5d)
>         -   [Using System.DirectoryServices and Active Directory](http://support.microsoft.com/default.aspx?scid=http://support.microsoft.com:80/support/kb/articles/q317/0/12.asp&NoWebContent=1#5e)
>         -   [Using Performance Counters](http://support.microsoft.com/default.aspx?scid=http://support.microsoft.com:80/support/kb/articles/q317/0/12.asp&NoWebContent=1#5f)
>         -   [Starting Out-of-Process COM Servers](http://support.microsoft.com/default.aspx?scid=http://support.microsoft.com:80/support/kb/articles/q317/0/12.asp&NoWebContent=1#5g)
>         -   [Debugging Issues](http://support.microsoft.com/default.aspx?scid=http://support.microsoft.com:80/support/kb/articles/q317/0/12.asp&NoWebContent=1#5h)
>         -   [Running Code with a Fixed Identity](http://support.microsoft.com/default.aspx?scid=http://support.microsoft.com:80/support/kb/articles/q317/0/12.asp&NoWebContent=1#5i)
>         -   [Compiling Code-Behind Files on UNC Shares](http://support.microsoft.com/default.aspx?scid=http://support.microsoft.com:80/support/kb/articles/q317/0/12.asp&NoWebContent=1#5j)
>         -   [Using ASP.NET on a Primary or Backup Domain Controller](http://support.microsoft.com/default.aspx?scid=http://support.microsoft.com:80/support/kb/articles/q317/0/12.asp&NoWebContent=1#5k)
>         -   [Reading the IIS Metabase](http://support.microsoft.com/default.aspx?scid=http://support.microsoft.com:80/support/kb/articles/q317/0/12.asp&NoWebContent=1#5l)
>         -   [Using System.Management and WMI](http://support.microsoft.com/default.aspx?scid=http://support.microsoft.com:80/support/kb/articles/q317/0/12.asp&NoWebContent=1#5m)
>         -   [Interacting with the Desktop](http://support.microsoft.com/default.aspx?scid=http://support.microsoft.com:80/support/kb/articles/q317/0/12.asp&NoWebContent=1#5n)
>         -   [Removing ASP.NET](http://support.microsoft.com/default.aspx?scid=http://support.microsoft.com:80/support/kb/articles/q317/0/12.asp&NoWebContent=1#5o)
> -   [REFERENCES](http://support.microsoft.com/default.aspx?scid=http://support.microsoft.com:80/support/kb/articles/q317/0/12.asp&NoWebContent=1#6)

Thanks for [the reference](http://weblogs.asp.net/rosherove/posts/26732.aspx), [Roy Osherove](http://weblogs.asp.net/rosherove/).

