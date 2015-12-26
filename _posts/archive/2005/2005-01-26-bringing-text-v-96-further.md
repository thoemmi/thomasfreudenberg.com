---
layout: post
title: 'Bringing .Text v.96 further'
date: 2005-01-26 06:31:00 +01
comments: true
disqus_identifier: 513
tags: [.Text]
redirect_from:
  - /blog/archive/2005/01/26/Bringing-.Text-v.96-further.aspx
  - /blog/archive/2005/01/26/513.aspx
---

Almost one year ago [I upgraded my .Text blog to .96](/archive/2004/02/05/updated-to-text-pre-96/). I blogged about it several times, my last post was about adding the rel="nofollow" attribute to links in comments.

Since then I've got several requests how to get the .96 sources and upgrade. One of them was [Dave Burke](http://dbvt.com/blog/). Yesterday he published the [entire upgrade process](http://dbvt.com/blog/archive/2005/01/25/788.aspx). (Thanks, Dave, now I can forward all request to you ;-) ) BTW, he has done [awesome improvements](http://dbvt.com/blog/series/12.aspx) to .Text.

Today, I've got another request by [Dennis van der Stelt](http://bloggingabout.net/dennis/). First, we talked about how I could provide him with my code base. But then I've got another idea. But first some points which lead me to it.

-   Since last summer [Scott](http://scottwater.com/), the creator of .Text, works for [Telligent](http://www.telligentsystems.com/), and now .Text is bundled with [nGallery](http://www.ngallery.org/) and [ASP.NET Forums](http://www.telligentsystems.com/Solutions/Forums/) in [Community Server](http://www.communityserver.org/). They are working on version 1, currently beta 3 is published. I haven't tried CS yet, but I'm not sure whether I like it. I only want a simple blog engine, not a full bloated server.
-   There are many lone warriors like Dave, [Bob Roudebush](http://roudybob.net/), [Chrissy LeMaire](http://www.netnerds.net/), or [Dan Bartel](http://www.danbartels.com/), who have done minor or major tweaks to .Text, such as a [solution against comment spam](http://netnerds.net/archive/2005/01/25/494.aspx) or a [webcam panel](http://roudybob.net/articles/841.aspx).
-   I don't know, how these others handle their .Text engine, but whenever I see an interesting improvement I try to adopt it in my code base. Currently, I'm incorporating Chrissy's anti-spam solution into my blog. I'm a developer and I *love* to code. But I believe there are other bloggers who would like to use all these .Text improvements (at least a newer version of FreeTextBox [like Dan did](http://blog.danbartels.com/articles/266.aspx)), but either don't want to mess with the code, or just don't know what sources are ;-)

Therefore, I thought about bringing the knowledge and dev power together. We could build and publish a new .Text release, .97 or whatever. I hope Scott or some others don't feel offended, because that's not my intention. As I said, I haven't tried CS yet, so I don't know neither how much of .Text is left in CS, what features are already implemented, and how difficult it is to incorporate mentioned "tweaks" into it.

So what do you think about it?

But maybe I'm completely on the wrong track, and Community Server it better than I fear ;-)

