---
layout: post
title: 'Emoticons within .Text'
date: 2003-09-19 06:56:00 +02
comments: true
disqus_identifier: 199
categories: [.Text]
redirect_from:
  - /blog/archive/2003/09/19/Emoticons-within-.Text.aspx
---

Some days back I've started to implement support for emoticons in [.Text](http://scottwater.com/dottext/). It was expected to replace any textual emoticons such as :) into the graphical representation such as ![Smiley](/files/archive/smiley_smile.gif).

However, today I notived that [ScottW](http://scottwater.com/) is already adding this into .Text. At least I found it when synchronizing my home installation with the published [sources](http://www.gotdotnet.com/Community/Workspaces/workspace.aspx?id=e99fccb3-1a8c-42b5-90ee-348f6b77c407). Unfortunately, the file containing the replacement table is missing up to now. But since Scott uses the same algorithm as [ASP.NET Forums](http://www.gotdotnet.com/Community/Workspaces/workspace.aspx?id=d9e0d1dc-122a-4dc7-a216-b76bd927b20b) do, I took their file (emoticons.txt, is that).

Anyway, the graphics Scott envisioned to use are not my favourites. Therefore, I'm using the same as [CodeProject](http://www.codeproject.com/) does. Finally, here's my substitution table:

`[:``)]`

![Smiley](/files/archive/smiley_smile.gif)

`[:``-D]`

![Big Smile](/files/archive/smiley_biggrin.gif)

`[``=:O]`

![Scared](/files/archive/smiley_frown.gif)

`[``P]`

![Tongue out](/files/archive/smiley_tongue.gif)

`[;``)]`

![Smiley](/files/archive/smiley_smile.gif)

`[:``(]`

![Sad](/files/archive/smiley_frown.gif)

`[:``~]`

![Perplexed](/files/archive/smiley_confused.gif)

`[:``|]`

![Expressionless](/files/archive/smiley_line.gif)

`[:``'(]`

![Crying](/files/archive/smiley_cry.gif)

`[:``}]`

![Blushing](/files/archive/smiley_redface.gif)

`[8``)]`

![Cool](/files/archive/smiley_cool.gif)

`[>``:<]`

![Mad](/files/archive/smiley_mad.gif)

`[0``:)]`

![Rolleyes](/files/archive/smiley_rolleyes.gif)

`[X``(]`

![Dead](/files/archive/smiley_dead.gif)

`[d``oh]`

![Doh](/files/archive/smiley_doh.gif)

`[e``ek]`

![Eek](/files/archive/smiley_eek.gif)

`[o``mg]`

![OMG](/files/archive/smiley_omg.gif)

`[s``igh]`

![sigh](/files/archive/smiley_sigh.gif)

`[``zzz]`

![Zzz](/files/archive/smiley_Snore.gif)

`[``wtf]`

![WTF](/files/archive/smiley_WTF.gif)

`[``unsure]`

![Unsure](/files/archive/smiley_squeamish.gif)

 

**Update:** Of course I asked [Chris](http://www.codeproject.com/script/profile/whos_who.asp?id=1) (heart and soul of CodeProject) for permission to use the depicted graphics. Therefore as promised: Credits for the emoticons go to Chris and CodeProject.

