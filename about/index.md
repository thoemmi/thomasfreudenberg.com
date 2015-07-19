---
layout: page
title: About
include_in_sidebar: true
show_metadata: false
---

## About me

I'm the technical head of product development at [Cubeware](http://www.cubeware.com), offering a complete product family around business intelligence.

In my spare time I struggle with different open-source projects. If the weather is acceptable, you'll find me riding my bicycle in the Alps.

## Finding me elsewhere

<i class="fa fa-github-square"></i> [Github](http://github.com/thoemmi)<br/>
<i class="fa fa-twitter-square"></i> [Twitter](http://twitter.com/thoemmi)<br/>
<i class="fa fa-linkedin-square"></i> [LinkedIn](http://linkedin.com/in/freudenberg)<br/>
<i class="fa fa-xing-square"></i> [Xing](http://www.xing.com/profile/Thomas_Freudenberg)

## Some projects I'm working on

### [Solutionizer](https://github.com/thoemmi/Solutionizer)

This is a small tool caused by needs in my former company. It scans a directory tree for all C# projects and allows the user to create a Visual Studio solution containing only those projects the user is currently interested in. Beyond other features it can add referenced projects automatically up to a configurable depth, and even set the TFS binding in the generated solution.

### [NDepCheck](https://github.com/thoemmi/NDepCheck)

This is also a tool we used at work extensively. It checks all dependencies in an assembly against a given set of rules, i.e. classes in namespace A must not reference classes in namespace B. If a restrictive rule is violated, our CI build fails.