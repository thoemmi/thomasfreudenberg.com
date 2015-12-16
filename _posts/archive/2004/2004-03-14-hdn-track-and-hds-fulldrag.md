---
layout: post
title: 'HDN_TRACK and HDS_FULLDRAG'
date: 2004-03-14 05:14:00 +01
comments: true
disqus_identifier: 352
categories: [Development]
keywords: [listview, HDN_BEGINTRACK, HDN_TRACK, HDN_ENDTRACK, HDS_FULLDRAG]
redirect_from:
  - /blog/archive/2004/03/14/HDN_TRACK.aspx
  - /blog/archive/2004/03/14/352.aspx
---

I'm posting this, because it took me two hours to find the issue.

I wanted to customize a listview's header control, i.e. changing its behavior when the user resizes a column. According to the MSDN documentation, the header sends following notifications:

-   [`HDN_BEGINTRACK`](http://msdn.microsoft.com/library/en-us/shellcc/platform/commctls/header/notifications/hdn_begintrack.asp) when the user starts dragging a divider,
-   [`HDN_TRACK`](http://msdn.microsoft.com/library/en-us/shellcc/platform/commctls/header/notifications/hdn_track.asp) while dragging, and
-   [`HDN_ENDTRACK`](http://msdn.microsoft.com/library/en-us/shellcc/platform/commctls/header/notifications/hdn_endtrack.asp) when the user has finished dragging the divider.

I've had no problem getting `HDN_BEGINTRACK` and `HDN_ENDTRACK`. Unfortunately, I didn't receive the `HDN_TRACK` notification.

I've found many examples in the internet, which, instead of `HDN_TRACK`, intercepted the [`HDN_ITEMCHANGING`](http://msdn.microsoft.com/library/en-us/shellcc/platform/commctls/header/notifications/hdn_itemchanging.asp) notification. Well, after some more research, I've found a hint to the header control's style [`HDS_FULLDRAG`](http://msdn.microsoft.com/library/en-us/shellcc/platform/commctls/header/styles.asp), which causes the control to render its content while being resized. If this style is set, **no `HDN_TRACK` notifications are sent**. And the [`System.Windows.Forms.ListView`](http://msdn.microsoft.com/library/en-us/cpref/html/frlrfsystemwindowsformslistviewclasstopic.asp)'s header has this style by default. That's ok, but what's not ok is that nowhere in the MSDN the relation between `HDN_TRACK` and `HDS_FULLDRAG` is documented.

I hope that if someone stumbles over this issue, Google will refer him to here. It would save him some time.

**Update:** I've got a request from [Martin Welker](http://www.martinwelker.com), who asked how to remove `HDS_FULLDRAG`. I've found the article [INFO: HDN\_TRACK Notifications and Full Window Drag Style](http://support.microsoft.com/default.aspx?scid=kb;en-us;183258) in the Microsoft Knowledge Base:

> **SUMMARY**
> Starting with version 4.70 of ComCtl32.dll, the header control of a list view control in report view (LVS\_REPORT) automatically receives the HDS\_FULLDRAG style. When this style is set, the parent of a list view control receives HDN\_ITEMCHANGING notifications, rather than HDN\_TRACK notifications, when the column divider of the header control is dragged. To receive HDN\_TRACK notifications, the header control of the list view control must not have the HDS\_FULLDRAG style set. Note that the HDS\_FULLDRAG style is ignored in versions of ComCtl32.dll prior to 4.70.

This article also includes some sample code how to remove the `HDS_FULLDRAG` style flag.