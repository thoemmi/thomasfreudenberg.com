---
layout: post
title: 'DateTime.ParseExact'
date: 2004-07-20 02:24:00 +02
comments: true
disqus_identifier: 428
categories: [Development]
redirect_from:
  - /blog/archive/2004/07/20/DateTime.ParseExact.aspx
---

If you're using [`DateTime.ParseExact`](http://msdn.microsoft.com/library/en-us/cpref/html/frlrfSystemDateTimeClassParseExactTopic.asp) with a custom format string including slashes, don't forget to escape them.

After I've catched `FormatExceptions` several times, I've found [this explanation](http://www.error-bank.com/microsoft.public.dotnet.framework/73802_Thread.aspx):

> '/' is the default date separator defined in DateTimeFormatInfo.DateSeparator.  Therefore you have to escape '/' with '\\' if you want to use it:
>
> ``` csharp
> System.DateTime.ParseExact("2004/05/31 16:19:43", @"yyyy\/MM\/dd HH:mm:ss", null);
> ```

