---
layout: post
title: 'Sharing Extension for Graffiti'
date: 2008-02-04 10:52:00 +01
comments: true
disqus_identifier: 58262
categories: [Graffiti]
redirect_from:
  - /blog/archive/2008/02/04/sharing-extension-for-graffiti.aspx/
---

Two weeks ago [Telligent](http://telligent.com/) published the second beta of their upcoming new product [Graffiti](http://graffiticms.com/). It is a simple lightweight content management system. And by simple I don't mean lame. Far from it! It is simple in the sense of easy deployment, management, and publishing.

Additionally it's easy to extend. [Keyvan](http://nayyeri.net/), who I got to know and appreciate while working on the [Community Server Modules](http://csmvps.com/news/archive/2007/05/13/community-server-mvps-cinnabar-csmodule-package.aspx), already [wrote](http://nayyeri.net/blog/post-navigator-extension-for-graffiti/) [several](http://nayyeri.net/blog/community-credit-plug-in-for-graffiti/) [extensions](http://nayyeri.net/blog/search-relevancy-extension-for-graffiti/) for Graffiti. To wrap up all his addons and provide a simple installation experience [he started](http://nayyeri.net/blog/introducing-graffiti-extras/) the [Graffiti Extras project](http://www.codeplex.com/GraffitiExtras) on CodePlex. And he was kind enough to accept me as a contributor.

![](/files/archive/SharingExtension.png)

So here it is, my first extension for Graffiti. In fact, I was inspired by Danny Douglass' [Social Bookmarks extension](http://www.dannydouglass.com/post/2008/01/Add-Social-Bookmarking-Links-To-Your-Blog.aspx) for BlogEngine.NET. It enables you to link your posts to some of the most popular social bookmarking sites. The image to the right depicts an exemplary post with the extension rendered below.

### Implementation

The Sharing extension is implemented as a so called [**chalk**](http://graffiticms.com/support/advanced-options/chalk-overview/). Think of chalks as of macros. How to write your own chalk is [well-documented](http://graffiticms.com/support/advanced-options/extending-chalk/), so I won't describe how I implemented the Sharing extension. If you want to have a look at the sources, go to the [GraffitiExtras project](http://www.codeplex.com/GraffitiExtras) on CodePlex and either download them or browse them online.

### Installation

To install the Sharing chalk (and all other extensions provided in Graffiti Extras) download the attached [ZIP File](/files/archive/GraffitiExtras.zip). This archive contains two root folders: in the *bin* folder you can find the *GraffitiExtras.dll* which you must drop into the *bin* folder of your Graffiti installation. The second folder, *sharing-images*, contains two flavors of icons in different sizes (16x16, 24x24, 32x32, and 48x48) for several social bookmarking sites (original icons are provided by [FastIcon](http://fasticon.com/freeware)). Either copy that folder entirely or only the desired flavor/sizes somewhere to the Graffiti web folder.

### Usage

To add the sharing extension to your posts, you just have to add a single line to your theme file:

    $sharing.Write($post, "<image folder>")

Replace `image folder` with the path to the desired images. E.g. if you have copied the entire *sharing-images* folder to the root of your web application, and you want to see the round images with a size of 16x16, you would add following line:

    $sharing.Write($post, "/sharing-images/circle/16x16/")

By default the different images are separated by a non-breaking space (`&nbsp;`) but you can change that with the optional third parameter:

    $sharing.Write($post, "<image folder>", " | ")
