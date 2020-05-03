---
layout: post
title: 'My Journey to Pretzel: Preface'
comments: true
disqus_identifier: http://thomasfreudenberg.com/archive/2015/12/30/journey_to_pretzel/
tags: [Pretzel, .Text, Community Server]
---

After running my site for more than 12 years, I decided it was time to replace the
software behind it with something new.

I started this blog with **.Text** in August of 2002, which later was merged into
**CommunityServer**. I wrote many extensions for CS, customized it in many ways,
and was active in the community. [Telligent](http://telligent.com/), the company
behind CommunityServer, even awarded me with a MVP status.

However, I lost interest in CS after a while. I started writing my own blog engine
(as most developers do I guess). Well, not only once but countless times. Every
few months I threw away the current code and started again from scratch. I took
the opportunity to play around with the newest stuff, [ASP.NET MVC](http://www.asp.net/mvc)
and [Nancy](http://nancyfx.org/), [Entity Framework](http://www.asp.net/entity-framework)
or [RavenDb](http://ravendb.net/), n-tier architecture or
[CQRS](http://codebetter.com/gregyoung/2010/02/16/cqrs-task-based-uis-event-sourcing-agh/).

Well, though I learnt a lot about the different technologies, libraries etc, I never
got to the point where my software was ready to be published.

Finally I decided to overcome my developer ego and use some existing software. A few
month ago I switched to [Jekyll](http://jekyllrb.com/), a static site generator written
in Ruby. Some weeks later I switched again, this time to [Pretzel](https://github.com/Code52/pretzel),
which is very similar to Jekyll but written in .NET.

After writing this introduction, I intend to publish a couple of posts about the different
stations of my journey to Pretzel in the next few weeks. E.g. I wrote several extensions
for Pretzel, and I configured Azure for auto-deployment whenever I push to the
[git repository of this site](https://github.com/thoemmi/thomasfreudenberg.com).
