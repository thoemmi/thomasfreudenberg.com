---
layout: post
title: 'Naming Events in .NET'
comments: true
tags: [.NET]
disqus_identifier: http://thomasfreudenberg.com/archive/2016/06/29/naming-events-in-dotnet/
keywords: [.NET Core, .NET Framework, Naming, Guideline, Events]
date: 2016-07-01
last_modified_at: 2016-12-29
---

**Update 2016/12/29**: I've complained about the `On` prefix in the [comment section](https://docs.microsoft.com/en-us/dotnet/articles/csharp/events-overview#comments-container)
of the documentation (and [Jonas Gauffin](http://blog.gauffin.org/) too). In fact the prefix was a mistake and
is [fixed](https://github.com/dotnet/docs/pull/1012) by now.

<hr>

Things are changing in the .NET world. A couple of days ago Microsoft released
[.NET Core 1.0](https://blogs.msdn.microsoft.com/dotnet/2016/06/27/announcing-net-core-1-0/),
the new cross-platform, open source, and modular .NET platform.

Unfortunately, not only the managed framework's changing, but naming guidelines
too.

Lets start with the old .NET framework. Microsoft says in the
[Naming Guideline for Events](https://msdn.microsoft.com/en-us/library/ms229012.aspx#Anchor_2):

> **✓ DO** name events with a verb or a verb phrase.
>
> Examples include `Clicked`, `Painting`, `DroppedDown`, and so on.
>
> **✓ DO** give events names with a concept of before and after, using the present
> and past tenses.
>
> For example, a close event that is raised before a window is closed would be
> called `Closing`, and one that is raised after the window is closed would be
> called `Closed`.

The (slightly outdated) [Event Naming Guidelines for .NET Framework 1.1](https://msdn.microsoft.com/en-us/library/h0eyck3s(VS.71).aspx)
even says more explicitly:

> * Do not use a prefix or suffix on the event declaration on the type. For
>   example, use `Close` instead of `OnClose`.

That's what we've been taught for the last 15 years: Events are named without
a prefix.

Let's repeat: Events are named without a prefix.

## Entry .NET Core!

[Robin Müller](https://github.com/MrRoundRobin), maintainer of the [telegram.bot](https://github.com/MrRoundRobin/telegram.bot)
library, changed the names of all event from an unprefixed name to prefixed with `On`
in a [recent commit](https://github.com/MrRoundRobin/telegram.bot/commit/54860e7048c2a0b76a206739d1bc1a2795e31199).
I complained that this renaming would contradict the guidelines recommendations by Microsoft
and what we've learnt the last 15 years.

However, Robin pointed me to the [new guidelines](https://docs.microsoft.com/en-us/dotnet/articles/csharp/events-overview#language-support-for-events)
(emphasis mine):

> There are a number of conventions that you should follow when declaring an event.
> Typically, the event delegate type has a void return. **Prefix event declarations
> with 'On'.** The remainder of the name is a verb.

WTF? Do we have to forget the old habits and rename all events when moving from good ol'
.NET Framework to .NET Core?

The new guidelines include a comment section at the bottom where I asked for the rational
behind the changed guideline a few days ago, but I still got no answer. I'd really like to
now...

**Sidenote:** Most of us are used to name the **handler** for an event
`On<name of the event>`, e.g.

```c#
foo.SomethingHappened += OnSomethingHappened;
```

What should we call those event handlers now? `OnOnSomethingHappened`?
