---
layout: post
title: 'SharpReader 0.9.3 published'
date: 2003-11-06 22:17:00 +01
comments: true
disqus_identifier: 260
categories: [Software]
redirect_from:
  - /blog/archive/2003/11/06/260.aspx/
---

[Luke Hutteman](http://www.hutteman.com/) [has released a new version](http://www.hutteman.com/weblog/2003/11/07-137.html) of [SharpReader](http://www.sharpreader.net/):

> SharpReader 0.9.3 is now available for download at [sharpreader.net](http://www.sharpreader.net/).
>
> Changes since the last version are:
>
> -   .NET 1.1 only. Go to [windowsupdate.microsoft.com](http://windowsupdate.microsoft.com/) to upgrade if you currently only have .NET 1.0 installed
> -   Added support for HTTP Authentication (either through a username:pwd@url, or through a popup authentication dialog)
> -   [FeedValidator.org](http://feedvalidator.org/) url change
> -   Multi-select enabled in headline-view
> -   Handle feed:// protocol. Links to a feed:rss-url will automatically open in SharpReader. For example <feed:www.hutteman.com/weblog/rss.xml> would open my rss-feed in SharpReader.
> -   Updated to use log4j 1.2.0 beta 8 - this build no longer has the Win98/WinME bug
> -   Improved performance of opening new browser windows for users with IE as their default browser.
> -   Support for the [\<wfw:commentrss\>](http://www.sellsbrothers.com/spout/#exposingRssComments) element.
>     -   Comments are retrieved on demand and are cached across sessions.
>     -   If both \<wfw:commentrss\> and \<slash:comments\> tags are present, SharpReader changes the comment-count displayed when you delete comments, and also displays the number of unread items.
>     -   For items no longer in the rss-feed, a "+" is displayed after the comment-count to indicate more comments could have been added since the item disappeared from the feed.
> -   Fixed bug that sometimes caused an InvalidOperationException (Collection was modified) to occur.
> -   Save subscriptions right away when new feed is added.
> -   Load subscriptions.xml even if there was a problem loading settings.xml (previously you would lose all your subscriptions if this happened).
> -   Added feed-property to specify whether to automatically open the links belonging to an item. Property can be set to "always", "never", or "only if no description is present".
> -   "Copy IE Proxy Settings on SharpReader startup" option on the proxy-tab.
> -   Bypass proxy for local URLs
> -   Systray popup when new items arrive (can be disabled on a per-feed or per-category basis through the properties pane)
> -   Memory consumption has been reduced by approximately 25%. Startup performance has also been improved.

Yes, the memory consumption is better now, but still high. However, what I really like is the that the option to open links *always*, *never*, and *only if no description is present* is per feed. Some feeds do contain only a few lines of the entire posting, so for these I set the option to *always*. I really like that.

And finally it provides toasts...

Though I like the UI of [FeedDemon](http://www.bradsoft.com/feeddemon/index.asp) much more, I think I'm going back to SharpReader. Maybe Luke will publish the source code some time ![Blushing](/files/archive/smiley_redface.gif)

