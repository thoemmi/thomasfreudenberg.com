---
layout: post
title: 'Remote Access to SQL Server Express'
date: 2006-09-29 06:40:48 +02
comments: true
disqus_identifier: 17882
categories: [Development, Tips 'n Tricks, SQL Server]
redirect_from:
  - /blog/archive/2006/09/29/Remote-Access-to-SQL-Server-Express.aspx/
---

Today I tried to access a SQL Express server remotely for the first time. Because I'm writing this you may already guess that I had some trouble. In fact, I got several different error messages while playing around with configuration of the SQL server, e.g. SQL server does not allow remote connections, Server does not exist or access denied etc. After struggling with the *SQL Server Configuration Manager* and *SQL Server Surface Area Configuration* for about an hour, I finally consulted Google and found this article: [Configuring SQL Server Express 2005 for Remote Access when SQL Server does not allow remote connections](http://www.datamasker.com/SSE2005_NetworkCfg.htm "Configuring SQL Server Express 2005 for Remote Access when SQL Server does not allow remote connections"). It provides detailed step-by-step instructions, which finally helped me to solve my problem.

