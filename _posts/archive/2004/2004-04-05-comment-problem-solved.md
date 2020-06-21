---
layout: post
title: 'Comment Problem Solved'
date: 2004-04-05 04:43:00 +02
comments: true
disqus_identifier: 367
tags: [Site news]
redirect_from:
  - /blog/archive/2004/04/05/CommentProblemSolved.aspx
  - /blog/archive/2004/04/05/367.aspx
---

As [I posted](/archive/2004/04/01/no-comments-possible/), no postbacks on my site were possible. Though I'm running the same application at home and on my site, the `onsubmit` tag was rendered differently. At home I get

``` aspnet
<form name="Form1" method="post" action="CommentsBroken.aspx"
    language="javascript" onsubmit="ValidatorOnSubmit();" id="Form1">
```

while [my public blog](/) is rendered

``` aspnet
<form name="Form1" method="post" action="CommentsBroken.aspx"
    language="javascript"
    onsubmit="if (DefaultButton_RequireOwnPostback(this) ) { return false; }; if (!ValidatorOnSubmit()) return false;"
    id="Form1">
```

Notice that the result of `ValidatorOnSubmit` is analysed.

Well, I've [found](http://www.asp.net/Forums/ShowPost.aspx?tabindex=1&PostID=494822) [some](http://www.asp.net/Forums/ShowPost.aspx?tabindex=1&PostID=485895) [hints](http://www.asp.net/Forums/ShowPost.aspx?tabindex=1&PostID=482721) [in](http://www.asp.net/Forums/ShowPost.aspx?tabindex=1&PostID=370419) the [ASP.NET forum](http://www.asp.net/Forums/). This issue seems to be caused by an ASP.NET hotfix as described on [KB 818803](http://support.microsoft.com/default.aspx?scid=kb;en-us;818803).

Ok, how did I solve this issue? I've just edited my [WebUIValidation.js](view-source:http://thomasfreudenberg.com/aspnet_client/system_web/1_1_4322/WebUIValidation.js), more precisely, I added the line `return true;` to `ValidatorCommonOnSubmit`:

``` javascript
function ValidatorCommonOnSubmit() {
    event.returnValue = !Page_BlockSubmit;
    Page_BlockSubmit = false;
    return true;
}
```

Now comments are possible again and I'm happy.
