---
layout: post
title: 'Twitter Publisher for CruiseControl.NET'
date: 2007-06-17 12:09:00 +02
comments: true
disqus_identifier: 31811
categories: [Development, ccnet, Twitter]
redirect_from:
  - /blog/archive/2007/06/17/twitter-publisher-for-cruisecontrol-net.aspx/
---

Some weeks ago [I posted a CC.NET](/archive/2007/04/29/blog-publisher-for-cruisecontrol-net/) task which pushes build results to a blog using the MetaWeblogAPI. This might be a feasable solution for projects which sources aren´t updated that often. Otherwise that blog would be really cluttered, and you won´t be able to keep track of all the build results.

Several month ago a new social networking site started called [Twitter](http://twitter.com/ "Twitter"). It offers a kind of micro-blogging service, allowing its users to send text-only status, up to 140 characters long. Whenever you update your status, it is delivered instantly to other users who have put you to their "friends" list. Though you can receive the updates of your friends via an RSS feed, it is more common to either use Twitter´s website or a desktop client such as [TeleTwitter](http://www.teletwitter.com/). Additionally, Twitter offers a [RESTful](http://en.wikipedia.org/wiki/RESTful) API.

Therefore it was pretty obvious to write a CC.NET task which announces new build results on Twitter. The project manager creates a special Twitter account and configures CC.NET to post build results as updates for that user. The developers then just have to add that user to their friend list, and will get the announcements in the Twitter front-end of their choice.

The [attached ZIP file](/files/archive/ccnet.TwitterPublisher.plugin.zip) contains both the sources and the compiled assembly, which you have to dump into CC.NET´s `server` directory. The configuration of the task is pretty easy, just specify the user and the password of the Twitter account.

``` xml
<publishers>
    ...
    <twitter>
        <user>username</user>
        <password>password</password>
    </twitter>
    ...
```

