---
layout: post
title: 'Windows caches file dates'
date: 2003-09-04 17:32:00 +02
comments: true
disqus_identifier: 161
categories: [Development]
redirect_from:
  - /blog/archive/2003/09/04/161.aspx/
---

There's has been an [informative discussion](http://www.codeproject.com/lounge.asp?select=559609&df=100&tid=559609&forumid=1159&app=50#xx559609xx) in [CodeProject](http://www.codeproject.com/)'s [Lounge](http://www.codeproject.com/lounge.asp) regarding cached file dates.

Here some quotes from MSDN:

> **File Times**
> A file time is a 64-bit value that represents the number of 100-nanosecond intervals that have elapsed since 12:00 A.M. January 1, 1601 (UTC). The system records file times whenever applications create, access, and write to files. **Not all file systems can record creation and last access time** and **not all file systems record them in the same manner**. For example, on NT FAT, create time has a resolution of 10 milliseconds, write time has a resolution of 2 seconds, and access time has a resolution of 1 day (really, the access date). On NTFS, access time has a resolution of 1 hour.

and in the documentation of CreateFile:

> **Windows NT/2000:** If you rename or delete a file, then restore it shortly thereafter, Windows NT searches the cache for file information to restore. Cached information includes its short/long name pair and creation time.

