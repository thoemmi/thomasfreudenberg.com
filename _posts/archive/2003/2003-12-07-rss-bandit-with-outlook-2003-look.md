---
layout: post
title: 'RSS Bandit with Outlook 2003 look'
date: 2003-12-07 20:55:00 +01
comments: true
disqus_identifier: 288
categories: [Development, Software]
redirect_from:
  - /blog/archive/2003/12/08/RSS-Bandit-with-Outlook-2003-look.aspx/
---

[RSS Bandit](http://www.rssbandit.org/) is getting [better](http://www.rendelmann.info/blog/Trackback.aspx?guid=1782d30f-3725-45c3-9b74-d1a7b81f3cf9) and [better](http://www.25hoursaday.com/weblog/PermaLink.aspx?guid=690c21aa-205d-4a08-b38c-8c0321013fbc). I'm really thinking about switching from [SharpReader](http://www.sharpreader.net/), but it doesn't feel *right* at the moment. ![Wink](/files/archive/smiley_wink.gif)

Anyway, contrary to SharpReader, you can get the [bandit's source code](http://www.gotdotnet.com/Community/Workspaces/workspace.aspx?id=cb8d3173-9f65-46fe-bf17-122e3703bb00). Because I really like the UI of [Outlook 2003](http://www.microsoft.com/outlook) (and [FeedDemon](http://www.bradsoft.com/feeddemon/)), I patched RSS Bandit:

![RSS Bandit w/ Oulook 2003 look](/files/archive/RssBandit2003.PNG)

It took about 15 minutes. Mainly I docked the feed item list and the splitter to the left. Additionally, I've created a custom feed item formatter, which bases on [Julien Cheyssial](http://dotnetjunkies.com/weblog/jcheyssial/)'s [MyBlogroll](http://www.myblogroll.com/) template. You can download my XSLT file ~~here~~.

**Update:** I've changed the ~~XSLT~~ to show the author, if available.

**Update:** Meanwhile the Outlook formatter is part of RSS Bandit so don't ask me anymore for the XSLT file. I removed the link.