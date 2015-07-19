---
layout: post
title: 'ScottW on Service Based Aggregator'
date: 2003-09-22 06:19:00 +02
comments: true
disqus_identifier: 208
categories: [Development]
redirect_from:
  - /blog/archive/2003/09/22/208.aspx/
---

[ScottW](http://scottwater.com/) [talks about a Service Based Aggregator](http://scottwater.com/blog/posts/9981.aspx):

> *For a new little project, I needed to create a simple windows service that aggregated a set of feeds. Part two was wiring up this data to a winform app. Along the way, it got me to thinking that this might be an interesting way to create an aggregator. Some service/site runs in the background processing the data. When you need it, fire up your application (Winform/Site/Etc).  The other really cool thing is that now all of this great data is just sitting there waiting to be used and reused.*

I really like that idea for three reasons:

1.  Many GUI aggregators have a horrible start-up time (Precisely, I am using [SharpReader](http://www.sharpreader.net/) and [RSS Bandit](http://www.rssbandit.org)). When they start, they read your local list of aggregated sites, contact each to get new items/updates, and finally presents the results to you.
    A service based aggregator would do this all the time, beginning from the start-up of your system. To access the feeds, you would just start the proper WinForm application (or even ASP.NET based UI) which gets all the information pre-processed from the already running local service.
2.  You can think of a mobile solution. I for example am reading blogs both at home and at work, which has two draw-backs. First, I have to keep the OPML synchronized, and second, all the blogs I've read at work are still marked unread at home. Using a WinForm application connecting to the aggregator service on my home machine, my UI is always in sync, because it's just a user layer accessing the same aggregator.
3.  I have subscribed some RSS feeds from [phpbb](http://www.phpbb.com/)-driven boards listing the last 20 active threads. On busy days, I regularly miss some items, because my aggregator is not running all the time (There are times when I'm logged off). A aggregator service running on my server at home would aggregate all sites independant from whether I'm logged in or not.

All this told, I think it's a great idea to separate the aggregator logic from the user representation.

BTW, this approach helps both GUI developers to write their own WinForm app without struggling with the RSS processing, and 'other' developers with no sense for UI design. ![Smiley](/files/archive/smiley_smile.gif)

