---
layout: post
title: 'Upgraded to Community Server 2.1 beta 1'
date: 2006-07-21 18:25:00 +02
comments: true
disqus_identifier: 16866
tags: [Site news, Community Server]
redirect_from:
  - /blog/archive/2006/07/22/Upgraded-to-Community-Server-2.1-beta-1.aspx
---

Finally I managed to update my site. I already missed the last major step from 1.1 to 2.1. However, during the last few weeks the number of spams increased daily. Because CS 2.0 introduced a spam checker, I decided to bite the bullet. Of course I took the harder route: Not only updating from CS 1.1 to CS 2.1 beta 1, but from .NET 1.1 to 2.0 as well. Surprisingly it went smoother than expected:

1.  Shutting down my site. ASP.NET 2.0 introduced a new feature: if you put a file named `App_Offline.htm` in the root of a web application, ASP.NET will shutdown that application and just send back the content of this file to every request for dynamic pages. ([More](http://weblogs.asp.net/scottgu/archive/2005/10/06/426755.aspx) [details](http://weblogs.asp.net/scottgu/archive/2006/04/09/442332.aspx) by ScottGu)
2.  Upgrading the database: first I applied `CS_1.1_to_2.0_upgrade.sql` from the CS 2.0 distribution, then `cs_2.0_to_2.1Beta1_upgrade.sql`, and finally `cs_ASPNET2_Membership_Schema_Update.sql` because of the migration to .NET 2.0.
3.  Uploading all the files for CS2.1b1. Quite time consuming because I took the chance to clean up my web space.
4.  Fixing my post names. Even more time consuming. I used to give my post descriptive names, which [was not well supported](/archive/2005/10/02/using-hyphens-in-post-names/) by CS in the past. However, they fixed it, but now all URL of my posts are broken. That's because CS now encodes the post name, and [all hyphens were converted to `_2D00_`](http://communityserver.org/forums/thread/538926.aspx). So I went through all my posts and fixed their names. (that's the first time I'm glad that I'm not posting so much [;)])
5.  Finally I deleted `App_Offline.htm` again and reviewed all settings in the control panel.

So everything went pretty well. However, the site is not skinned yet. But I refrain from going to the time and effort of creating a decent design until CS2.1 is released. Instead, I'll invest some of my spare time in some **CSModules**.