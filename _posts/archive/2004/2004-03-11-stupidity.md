---
layout: post
title: 'Stupidity'
date: 2004-03-11 06:09:00 +01
comments: true
disqus_identifier: 349
tags: [Site news, .Text]
redirect_from:
  - /blog/archive/2004/03/11/Stupidity.aspx
  - /blog/archive/2004/03/11/349.aspx
---

Remember: if you patch your blogging engine, make sure everything works properly before publishing it! And backup everything!

Ok, what I'm talking about here is this: as you may know I'm using [.Text](http://dottextwiki.scottwater.com/) as my blog backend. Instead of using the pre-compiled binaries, I'm using the sources, which I compile directly. In fact, I do this in several stages:

1.  I have a folder which contains the current sources [synchronized with Vaultpub](http://scottwater.com/blog/archive/2004/01/12/11161.aspx).
2.  Another folder contains my *developer* version. This is the one I'm working with in VS.NET and doing my builds. Here I customize .Text to my needs. E.g. I added a [calendar](http://scottonwriting.net/sowblog/posts/708.aspx) and the [search](/archive/2004/02/05/updated-to-text-pre-96/). After synchronizing with the vault folder, I test it locally. Additionally, I update the database when required.
3.  If the previous version works properly, I copy all files necessary for publishing to a third folder called *live*. This includes files such as the \*.aspx and \*.dll files. I change the home directory in the IIS administrator to this folder and test it again.
4.  Last but not least, if the live version runs without issues, I upload the files to my web server.

Generally, this process works pretty well for me. Unfortunately, last month I haven't tested properly, therefore a buggy version got uploaded to my server: Adding new entries was not possible. The worst thing is, I already changed my local sources to the .96 development version, which is not intended to go live.

Fortunately, I do backups of the sources whenever I update my web server. Though it took several days to find the time to investigate the bug, I finally managed to get my blog working again.

Long story short:

-   Test your software before releasing it (which I didn't)
-   Backup your sources at release (which I did -- fortunately)
-   You can expect more posts coming on this blog than in the past

Thanks your patience ![:-)](/files/archive/smiley_smile.gif)

