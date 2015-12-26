---
layout: post
title: 'coComment support for CS 2007'
date: 2007-04-23 12:34:00 +02
comments: true
disqus_identifier: 28102
tags: [Community Server, Development, coComment]
redirect_from:
  - /blog/archive/2007/04/23/cocomment-support-for-cs-2007.aspx
---

If you are one of my two regular readers, you may have noticed that I published [many posts](/files/archive/default.bin) regarding [coComment](http://www.cocomment.com/). In fact, I published instructions to integrate coComment in original [CommunityServer](/archive/2006/02/08/revised-cocomment-support/) and [CS2.1SP1](/archive/2006/09/19/updated-cocomment-support-for-community-server-2-1/) (for CS2.0 and CS2.1 [Keyvan](http://nayyeri.net/) was faster than me [:p])

(if you think I write so much about coComment is because I love it so much, you totally missed the point of my blog)

Anyway, if you follow the old instructions you'll see that there's bunch of script code you have to add to your blog theme. Unfortunately, that solution does not work anymore with CS 2007, because the controls in the comment form are wrapped in a new Chameleon control. I did not see a chance to access the ids of the contained controls and continue the old solution with my limited ASP.NET knowledge.

Instead, I developed another solution. I simply inherited a new control from `WeblogPostCommentForm`, where I have all access to the contained elements. And up to now I didn't know how easy it is to [add some script](http://msdn2.microsoft.com/en-us/library/system.web.ui.clientscriptmanager.registerclientscriptblock.aspx) in your code to be added to the rendered HTML

Long story short, here's my solution for coComment support in CS2007:

Drop the attached [`ThomasFreudenberg.CS2007.dll`](/files/archive/ThomasFreudenberg.CS2007.dll) into your `~/bin` folder.

Open `post.aspx` of your desired blog theme

1.  Add following line right after the imports:

    ``` aspx-cs
    <%@ Register TagPrefix="TFr" Namespace="ThomasFreudenberg.CS2007"
        Assembly="ThomasFreudenberg.CS2007" %>
    ```

2.  Replace `<CSBlog:WeblogPostCommentForm>` with `<TFr:WeblogPostCommentForm>`
3.  and `</CSBlog:WeblogPostCommentForm>` with `</TFr:WeblogPostCommentForm>`

In fact, for me as a non-web developer that approach seems much more natural to me than adding fancy instructions in the web control.

