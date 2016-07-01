---
layout: post
title: 'How to add GeoTags to your blog'
date: 2004-01-08 19:50:00 +01
comments: true
disqus_identifier: 305
tags: [Site news, .Text]
redirect_from:
  - /blog/archive/2004/01/09/How-to-add-GeoTags-to-your-blog.aspx
  - /blog/archive/2004/01/09/305.aspx
---

Someone [asked](http://www.asp.net/Forums/ShowPost.aspx?tabindex=1&PostID=438059) in the [.Text forum](http://www.asp.net/Forums/ShowForum.aspx?tabindex=1&ForumID=149) how to add [GeoTags](http://www.geourl.com/) to your blog. Well, since version .95 .Text uses a masterpage, which is declared in `DottextWeb/DTP.aspx`. In its header section I've added my GeoTags as follows (my changes in **bold**):

``` aspnet
<%@ Page language="c#" Codebehind="DTP.aspx.cs" AutoEventWireup="false"
    Inherits="Dottext.Web.UI.Pages.DottextMasterPage" %>
<%@ Register TagPrefix="DT" Namespace="Dottext.Web.UI.WebControls" Assembly="Dottext.Web" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
        <title ID="pageTitle" Runat="server">
        **<meta content=".Text" name="GENERATOR">**
        <link id="MainStyle" type="text/css" rel="stylesheet" runat="Server"/>
        <link id="SecondaryCss" type="text/css" rel="stylesheet" runat="Server"/>
        <link id="RSSLink" title="RSS" type="application/rss+xml" rel="alternate" runat="Server"/>
        <meta name="ICBM" content="50.82333, 6.12417">
        <meta name="DC.title" content="Weblogs @ ThomasFreudenberg.com">
        <meta name="geo.position" content="50.8233;6.1242">
        <meta name="geo.region" content="DE">
        <meta name="geo.placename" content="Würselen">
        <meta name="author" content="Thomas Freudenberg"
```