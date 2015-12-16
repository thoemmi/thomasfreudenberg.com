---
layout: post
title: '7-Zip for Powershell'
date: 2013-04-07 16:27:56 +02
comments: true
disqus_identifier: 458163
categories: [7-zip, Powershell]
redirect_from:
  - /blog/archive/2013/04/07/7-zip-for-powershell.aspx
---

![powershell\_logo](/files/archive/powershell_logo.jpg "powershell_logo")

At work we deal with different big databases, and by big I mean between 3.5 and 8 GB. Those databases are zipped with [7-Zip](http://7-zip.org/) and stored on a server. Depending on the scenario we unzip one of these databases to a local folder and attach it to the SQL Server. To simplify these steps we have a couple of Powershell scripts, among other things invoking the command line version of 7-Zip.

However, extracting an archive of several gigabytes over the network might take some time, and we’d like to see the progress in the Powershell console. Powershell provides a standard way to report progress by calling [`Cmdlet.WriteProgress`](http://msdn.microsoft.com/en-us/library/system.management.automation.cmdlet.writeprogress(v=vs.85).aspx), which then will be displayed by the current host (e.g. command line) appropriately.

Therefore with some support of a co-worker I’ve written two **Cmdlet**s for extracting and compressing archives. The syntax is simple as this:

    Expand-7Zip
        [-ArchiveFileName] <string>
        [-TargetPath] <string>
        [<CommonParameters>]

    Compress-7Zip 
        [-ArchiveFileName] <string> 
        [-Path] <string>
        [[-Filter] <string>]
        [-Format <OutArchiveFormat> {SevenZip | Zip | GZip | BZip2 | Tar | XZ}]
        [-CompressionLevel <CompressionLevel> {None | Fast | Low | Normal | High | Ultra}]
        [-CompressionMethod <CompressionMethod> {Copy | Deflate | Deflate64 | BZip2 | Lzma | Lzma2 | Ppmd | Default}]
        [<CommonParameters>]

It works with both x86 and x64 and uses [SevenZipSharp](https://sevenzipsharp.codeplex.com/) as a wrapper around 7zip’s API.

![7zip4powershell](/files/archive/7zip4powershell.png "7zip4powershell")

You can download the cmdlets with the required libraries [here](/files/archive/7Zip4Powershell.zip) or grap the sources at [Github](https://github.com/thoemmi/7Zip4Powershell).

