---
layout: post
title: 'Mixing C# and VB.NET in one assembly'
date: 2006-08-21 13:18:00 +02
comments: true
disqus_identifier: 17593
categories: [Development, MSBuild, CSMVPs]
redirect_from:
  - /blog/archive/2006/08/22/Mixing-C_2300_-and-VB.NET-in-one-assembly.aspx/
---

A couple of weeks ago Jayson Knight invited me to join the [CSMVP's](http://csmvps.com/)' [CSModules package](http://csmvps.com/blogs/news/archive/2006/08/14/Community-Server-MVP_2700_s-Alabaster-CSModule-Package.aspx). This project was created to incorporate several CSModules written by CS MVP's. So I bought into that project by bringing along my Akismet spam rule.

At that point in time, for each CSModule there was a single Visual Studio project, all bound together in a Visual Studio solution. But our goal was to incorporate all modules into a single assembly, so the user only has to copy one DLL to his `/bin` web folder.

My first idea was to put all sources into a single project. However, since every CS MVP wrote his module in his favorite language, there were both C\# and VB.NET projects. Unfortunately, in Visual Studio projects have a certain type supporting only a single language.

But luckily, even if there's no support by the IDE, you still can compile different .NET languages into one assembly. The solution are modules. A module is a unit of compilation, comparable to `.obj` files in C++. It can't stand by its own, but must be linked into an assembly before it can be used. Basically, a module is an assembly without a manifest. You can get more details on MSDN at [.netmodule Files as Linker Input](http://msdn2.microsoft.com/en-us/library/k669k83h.aspx). Additionally I recommend reading Junfeng Zhang's [Netmodule vs. Assembly](http://blogs.msdn.com/junfeng/archive/2005/02/12/371683.aspx) and [Multimodule Assemblies](http://blogs.msdn.com/junfeng/archive/2004/07/15/183813.aspx).

Knowing the concept of modules, I was able to write a MSBuild project file to compile all CSModules into a single assembly. Here's an (extremely) simplified version:

``` xml
<Project
  DefaultTargets="build"
  xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
        
  <!-- Target folders -->
  <PropertyGroup>
    <SourcePath>src</SourcePath>
  </PropertyGroup>

  <!-- Specify the sources to include, excluding any assembly info's -->
  <ItemGroup>
    <CSFiles
      Include="$(SourcePath)/**/*.cs"
      Exclude="$(SourcePath)/**/assemblyinfo.cs"/>
    <VBFiles 
      Include="$(SourcePath)/**/*.vb" 
      Exclude="$(SourcePath)/**/assemblyinfo.vb;$(SourcePath)/**/My Project/*"/>
  </ItemGroup>

  <!-- Specify all referenced assembly -->
  <ItemGroup>
    <References Include="lib/2.1 RTM/*.dll" />
  </ItemGroup>

  <!-- Target files -->
  <PropertyGroup>
    <OutputModule>MyModule</OutputModule>
  </PropertyGroup>

  <!-- builds the CSMVPs.CSModules assembly -->
  <Target 
    Name="build"
    Inputs="@(CSFiles);@(VBFiles);@(References)" 
    Outputs="$(OutputModule).dll">

    <!-- compile C# sources -->
    <CSC
      Sources="@(CSFiles)"
      References="@(References)" 
      OutputAssembly="$(OutputModule).CS.netmodule"
      TargetType="module">
    </CSC>
      
    <!-- compile VB.NET sources -->
    <VBC
      Sources="@(VBFiles)"
      References="@(References)" 
      OutputAssembly="$(OutputModule).VB.netmodule"
      TargetType="module">
    </VBC>

    <!-- link the C# and VB.NET modules -->
    <Exec 
      Command="link /dll /ltcg /out:$(OutputModule).dll *.netmodule" />
  </Target>
</Project>
```