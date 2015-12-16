---
layout: post
title: 'Feature Request for RSS Bandit'
date: 2004-01-22 11:45:00 +01
comments: true
disqus_identifier: 319
categories: [Development]
redirect_from:
  - /blog/archive/2004/01/22/Feature-Request-for-RSS-Bandit.aspx
---

Earlier today [I mentioned](/archive/2004/01/22/new-control-by-tim-dawson-eye-finder/) the [new Eyefinder control](http://www.divil.co.uk/net/controls/eyefinder/) by [Tim Dawson](http://www.divil.co.uk/). I said I would like to see it in [RSS Bandit](http://rssbandit.org). Here's a screenshot of what I have in mind:

![RSS Bandit with EyeFinder](/files/archive/rssbandit+with+eyefinder.jpg)

Ok, I admin this screenshot is faked. First I tried to implement it in RSS Bandit myself, but unfortunately, the sources are messed up (though [it's good to have them](http://www.25hoursaday.com/weblog/PermaLink.aspx?guid=ef582f73-20a2-4c43-b446-4fba3ed02254)) . At least for me I didn't see a chance to install my desired changes. [Dare](http://www.25hoursaday.com/weblog/) and [Torsten](http://www.rendelmann.info/blog/), how about some refactoring? IMHO the aggregation code and the GUI are too merged (Currently the [main window's source file](http://cvs.sourceforge.net/viewcvs.py/rssbandit/CurrentWork/Source/RssBandit/WinGui/Forms/WinGUIMain.cs?view=auto) is about 8100 lines).

Anyway, no offense. This should just give an impetus.

PS: How could Tim conceive to call his new control *EyeFinder*???

