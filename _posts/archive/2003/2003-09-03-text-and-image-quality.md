---
layout: post
title: '.Text and Image quality'
date: 2003-09-03 13:33:00 +02
comments: true
disqus_identifier: 156
tags: [.Text]
redirect_from:
  - /blog/archive/2003/09/03/156.aspx
  - /blog/posts/156.aspx
---

I don't know what others think, but IMHO the quality of the preview images generated by [.Text](http://scottwater.com/dottext/) isn't as good as it could be. Currently it just resizes the images with the simplest algorithm existing in the .NET framework.

Therefore, I've patched the sources, so it will use bicubic interpolation. Here's a comparison:

| Previous resizing                                    | Bicubic resizing                                     |
|------------------------------------------------------|------------------------------------------------------|
| ![Standard resizing](/files/archive/pool_simple.jpg) | ![Bicubic resizing](/files/archive/pool_bicubic.jpg) |

Maybe Scott wants to commit my changes to his sources, so here's what I did: The image conversion happens in the method `MakeAlbumImages` in `Dottext.Framework.Images`. I've added another method which does the resizing, and added the calls to it in the original method. Following the affected code snippet, I've marked my changes bold:

``` C#
public static void MakeAlbumImages(ref Dottext.Components.Image _image)
{
    System.Drawing.Image original = System.Drawing.Image.FromFile(_image.OriginalFilePath);

    Size _newSize = ResizeImage(original.Width,original.Height,640,480);
    _image.Height = _newSize.Height;
    _image.Width = _newSize.Width;
    System.Drawing.Image displayImage = ResizeImage(original,_newSize);
    System.Drawing.Image tbimage = ResizeImage(original, ResizeImage(original.Width,original.Height,120,120));
    original.Dispose();

    displayImage.Save(_image.ResizedFilePath, GetFormat(_image.File));
    displayImage.Dispose();
    tbimage.Save(_image.ThumbNailFilePath,ImageFormat.Jpeg);
    tbimage.Dispose();
}

private static System.Drawing.Image ResizeImage(System.Drawing.Image original, Size newSize)
{
    System.Drawing.Image result = newBitmap(newSize.Width, newSize.Height);
    using(Graphics g = Graphics.FromImage(result))
    {
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        g.DrawImage(original, 0, 0, newSize.Width, newSize.Height);
    }
    return result;
}
```
