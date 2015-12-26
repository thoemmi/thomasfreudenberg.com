---
layout: post
title: 'Adding new pages to CommunityServer administration'
date: 2005-09-08 13:56:00 +02
comments: true
disqus_identifier: 12484
tags: [Community Server]
redirect_from:
  - /blog/archive/2005/09/09/Adding-new-pages-to-CommunityServer-administration.aspx
---

In an addin I'm writing for CommunityServer I'm using a *job*. A job in the CommunityServer perspective is a task which is executed periodically. Since I have had some trouble with my job, I needed a way to monitor whether my job is executed properly. [Scott Watermasysk](http://scottwater.com/) has [posted a simple ASPX page](http://communityserver.org/forums/470843/ShowPost.aspx#470925) some time ago to get the status of all jobs configured in CS. Since I'm a lazy guy I integrated this code into the CommunityServer administration interface and additionally added a page for displaying the email queue:

![Jobs list](/files/archive/admin-jobs.png) ![Email Queue](/files/archive/admin-EmailQueue.png)

You only have to copy the two ASPX files to */admin/system/tools/* and add them to the */admin/Tab.config*. Additionally, you have to add the following entries to the end of your *resources.xml*, right before the closing *\</root\>* element.

    <resource name="Admin_Jobs_Title">Jobs</resource>

    <resource name="Admin_Jobs_SubTitle">Here you will find a list of all configured jobs.</resource>

    <resource name="Admin_EmailQueue_Title">Email Queue</resource>

    <resource name="Admin_EmailQueue_SubTitle">Here you will find a list of all enqueued emails.</resource>

You can download the ASPX files and the modified *Tab.config* file [here](/files/archive/JobsAndEmailQueue.zip).

