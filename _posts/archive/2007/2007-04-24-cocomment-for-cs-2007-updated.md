---
layout: post
title: 'coComment for CS 2007 updated'
date: 2007-04-24 11:09:00 +02
comments: true
disqus_identifier: 28125
categories: [Community Server, coComment]
redirect_from:
  - /blog/archive/2007/04/24/cocomment-for-cs-2007-updated.aspx/
---

Every day you can learn something new. Today it was [Scott](http://scottwater.com/) who taught me [`ControlAdapter`](http://weblogs.asp.net/scottgu/archive/2005/12/21/433692.aspx)s after he read my post about [coComment with CommunityServer 2007](/archive/2007/04/23/cocomment-support-for-cs-2007/). You know, `ControlAdapter`s are not only good for tweaking CSS.

My original solution was a replacement for the `WeblogPostCommentForm`, i.e. for every blog theme you had to edit its `post.aspx`, register my new control and replace the original control.

ControlAdapters however give you the power to inject your code into any desired existing control. In a central file you specify which controls you want to customize, and that's it. No editing of any pages or controls is required.

So I took the chance and transformed my custom comment form into a ControlAdapter. In fact, it's as easy as writing a control. Here's the simplified code, just in case you're interested:

``` csharp
public class WeblogPostCommentFormAdapter : ControlAdapter
{
    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        WeblogPostCommentForm commentForm = base.Control as WeblogPostCommentForm;
        if (commentForm != null)
        {
            string coCommentScript = GetCoCommentScript(commentForm);
            if (!String.IsNullOrEmpty(coCommentScript))
                CSControlUtility.Instance().RegisterStartupScript(base.Control, 
                    typeof (WeblogPostCommentForm), "cocomment", coCommentScript, false);
        }
    }

    private static string GetCoCommentScript(WeblogPostCommentForm commentForm)
    {
        // just boring stuff which creates the javascript code to make coComment happy
    }
}
```

Just drop the attached assembly to your `~/bin` folder and add following line to the `controlAdapters` section in `~/App\_Browsers/default.browser`:

``` xml
<adapter controlType="CommunityServer.Blogs.Controls.WeblogPostCommentForm"
    adapterType="ThomasFreudenberg.CS2007.WeblogPostCommentFormAdapter, ThomasFreudenberg.CS2007" />
```

That's all, without further editing of any files<sup>1</sup> coComment support is enabled for all blog themes automagically.

<sup>1</sup> unless of course if you're already using the assembly I published yesterday; in this case revert all changes done to your `post.aspx`

