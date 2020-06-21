---
layout: post
title: 'Images&#58; relative vs. absolute'
date: 2003-09-08 21:04:00 +02
comments: true
disqus_identifier: 178
tags: [Site news]
redirect_from:
  - /blog/archive/2003/09/08/178.aspx
---

I've updated the img tags in my previous posts. I've used relativ links (i.e. `\<src img="/images/..." /\>`). It looked ok in [SharpReader](http://www.sharpreader.net), but, unfortunatley, not in [RSS Bandit](http://www.rssbandit.org). The latter wasn't able to locate the images. It tried to load the images relative to `about:blank`. Of course that cannot work ;-)

IIRC this issue has been discussed before somewhere, but I cannot remember the place. I will have a look tomorrow at work, since I'm using SharpReader there for about 4 month. I hope I'm able to find this issue in its history.

Anyway, I've updated the image links to absolute.
