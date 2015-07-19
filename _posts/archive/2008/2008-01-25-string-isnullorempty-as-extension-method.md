---
layout: post
title: 'String.IsNullOrEmpty as Extension Method'
date: 2008-01-25 12:53:00 +01
comments: true
disqus_identifier: 57390
categories: ['.NET']
redirect_from:
  - /blog/archive/2008/01/25/string-isnullorempty-as-extension-method.aspx/
---

Most you will probably know about Extension Method introduced with C\# 3.0. If not, I strongly recommend to read ScottGu's [explanation](http://weblogs.asp.net/scottgu/archive/2007/03/13/new-orcas-language-feature-extension-methods.aspx).

Anyway, a couple of days ago Brad Wilson posted [an experiment](http://bradwilson.typepad.com/blog/2008/01/c-30-extension.html):

> What I wasn't sure was whether or not you could call these extension methods when you have a null instance of the object, since they're instance methods. The C++ guy in me said "sure, that should be legal", and the C\# guy in me said "it's probably illegal, and that's too bad". Amazingly, the C++ guy in me won!
>
> This code executes perfectly:
>
> ``` csharp
> using System;
>
> public static class MyExtensions {
>     public static bool IsNull(this object @object) {
>         return @object == null;
>     }
> }
>
> public class MainClass {
>     public static void Main() {
>         object obj1 = new object();
>         Console.WriteLine(obj1.IsNull());
>
>         object obj2 = null;
>         Console.WriteLine(obj2.IsNull());
>     }
> }
> ```
>
> When you run it, it prints out "False" and "True". Excellent!

When I read that I immediatley thought of another application. I guess all my readers are familiar with [`String.IsNullOrEmpty`](http://msdn2.microsoft.com/en-us/library/system.string.isnullorempty.aspx) which was introduced with .NET 2.0. So I asked myself if you can make `IsNullOrEmpty` a parameterless extension method:

``` csharp
using System;

public static class MyExtensions
{
    public static bool IsNullOrEmpty(this String s)
    {
        return String.IsNullOrEmpty(s);
    }
}

public class MainClass
{
    public static void Main()
    {
        string s1 = "Hello world";
        Console.WriteLine(s1.IsNullOrEmpty());

        string s2 = null;
        Console.WriteLine(s2.IsNullOrEmpty());
    }
}
```

Again, it prints out `false` and `true`. And in my opinion this [syntactic sugar](http://en.wikipedia.org/wiki/syntactic%20sugar) looks much more elegant than the ordinary `String.IsNullOrEmpty(s2)`</span>`.

If only C\# would support [extension **properties**](http://forums.microsoft.com/MSDN/ShowPost.aspx?PostID=1170257&SiteID=1)...

