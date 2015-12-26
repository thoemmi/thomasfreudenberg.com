---
layout: post
title: 'The Akismet Spam Rule included in Alabaster'
date: 2006-08-22 12:57:00 +02
comments: true
disqus_identifier: 17598
tags: [Community Server, Akismet, CSMVPs]
redirect_from:
  - /blog/archive/2006/08/22/The-Akismet-Spam-Rule-included-in-Alabaster.aspx
---

Though I spoke about my Akismet spam rule [a couple of weeks ago](/archive/2006/07/21/whats-next/), I didn't draw that much attention to it. However, now that the first version of CSMVP's CSModules package, code name [Alabaster](http://csmvps.com/blogs/news/archive/2006/08/14/Community-Server-MVP_2700_s-Alabaster-CSModule-Package.aspx), is released for more than a week, I'd like to spent some words on it, though Jayson mentioned it in his [CS Tidbits: Exploring The CS Spam Blocker](http://jaysonknight.com/blog/archive/2006/08/20/CS-Tidbits-_2300_21_3A00_-Exploring-The-CS-Spam-Blocker.aspx).

[Akismet](http://akismet.com/) provides a web service, which evaluates a comment or trackback based on several tests and returns a thumb up or thumb down. (Additionally, it can be trained, but that's not supported by my spam rule.)

The spam rule I wrote and contributed to Alabaster calls this Akismet web service. The implementation is straight forward, for a general spam rule implementation see [Jose Lema's instructions on the CS Forum](http://communityserver.org/forums/permalink/526847/526847/ShowThread.aspx#526847). Well, there some tips missing, but [Keyvan](http://nayyeri.net/) forwarded me an advice from Jose: if you use a web service in a spam rule, make that external call only if absolutely necessary. If the "cheaper" spam rules such as link count already identifies a comment as spam, an "expensive" call to an external service would be redundant.

The spam rule engine in Community Server evaluates comments three-stage. In the implementation of your spam rule you can specify at which stage your rule should be visited. Additionally, you can restrict your rule based on the result of previously visited spam rules. In the case of the Akismet spam rule, I specified that the rule should be visited in the third stage, and only if the comment is not considered spam yet:

``` c#
/// <summary>
/// Gets the pass criteria.
/// </summary>
/// <value>The pass criteria.</value>
public override PassCriteria PassCriteria
{
    get { return PassCriteria.ThirdPass; }
}

/// <summary>
/// Gets the status criteria.
/// </summary>
/// <value>The status criteria.</value>
public override StatusCriteria StatusCriteria
{
    get { return StatusCriteria.NotSpam; }
}
```

Ok, enough about the implementation. The installation is pretty easy. Contrary to CSModules, spam rules do not need to be registered in any `.config` files. Instead, the spam rule engine finds all rules via reflection on all assemblies in CS' `bin` folder.

For the configuration, first of all you need a WordPress API key, because Akismet requires it. Though you can [get a key for free](http://wordpress.com/api-keys/), the Akismet is free only for [personal use](http://akismet.com/personal/). If you are a commercial entity or making more than $500 from your personal blog, you need a [commercial key](http://akismet.com/commercial/).

![Akismet configuration](/files/archive/akismet.png)

Pretending you have your API key now, go to *Control Panel* -\> *Administration* -\> *System Tools* -\> *Manage Spam Blocker* (`~/ControlPanel/Tools/ManageSpamRules.aspx`). Tick the *Akismet.com* spam rule and click on **Configure**. In the configuration window enter your API key and your desired points for detected spam (I chose 5, so it gets moderated automatically. I trust Akismet [;)]). Click **Save** to close the configuration window and again **Save** to accept the selected spam rules.