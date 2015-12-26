---
layout: post
title: 'Another .Text enhancement'
date: 2003-09-19 07:53:00 +02
comments: true
disqus_identifier: 203
tags: [.Text]
redirect_from:
  - /blog/archive/2003/09/19/Another-.Text-enhancement.aspx
  - /blog/archive/2003/09/19/203.aspx
---

I'm using the [.Text](http://scottwater.com/dottext/) web administrator for writing my postings. Unfortunately, there's no link provided to get from the administrator section to the public view. Either you have to edit the address line, click on a favourite link, or logout. Neither of them is very comfortable. I admit I never log out ![Blushing](/files/archive/smiley_redface.gif).

Therefore, once again I patched .Text and added another link to the header of the administrator section:

![.Text administration with Home link](/files/archive/Text.Home.png)

I've simply added

``` xml
| <a href="<%= dottext.framework.config.instance(context).fullyqualifiedurl="" %>">Home</a>
```

to the start of line 19 in `\admin\Resources\PageTemplate.ascx`. This link directs you to the homepage of your blog (in my case [http://ThomasFreudenberg.com/blog/](/))

I can think of others who are missing this too. [Scott](http://scottwater.com/), how about adding this to the official .Text distribution?

 

**Update:** ![Doh](/files/archive/smiley_doh.gif) Do you see the "Thoemmi.NET" text? In fact, that's the link back to the main page. I didn't notice that. Thanks to [Scott](http://scottwater.com/), Bryant Likes, and [Shannon J Hager](http://www.hdconsultants.us/) for opening my eyes.

