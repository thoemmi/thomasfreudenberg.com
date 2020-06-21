---
layout: post
title: 'Snippet Compiler 1.7'
date: 2003-09-11 13:43:00 +02
comments: true
disqus_identifier: 190
tags: [Development]
redirect_from:
  - /blog/archive/2003/09/11/190.aspx
---

While two days ago [I told you](http://thoemmi.dyndns.org/tfr/posts/186.aspx) about Snippet Compiler 1.6, today [1.7](http://www.sliver.com/dotnet/snippetcompiler/) has been released. Gosh, I'm glad we don't release our software at this speed.

Judge yourself, if following changes justify a new release:

- Added projects so the user can save/open snippets en masse
- Added "Build" menu so user can build Console exe/WinForms exe/DLL to a user-specified file
- Added "Start as WinForm" and "Start All as WinForm". These will compile the snippets as a WinExe (so the console doesn't pop up first). 
- Added "Start Minimized" option.
- Added "Close All"
- Added samples showing how to break into the debugger (and info in the help file) 
- Noticed <kbd>[Shift+]Ctrl+Tab</kbd> now works.
- Noticed the icon on non 32-bit displays looked really bad, so I added more color depths
- Realized CompilerResults has an Errors property. Smacked head and removed RegExed error parsing.
