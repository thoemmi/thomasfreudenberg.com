---
layout: post
title: 'Add rel=&quot;nofollow&quot; to .Text comments'
date: 2005-01-19 08:15:00 +01
comments: true
disqus_identifier: 486
tags: [Internet, .Text]
redirect_from:
  - /blog/archive/2005/01/19/Add-rel_3D002200_nofollow_2200_-to-.Text-comments.aspx
  - /blog/archive/2005/01/19/486.aspx
---

Today [Google](http://www.google.com/googleblog/2005/01/preventing-comment-spam.html), [Yahoo](http://www.ysearchblog.com/archives/000069.html), [MSN Search](http://blogs.msdn.com/msnsearch/archive/2005/01/18/nofollow_tags.aspx), and other search operators announced their support of the `rel="nofollow"` attribute for `<a href="..." />` tags. Adding this attribute indicates the search crawlers, that the specific links should not contribute to the linked site's page rank. This [might](http://www.intertwingly.net/blog/2003/11/17/Comment-Throttle#c1069204247) help fighting comment spam, since overwhelming blogs with comments containing links to any pharmaceutical site won't increase their search rank.

Whether this will help to fight comment spam or not, time will show. Anyway, I've written a small plug-in for .Text, which adds the mentioned attribute to all links in comments.

Some time ago Scott Watermasysk has described [who to add custom entry handlers to .Text](http://scottwater.com/blog/archive/2004/03/11/11537) v.96. According to these instructions, my entry handler looks as follows:

``` csharp
public class NoFollowFormatHandler : IEntryFactoryHandler
{
    public NoFollowFormatHandler()
    {}
    public void Configure()
    {}
    public void Process(Entry entry)
    {
        entry.Body = ReformatLinks(entry.Body);
    }
    private string ReformatLinks(string text)
    {
        return text.Replace(
            "<a target=\"_new\" href=\"",
            "<a target=\"_new\" rel=\"nofollow\" href=\"");
    }
}
```

Afterwards, you have to add this handler to the event handler configuration section in your `web.config`, in fact after the default handler:

``` xml
<EntryHandlers>
    <EntryHandler
        type="Dottext.Framework.EntryHandling.CommentFormatHandler, Dottext.Framework"
        postType="Comment" processAction="Insert" processState="PreCommit"
        isAsync="false" />
    <EntryHandler
        type="Dottext.NoFollow.NoFollowFormatHandler, Dottext.NoFollow"
        postType="Comment" processAction="Insert" processState="PreCommit"
        isAsync="false" />
    <EntryHandler
        type="Dottext.Framework.EntryHandling.CommentDeliveryHandler, Dottext.Framework"
        postType="Comment" processAction="Insert" processState="PostCommit"
        isAsync="true" />
    ...
```

That's it. You may either download the [source code](/files/archive/Dottext.NoFollow_src.zip), or just get the [compiled assembly](/files/archive/Dottext.NoFollow.zip) and copy it to your bin folder. Add the handler in the `web.config`, and all links in new comments will have the `rel="nofollow"` attribute.

Be aware, that this solution targets .Text v.96 only. V.95 does not have entry handlers, so please don't bother me with asking for a .95 version.

