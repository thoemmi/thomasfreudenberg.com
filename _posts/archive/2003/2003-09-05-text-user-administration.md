---
layout: post
title: '.Text User Administration'
date: 2003-09-05 21:54:00 +02
comments: true
disqus_identifier: 165
tags: [.Text]
redirect_from:
  - /blog/archive/2003/09/05/165.aspx
---

.Text is a great product. However, currently there's no comfortable way to administrate the users, but you have to [edit and execute a SQL script](http://scottwater.com/dottext/posts/9253.aspx). I don't know how [Scott](http://scottwater.com/blog/) can manage all these 259 blogs at [weblogs @ asp.net](http://weblogs.asp.net/).

Since I am going to set-up an internal .Text installation in my company with about 20 bloggers (hopefully), I was thinking about an easier way. I don't want to see 20 work-mates standing in front of me to set-up their blog...

Therefore, I've started to implement an on-line user administration. Here's what it currently looks like:

![.Text User Administration](/files/archive/edit_user.png)

It just creates and updates users in the database. Some more things have to be done: For non-virtual set-ups it has to create the appropriate folder and the dummy `default.txt` file in it, but that's not implemented yet. Additionally, in the user database (i.e. `blog\_Config`) a flag has to be added for each user, whether he is allowed to administrate the users.

I would like to know, if anyone else (esp. Scott) is interested in that? Any comments are welcome.

