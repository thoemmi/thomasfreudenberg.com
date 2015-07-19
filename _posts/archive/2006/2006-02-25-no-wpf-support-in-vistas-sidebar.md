---
layout: post
title: 'No WPF support in Vista''s Sidebar'
date: 2006-02-25 18:24:00 +01
comments: true
disqus_identifier: 14114
categories: [Development, Windows Vista]
redirect_from:
  - /blog/archive/2006/02/26/No-WPF-support-in-Vistas-Sidebar.aspx/
---

![Sidebar](/files/archive/sidebar2.png)

Two days ago I've installed the new Windows Vista CTP February 2006. I'm excited that the sidebar found its way back, though it took it me some time to [find it](http://microsoftgadgets.com/Sidebar/DevelopmentOverview.aspx#gadgetCreation):

> Click the Start button, then click on All Programs. The Windows Sidebar can be found under the “Accessories” folder.

But as much as I like its return, there's one big bummer: In contrast to [my previous assumption](/archive/2005/09/14/the-return-of-the-sidebar/), the sidebar does not support XAML gadgets. Yes, only DHTML gagdets are possible. I read the [Development Overview](http://microsoftgadgets.com/Sidebar/DevelopmentOverview.aspx) and the [Object Model](http://microsoftgadgets.com/Build/Sidebar%20Reference%20Guide%20February%20CTP.doc) , but no hint how to develop WPF gadgets. Then I found [following post](http://microsoftgadgets.com/forums/3125/ShowPost.aspx#3215) by [Bruce Williams](http://microsoftgadgets.com/People/2286) in the Microsoft Gadgets Forum:

> Actually, what we want the press to say is "Vista looks amazing!  The sidebar is beautiful!  The gadgets are cool, useful, and easy to make."  With DHTML gadgets, we could make the Vista schedule, and accomplish that goal.  Trying to get WPF gadgets in would have put the entire sidebar at risk for Vista, since our team is pretty small and it would have taken resources off of our DHTML efforts.
>
> Having said that - we love WPF. We looked very seriously at adding WPF support; we did some prototyping and other investigations. Maybe we could have done it; but given the time frame it was just too risky, and a little too architecturally-rushed, for us to be comfortable attempting it for Vista. I will be personally disappointed if the next version of the sidebar after Vista doesn't include gadgets whose manifests read \<type\>WPF\</type\>.

Though I understand the point, I'm still disappointed. I've had several ideas for sidebar gadgets, but all of them require more than what can be achieved with DHTML.

 

