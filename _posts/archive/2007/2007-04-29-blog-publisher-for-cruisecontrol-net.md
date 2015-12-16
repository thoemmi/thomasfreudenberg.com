---
layout: post
title: 'Blog Publisher for CruiseControl.NET'
date: 2007-04-29 08:47:00 +02
comments: true
disqus_identifier: 28236
categories: [Development, MetaWeblogApi, ccnet]
redirect_from:
  - /blog/archive/2007/04/29/blog-publisher-for-cruisecontrol-net.aspx
---

Some time ago I wrote a blog publisher for [CruiseControl.NET](http://ccnet.thoughtworks.com/), but didn't manage to blog about it. In fact, it totally slipped my mind. However, my machine behaves more and more weird lately, so I started to clean up the hard disks and back up all my data. So today it happened that I stumbled over my old blog publisher and finally posted it here.

Background: CruiseControl.NET (CC.NET) is a [continuous integration](http://en.wikipedia.org/wiki/continuous%20integration) server for .NET. Publishers are tasks that are executed by CC.NET after a build is done, and are primarily used to report the build results, e.g. by sending emails.

There are instructions on [how to write your own publisher](http://confluence.public.thoughtworks.org/display/CCNET/Custom+Builder+Plug-in) available, so I created one which posts the build results to a blog. It stood to reason to access the blog using [MetaWeblog](http://en.wikipedia.org/wiki/MetaWeblog) API. Fortunately, [Charles Cook](http://www.cookcomputing.com/blog/index.html) wrote the [XML-RPC.NET](http://www.xml-rpc.net/) library, so my publisher degenerated to a simple gateway [;)]

The installation is simple: just drop the assemblies from the [ZIP file](/files/archive/ccnet.BlogPublisher.plugin.zip) to the `server` folder of CC.NET and restart the server. CC.NET uses a fixed naming scheme to find all extensions, that's why the assembly has that weird name `ccnet.BlogPublisher.plugin`.

The minimal configuration just takes details required to access a particular blog:

``` xml
<publishers>
    ...
    <blog>
        <url>http://localhost/MetaWeblog url</url>
        <blog>blog</blog>
        <username>username</username>
        <password>password</password>
    </blog>
```

With this configuration the publisher uses the default XSL files to transform the build results before posting them. But if you want to change the content of the blog post, you can specify which XSL files should be used. Additionally you can specify categories for the post:

``` xml
<publishers>
    ...
    <blog>
        <url>http://localhost/MetaWeblog url</url>
        <blog>blog</blog>
        <username>username</username>
        <password>password</password>
        <categories>
            <category>category 1</category>
            <category>category 2</category>
        </categories>
        <xslFiles>
            <xslFile>xsl\header.xsl</xslFile>
            <xslFile>xsl\modifications.xsl</xslFile>
            <xslFile>xsl\msbuild2ccnet.xsl</xslFile>
        </xslFiles>
    </blog>
```

The assembly is built with .NET 2.0, but it shouldn't be too difficult to change that. I even put the .NET 1.1 version of XML-RPC.NET into the ZIP file.


