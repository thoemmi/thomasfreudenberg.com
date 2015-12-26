---
layout: post
title: 'Binding WebBrowser content in WPF'
date: 2010-08-01 06:23:00 +02
comments: true
disqus_identifier: 258000
tags: [WPF, MVVM]
redirect_from:
  - /blog/archive/2010/08/01/binding-webbrowser-content-in-wpf.aspx
---

When you’re using a [WebBrowser control](http://msdn.microsoft.com/en-us/library/system.windows.controls.webbrowser.aspx "WebBrowser control") in your WPF application, you may have noticed that you can’t bind the control’s content. WebBrowser has no property to set its content but a method named [`NavigateToString`](http://msdn.microsoft.com/en-us/library/system.windows.controls.webbrowser.navigatetostring.aspx "WebBrowser.NavigateToString"). So when you’re following a strict MVVM approach you’re lost because you don’t want any code-behind for your views.

But then there are [attached properties](http://msdn.microsoft.com/en-us/library/ms749011.aspx). As their name implies they allow you to attach new properties to existing dependency objects. In your XAML code you apply such a attached property to your element and can access it as any other property of the object.

Ok, first here’s the code of an attached property to set a `WebBrowser`’s content:

``` csharp
public class WebBrowserHelper {
    public static readonly DependencyProperty BodyProperty =
        DependencyProperty.RegisterAttached("Body", typeof (string), typeof(WebBrowserHelper), new PropertyMetadata(OnBodyChanged));

    public static string GetBody(DependencyObject dependencyObject) {
        return (string) dependencyObject.GetValue(BodyProperty);
    }

    public static void SetBody(DependencyObject dependencyObject, string body) {
        dependencyObject.SetValue(BodyProperty, body);
    }

    private static void OnBodyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
        var webBrowser = (WebBrowser) d;
        webBrowser.NavigateToString((string)e.NewValue);
    }
}
```

The static `BodyProperty` defines the type of the attached property: its name is `Body`, the type is `string`, and whenever it is changed the method `OnBodyChanged` should be called.

The accessors for a attached property must be conventionally named `SetXxx` and `GetXxx`. They are called whenever you set or get the property’s value.

Last but not least `OnBodyChanged` is called when the value of the property has changed. The first parameter is the object the property is attached to, so we can cast it to `WebBrowser` and call its `NavigateToString` method.

The actual usage of the new Body property is pretty simple:

``` xml
<WebBrowser
    src:WebBrowserHelper.Body="{Binding MyHtml}"
    />
```

given that the ViewModel has a property named `MyHtml` providing the desired content for the control.

A complete sample application is available on [GitHub](http://github.com/thoemmi/WebBrowserHelper "GitHub").
