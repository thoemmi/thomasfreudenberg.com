---
layout: post
title: 'From Jekyll To Pretzel'
comments: true
disqus_identifier: http://thomasfreudenberg.com/archive/2016/05/16/from-jekyll-to-pretzel/
tags: [Jekyll, Pretzel]
---
[Some time ago](/archive/2015/12/31/first-stop-jekyll/) I told that I converted my blog
from CommunityServer to **Jekyll** on **Github Pages**. However, I was not satisfied with
that solution. Running a static site has one drawback: redirects for moved pages.

When you change the structure of a web site, you don't want old links to reference now
invalid URLs. That's would be called [**link rot**](https://en.wikipedia.org/wiki/Link_rot).
Instead, you want that users following a link to an old location are redirected to the
new page automatically.

Actually, there are plugins for Jekyll for redirection, the most popular is
[jekyll-redirect-from](https://github.com/jekyll/jekyll-redirect-from). However, what
it does is creating an HTML page at the old location with a `HTTP-REFRESH` meta tag
pointing to the new URL.

I don't like this solution because the status code of the HTTP response is **200**,
indicating that the old URL is still valid. I *guess* that Google or other search engines
pay attention to the `HTTP-REFRESH` meta tag, but nevertheless it's a bad idea for SEO
reasons.

Instead, a correct implementation would return the status code **302**, indicating that the
page moved permanently. Unfortunately that's not possible generally for static web sites.

That was the main reason I ditched Github Pages. I didn't want to go back to self-hosting
on a virtual server, so I decided to move my site to **Azure**. Additionally I took the
chance and replaced the blog engine too.

Not being a Ruby guy, I searched for a similar blog system but written in .NET. There are
a few, but the most appearing to me was the [**Pretzel**](https://github.com/Code52/pretzel).
Pretzel is an open source blog system, behaving more or less the same as Jekyll.
Additionally it supports several extension points, which I as a developer really like.

I'll write about running Pretzel on Azure and different Pretzel extensions I wrote in
some future posts.

**TL;DR:** I wanted to have more control over my website, therefore I moved from Github
Pages to Azure, and from Jekyll to Pretzel.