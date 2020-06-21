---
layout: post
title: 'Whidbey is soooo cool...'
date: 2003-11-17 05:09:00 +01
comments: true
disqus_identifier: 278
tags: [Development, Whidbey]
redirect_from:
  - /blog/archive/2003/11/17/Whidbey-is-soooo-cool_2E002E002E00_.aspx
  - /blog/archive/2003/11/17/278.aspx
---

... but I have to switch back to .NET 1.1 because of [this ~~bug~~ issue](http://staff.newtelligence.net/clemensv/PermaLink.aspx?guid=3fc6b7ee-e292-4fd0-aa22-c95aa2dba9fc):

![VSCorePackage](/files/archive/VSCorePackage.png)

I've already written about 2k lines, but this issue bars me from doing any UI development ![Dead](/files/archive/smiley_dead.gif) Additionally, I don't want to wait another year before releasing this project.

However, while porting back, I've noticed how much Whidbey will easen the developer's life:

- Anonymous delegates make your source code much clearer.
- Generics allow you do write more, well, generic code.
- `System.Xml.XmlTextWriter`/`Reader` 2.0 implement `IDisposable`.

.NET 1.1 is so... *yesterday*.

**Update:** I'm missing the `System.Windows.Form.WebBrowser` control, too.
