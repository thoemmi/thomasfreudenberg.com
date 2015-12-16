---
layout: post
title: 'Save Bandwidth and Compress Your CommunityServer Feeds'
date: 2005-10-02 22:02:00 +02
comments: true
disqus_identifier: 12539
categories: [Community Server, Development]
redirect_from:
  - /blog/archive/2005/10/03/compress-your-communityserver-feeds.aspx
---

Now that my vacation and the PDC are over, I can continue with all the stuff which I left unfinished on my desk. One of these is a mod for CommunityServer which compresses all the exposed feeds. I've written it some weeks ago already and deployed it on my web server. Since it seems to work properly, I now want to announce it publicly. Though my bandwidth at [WebHost4Life](http://www.WebHost4Life.com/default.asp?refid=thoemmi) isn't limited, for some of you it may save real money.

The HTTP standard defines the compression of any content in [RFC 2616, section 3.5](http://www.w3.org/Protocols/rfc2616/rfc2616-sec3.html#sec3.5). [IIS supports compression](http://www.microsoft.com/technet/prodtechnol/WindowsServer2003/Library/IIS/25d2170b-09c0-45fd-8da4-898cf9a7d568.mspx), however, admin permissions on the server are required. So if your CS blog is hosted in a shared environment, you do not have access to the server. Therefore, you have to look for another solution.

Due to the nature of blogs, the most accessed part of a blog is its feed, or better, the feeds, as most blogs offer RSS as well as ATOM, and may even explose feeds for categories and comments. Therefore it makes sense to at least compress the feeds.

Some time ago Jeff Julian has written an [add-on for dotText](http://geekswithblogs.net/jjulian/archive/2004/01/10/1211.aspx) which compressed the RSS feed. [I used to use](http://geekswithblogs.net/jjulian/archive/2004/01/10/1211.aspx) this add-on on my blog as well, which reduced the size of my feed by about 80%.

Currently CommunityServer does not compress its feeds, and till now there is no add-on available which would add this functionality. Therefore I took Jeff's solution as a starting point and wrote a module myself. Now I'm happy to announce [Thoemmi.CommunityServer.Compression](/files/archive/Thoemmi.CommunityServer.Compression.zip) :-)

The installation is pretty easy: [Download the ZIP file](/files/archive/Thoemmi.CommunityServer.Compression.zip) and extract the DLL's to your `bin` folder. Then replace the handlers in the `httpHandlers` section in `web.config` to point to my classes. Here's a lineup of the corresponding items:

**Original blog RSS handler**  
`CommunityServer.Blogs.Components.WeblogRssHandler, CommunityServer.Blogs`

**Replacement**  
`Thoemmi.CommunityServer.Compression.CompressedWeblogRssHandler, Thoemmi.CommunityServer.Compression`

**Original blog ATOM handler**  
`CommunityServer.Blogs.Components.WeblogAtomHandler, CommunityServer.Blogs`

**Replacement**  
`Thoemmi.CommunityServer.Compression.CompressedWeblogAtomHandler, Thoemmi.CommunityServer.Compression`

**Original blog comment RSS handler**  
`CommunityServer.Blogs.Components.WeblogCommentRssHandler, CommunityServer.Blogs`

**Replacement**  
`Thoemmi.CommunityServer.Compression.CompressedWeblogCommentRssHandler, Thoemmi.CommunityServer.Compression`

**Original gallery RSS handler**  
`CommunityServer.Galleries.Components.GalleryRssHandler, CommunityServer.Galleries`

**Replacement**  
`Thoemmi.CommunityServer.Compression.CompressedGalleryRssHandler, Thoemmi.CommunityServer.Compression`

**Original forum RSS handler**  
`CommunityServer.Discussions.Components.ForumRssHandler, CommunityServer.Discussions`

**Replacement**  
`Thoemmi.CommunityServer.Compression.CompressedForumRssHandler, Thoemmi.CommunityServer.Compression`

If you have had a default installation before, the `httpHandlers` section should now contain following lines:

``` aspx-cs
<add verb="GET" path="blogs/rss.aspx"
    type="Thoemmi.CommunityServer.Compression.CompressedWeblogRssHandler, Thoemmi.CommunityServer.Compression" />

<add verb="GET" path="blogs/atom.aspx"
    type="Thoemmi.CommunityServer.Compression.CompressedWeblogAtomHandler, Thoemmi.CommunityServer.Compression" />

<add verb="GET" path="blogs/commentrss.aspx"
    type="Thoemmi.CommunityServer.Compression.CompressedWeblogCommentRssHandler, Thoemmi.CommunityServer.Compression" />

<add verb="GET" path="photos/rss.aspx"
    type="Thoemmi.CommunityServer.Compression.CompressedGalleryRssHandler, Thoemmi.CommunityServer.Compression" />

<add verb="GET" path="forums/rss.aspx"
    type="Thoemmi.CommunityServer.Compression.CompressedForumRssHandler, Thoemmi.CommunityServer.Compression" />
```

That's it. By default, the feeds are compressed with *deflate* with normal compression. If you want to change the compression level or switch to *gzip* compression, have a look at `web.config.merge` in the ZIP file. My add-on uses [Ben Lowery](http://www.blowery.org/)'s [HttpCompressionModule](http://www.blowery.org/code/HttpCompressionModule.html), which in turn uses [SharpZipLib](http://www.icsharpcode.net/OpenSource/SharpZipLib/Default.aspx). Both assemblies are included in the ZIP file as well.

BTW, if you want to check the compression of your feeds, PipeBoost generates [Web Compression Reports](http://pipeboost.com/report.asp).

[Update 10/14/2005: Fixed broken link]