---
layout: post
title: 'Pretzel Plugin: Sitemap'
comments: true
tags: [Pretzel]
disqus_identifier: 50001
keywords: [Pretzel,Plugin,Sitemap]
---

A couple of month ago [I wrote](/archive/2016/05/16/from-jekyll-to-pretzel/) that
I switched to **Pretzel** to drive my site.

What I really like about Pretzel (except that it's written in .NET) is that it is
so [easy to extend](https://github.com/Code52/pretzel/wiki/create-plugins). You can
write plugins either as a .NET assembly, or&mdash;even simpler&mdash;throw in an
`.csx` file, because Pretzel supports [ScriptCs](http://scriptcs.net/).

One of the first extensions I wrote was a **[site map](https://en.wikipedia.org/wiki/Site_map)**
plugin. By default Pretzel already creates a site map, but only for static pages.
Unfortunately, this doesn't include paginated pages like the home page. Those pages
are generated dynamically at runtime of Pretzel, and the default `sitemap.xml` doesn't
take those dynamic pages into account.

Therefore I wrote this plugin which creates the `sitemap.xml` including all generated
pages, even the paginated ones. It uses the same technique as
[`JekyllEngineBase.ProcessFile`](https://github.com/Code52/pretzel/blob/master/src/Pretzel.Logic/Templating/JekyllEngineBase.cs#L89):
for each post and page it adds an `url` entry to the sitemap. Additionally it checks
the page's front-matter if `paginate` is specified, and adds relevant URLs to the sitemap
too.

The plugin is [hosted on Github](https://github.com/thoemmi/Pretzel.Sitemap) including
some basic tests, but in fact you only have to copy
[`Pretzel.Sitemap.csx`](https://github.com/thoemmi/Pretzel.Sitemap/blob/master/Pretzel.Sitemap.csx)
to the `_plugin` folder of your Pretzel site.
