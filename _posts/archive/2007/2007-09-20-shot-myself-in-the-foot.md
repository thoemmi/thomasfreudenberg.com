---
layout: post
title: 'Shot myself in the foot'
date: 2007-09-20 08:02:00 +02
comments: true
disqus_identifier: 40544
tags: [Site news, Comment Spam, CAPTCHA, Honeypot]
redirect_from:
  - /blog/archive/2007/09/20/shot-myself-in-the-foot.aspx
---

If you have tried to leave a comment on my site in the last two days, you may have noticed that they weren´t accepted. Here is why:

Because the rate of incoming spam decreased dramatically after I implemented the [Honeypot CAPTCHA](/archive/2007/09/17/honeypot-captcha-for-community-server/) on this site, I wondered if I could really give that solution the credit. Therefore I entered a comment myself to check it. And what happened? Nothing! Instead, that small red asterisk appeared next to the comment field, indicating that nothing was entered. WTF? I did enter some text! Garbage, I admit, but at least a few characters. Then I remembered that I switched the identifiers of the regular comment text box and the honeypot box. Then I had a sneaking suspicion, and I quickly checked `post.aspx`. My apprehension proved true: I have forgotten to point the `RequiredFieldValidor` to the other identifier! So as long as you didn't fill in the hidden honeypot, you couldn't post your comment. How stupid is that? The ironic side of the story is, that only comment spammers were able to cross that barrier, just to get marked as spam instantly afterwards.

Anyway, it´s fixed by now, and your comments are welcome (again)!

