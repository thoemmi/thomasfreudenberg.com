---
layout: post
title: 'Pretzel Plugin: Redirect'
comments: true
tags: [Pretzel]
disqus_identifier: 50003
keywords: [Pretzel,Plugin,redirect]
---

A while back I wrote about the migration of my blog from Community Server over Jekyll to Pretzel.

One golden rule when restructuring a web site is to avoid dead links. The original web engine was
a classic ASP.NET application, where every URL ends in `.aspx` (at least if you don't configure
extensionless URLs). Tens years ago every URLs ended in an extension like `.html`, `.php`, whatever.
Now-a-days, you barely see any file extensions anymore. The web servers don't expose the underlying
technology, and the user just doesn't care. And so does Pretzel.

To use a new URL schema, but preserve the old links and redirect them to the new schema, I wrote
an plugin for Pretzel, [Pretzel.RedirectFrom](https://github.com/thoemmi/Pretzel.RedirectFrom).
I've used the [jekyll-redirect-from](https://github.com/jekyll/jekyll-redirect-from) plugin as
a guide, so the syntax is the same. Just add alternative URLs in the page's YAML front-matter:

```yaml
---
title: "My First Post"
redirect_from:
  - /pages/page1
---
```
This will generate a small html page at `\pages\page1\index.html`, which will redirect to the new
location:
```html
<!DOCTYPE html>
<meta charset="utf-8" />
<title>Redirecting...</title>
<link rel="canonical" href="/2016/10/31/myfirstpost.html" />
<meta http-equiv="refresh" content="0; url=/2016/10/31/myfirstpost.html" />
<h1>Redirecting...</h1>
<a href="/2016/10/31/myfirstpost.html">Click here if you are not redirected.</a>
<script>
    location="/2016/10/31/myfirstpost.html"
</script>
```

Pretzel is a static file generator, so the redirection must be performed at the client-side.

However, I prefer a "real" redirect, i.e. a response with the correct HTTP status `301 Moved Permanently`.
Therefore I've implemented an additional switch. If you're using IIS (or Azure, or any other web server
supporting ASP.NET), you can specify the switch `redirect_generate_aspx: true` in Pretzel's
`_config.yml`. In this case the generated page will look like this:

```aspnet
<%@ Page Language="C#"%>
<script runat="server">
private void Page_Load(object sender, System.EventArgs e)
{
    Response.StatusCode = 301;
    Response.Status = "301 Moved Permanently";
    Response.AddHeader("Location","/2016/10/31/myfirstpost.html");
    Response.End();
}
</script>
```
This ensures that the server returns the correct HTTP status.

Anyway, this plugin is a [simple ScriptCs file](https://github.com/Code52/pretzel/wiki/create-plugins),
so you only have to copy
[Pretzel.RedirectFrom.csx](https://github.com/thoemmi/Pretzel.RedirectFrom/blob/master/Pretzel.RedirectFrom.csx)
to the `_plugin` folder of your Pretzel site, and you will be ready to use redirects.