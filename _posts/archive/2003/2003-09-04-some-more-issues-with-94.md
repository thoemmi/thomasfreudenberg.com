---
layout: post
title: 'Some more issues with .94'
date: 2003-09-04 07:53:00 +02
comments: true
disqus_identifier: 158
categories: [.Text]
redirect_from:
  - /blog/archive/2003/09/04/Some-more-issues-with-.94.aspx/
---

~~I've updated my site to~~ [~~.Text .94~~](http://scottwater.com/dottext/posts/9738.aspx)~~, but unfortunately I have had some issues, though I followed~~ [~~Scott's instructions~~](http://scottwater.com/dottext/posts/9742.aspx)~~. Maybe I did something wrong during the setup, but here are my changes to the aggregated version of `web.config` to get my site working:~~

1.  ~~Whenever I tried to go to the admin section of a blog, I got an error. .Text complained about missing templates of the admin pages. Therefore, I added following entries to the `appSettings` section:~~

    ``` xml
    <add key="Admin.DefaultTemplate" value="~/Admin/Resources/PageTemplate.ascx" />
    <add key="Admin.DownlevelTemplate" value="~/Admin/Resources/PageTemplate.ascx" />
    <add key="Admin.DefaultContent" value="PageContent" />

    ```
2.  ~~The authentification was set to Windows. I switched back to Forms authentification:~~

    ``` xml
    <authentication mode="Forms">
      <forms name=".ASPXFORADMIN" loginUrl="login.aspx" protection="All"  timeout="90" />
    </authentication>
    ```

3.  [~~Steve~~](http://adminblogs.com/steve/) ~~~~ [~~mentions~~](http://adminblogs.com/steve/posts/146.aspx) ~~to change the httpHandlers. Hmm, there is no `httpHandlers` section in my `web.config`. I admit I was already wondering when Scott moved all the handling stuff to blog.config. Someone has to tell ASP.NET to use that. Therefore:~~

    ``` xml
    <httpHandlers>
      <add verb="*" path="*" type="Dottext.Framework.UrlManager.UrlReWriteHandlerFactory,Dottext.Framework" />
    </httpHandlers>
    ```

~~With these modification my .Text installation works like a charm :-)~~

**~~Update:~~**

1.  ~~ASP.NET 1.1 validates the input, so I cannot use HTML in my posts. I've added following line:~~

    ``` xml
    <pages validateRequest="false" />
    ```

Ooops, my fault. I was using the out-dated `web.config`. Note to myself: [RTFM](http://info.astrian.net/jargon/terms/r/RTFM.html).

