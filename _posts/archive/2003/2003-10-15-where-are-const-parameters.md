---
layout: post
title: 'Where are const parameters?'
date: 2003-10-15 08:02:00 +02
comments: true
disqus_identifier: 225
categories: [Development]
redirect_from:
  - /blog/archive/2003/10/15/225.aspx
---

I'm programming in C\# for about 18 month by now, and I really like it. However, what I'm missing about C\# are constant parameters.

In C++ you can declare parameters as const, so the called method cannot change it. It's kind of a contract. If the method signature says, a parameter is constant, it won't change it.

AFAIK that's not possible in C\#. Whenever you call a method with a parameter which is a reference-type, that method is capable to change it.

One possible solution is shown in following sample:

``` C#
public interface IFoo
{
    int Param {get; }
}

public class Foo : IFoo
{
    private int param;
    public int Param
    {
        get { return param; }
        set { param = value; }
    }
}

public class MainClass
{
    private static void Bar(IFoo foo)
    {
        foo.Param = 42;
    }
   
    public static void Main()
    {
        Foo foo = new Foo();
        Bar(foo);
    }
}
```

Our object we want to forward to our method as const is of type `Foo`. However, this class implements the `IFoo` interface. This interface just defines *getter* functions, so it is somewhat read-only. The method Bar just takes a parameter of the interface type. Therefore, it is not able to change the concrete Foo object.

Aynway, forget what I've said. That's just a nasty work-around. I don't want to implement a special interface for each of my classes soleley because I need a const parameter. Do you?

Finally, I will return to the opening question: Why does C\# do not support const parameters? I hope [Brad Abrams](http://blogs.gotdotnet.com/BradA/) or someone else will read and answer this question. (BTW, does the MSIL? At least it supports default parameters, which C\# doesn't)

