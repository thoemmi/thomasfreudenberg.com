---
layout: post
title: 'No comments possible'
date: 2004-04-01 02:59:00 +02
comments: true
disqus_identifier: 364
categories: [Site news, .Text]
redirect_from:
  - /blog/archive/2004/04/01/CommentsBroken.aspx
---

Currently it's not possible to post comments on my blog. I'm still investigating this issue. I have a copy of all files and the database running at home, but I cannot reproduce this error. Somehow the files are rendered differently on my [WebHost4Life hosted](http://www.webhost4life.com/default.asp?refid=Thoemmi) blog, i.e. the form's `onsubmit` is rendered as `"if (!ValidatorOnSubmit()) return false;"` while everywhere else it is just `"ValidatorOnSubmit();"`. Any help is welcome.

*(Also [posted on the .Text forum](http://www.asp.net/Forums/ShowPost.aspx?tabindex=1&PostID=522467))*

