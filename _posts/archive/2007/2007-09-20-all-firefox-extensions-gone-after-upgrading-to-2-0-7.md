---
layout: post
title: 'All Firefox Extensions Gone after upgrading to 2.0.7'
date: 2007-09-20 11:09:00 +02
comments: true
disqus_identifier: 40563
tags: [Software, Tips 'n Tricks, Firefox]
redirect_from:
  - /blog/archive/2007/09/20/all-firefox-extensions-gone-after-upgrading-to-2-0-7.aspx
---

![Firefox](/files/archive/firefox_logo.png){: .align-right}

Today I upgraded Firefox to 2.0.7, which [fixes a flaw in the QuickTime plugin](http://www.mozilla.org/security/announce/2007/mfsa2007-28.html). However, after the upgrade **Firefox didn't load any of the extensions** I have installed

Fortunately I found [this thread](http://forums.mozillazine.org/viewtopic.php?t=586691&sid=38821ef113f1c7b841643b0101e6f1e6) in the support forum. Simply delete *extensions.ini*, *extensions.cache*, and *extensions.rdf* from [your profile folder](http://kb.mozillazine.org/Profile_folder_-_Firefox#Finding_the_profile_folder). On its next start Firefox will scan for installed extensions and regenerate these files.

I hope this post will be indexed properly so you can find this information faster than me.
