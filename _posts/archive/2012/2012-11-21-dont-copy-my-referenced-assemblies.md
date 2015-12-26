---
layout: post
title: 'Don’t copy my referenced assemblies'
date: 2012-11-21 07:51:17 +01
comments: true
disqus_identifier: 403453
tags: [msbuild]
redirect_from:
  - /blog/archive/2012/11/21/don-t-copy-my-referenced-assemblies.aspx
---

There are cases where you don’t want referenced assemblies to be copied to your output folder.

E.g. you write a plugin for an existing application, which provides a library declaring its contracts. Since the application will load that contract assembly itself, there’s no need for a second copy of the assembly in your plugin folder.

“But you can configure Visual Studio not to copy a reference to the output folder,” you may say. Well, that’s right. In the properties of a referenced assembly you can simply set **Copy Local** to **False**.

But…

If you’re an avid user of NuGet like I am, every time you update a package, the old references are removed from your project and the new ones will be added, and **Copy Local** will be **True** again. Do you think you will always remember to change that property back to **False** whenever you update a package? I don’t know about you, but I won’t.

Therefore, here’s a little trick I use in such cases. I have a little MSBuild file which suppresses any referenced assembly to be copied to the output folder:

``` xml
<?xml version="1.0" encoding="utf-8"?>
<Project ToolsVersion="4.0" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">

  <!-- make all references non-private, so they won't be copied to the output folder -->
  <Target Name="ClearReferenceCopyLocalPaths" AfterTargets="ResolveAssemblyReferences">
    <ItemGroup>
      <ReferenceCopyLocalPaths Remove="@(ReferenceCopyLocalPaths)" />
    </ItemGroup>
  </Target>

</Project>
```

Save that snippet to a file i.e. **PreBuild.targets**, and include it in your project file like this:

``` xml
  <Import Project="$(MSBuildToolsPath)\Microsoft.CSharp.targets" />
  <Import Project="$(SolutionDir)\.nuget\nuget.targets" />
  <Import Project="PreBuild.targets" />
```

That’s it. From now on the output folder will only contain your assembly (along with other build artifacts such as the pdb file, of course)

