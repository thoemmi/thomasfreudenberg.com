---
layout: post
title: 'What''s next'
date: 2006-07-21 19:06:00 +02
comments: true
disqus_identifier: 16868
tags: [Community Server, Development, coComment, Akismet]
redirect_from:
  - /blog/archive/2006/07/22/Whats-next.aspx
---

![](/files/archive/akismet.png)As mentioned in my [last post](/archive/2006/07/21/upgraded-to-community-server-2-1-beta-1/), I'm working on several extensions for Community Server 2.1. I used to use the [Intensive.CodeHighlighter library](http://communityserver.org/files/folders/add-ons/entry499284.aspx) by [Gary McPherson](http://intensivedesign.co.uk/), but I could not find any updated version. Therefore I "re-engineered" a .NET 2.0 version and improved its configuration handling. No custom `configSection` is required anymore.

Secondly, I was working on a solution for enabling [coComment](http://www.cocomment.com/) in CS2.x. [Scott Elkin](http://www.scottelkin.com) asked my two days ago for some hints because the coComment support in CS 2.x was broken if you give our posts names. However, after I found out about the `BlogThreadQuery`, I saw that Keyvan Nayyeri already [published the same instructions](http://nayyeri.net/archive/2006/07/21/Adding-CoComment-support-to-Community-Server-2.1.aspx) I was preparing.

Anyway, what's already running on this site is my custom spam rule using [Akismet](http://akismet.com/). You can see the module's settings to the right. I'd really like to see it in action, but up to now there was no spam knocking on my door. But I'm convinced that it will take only a couple of hours until the first spam will be rejected. As soon as I'm sure of its effectiveness I'll publish it.