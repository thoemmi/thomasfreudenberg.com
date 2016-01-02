---
layout: post
title: 'My Journey to Pretzel: First Stop Jekyll'
comments: true
tags: [Jekyll, CommunityServer]
---
As described in my [previous post](/archive/2015/12/30/journey_to_pretzel/), I decided to replace my CommunityServer setup with a static site generator. Being a vivid GitHub user, the first choice was [GitHub Pages](https://pages.github.com/). GitHub Pages allows you to commit your site to a repository and let GitHub serve it using [Jekyll](http://jekyllrb.com/).

I won't go into detail how to setup Jekyll or GitHub Pages. You'll be able to find enough information in the internet. Phil Haack, a much better story teller than me, wrote an article about [his migration from SubText to Jekyll](http://haacked.com/archive/2013/12/02/dr-jekyll-and-mr-haack/). He also gave advice how to [preserve all comments with Disqus](http://haacked.com/archive/2013/12/09/preserving-disqus-comments-with-jekyll/). 

So my first step was to get the data of my existing site out of CommunityServer and into a format that Jekyll understands. [Keyvan Nayyeri](http://www.keyvan.tech/) wrote once [an extension for CommunityServer](http://blogml.codeplex.com/) to download the content as a [BlogML](https://en.wikipedia.org/wiki/BlogML) document (a standarized XML format for storing blog content).

Then I found [BlogMLToMarkdown](https://github.com/pcibraro/BlogMLToMarkdown), a command line tool transforming a BlogML document to markdown documents ready to be consumed by Jekyll.

However, I had to tweak that tool for my needs. Amongst others it
* downloads all images, attachments, and other files hosted on my old site and changes the referencing links,
* fixes redirects, and
* exports all (approved) comments to a `disqus.wxr`, ready to be imported into [Disqus](https://disqus.com/).

If you're interested you can see my [fork at Github](https://github.com/thoemmi/BlogMLToMarkdown).

After I transformed my blog and tweaked the style (it's based on [Hyde](http://hyde.getpoole.com/)), I committed it to a GitHub repository, where it was happily hosted.

However, this setup had some drawbacks, which I will discuss in another post.