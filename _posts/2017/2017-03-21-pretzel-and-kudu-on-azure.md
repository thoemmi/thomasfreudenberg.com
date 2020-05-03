---
layout: post
title: 'Pretzel and Kudu on Azure'
comments: true
tags: [Pretzel]
disqus_identifier: 50005
keywords: [pretzel,azure,kudu,deploy]
og_image: /files/archive/pretzel-and-azure.png
---

I've published a couple of posts about that I'm using [Pretzel](https://github.com/Code52/pretzel)
to generate the HTML pages of my blog. However, I didn't talk about the hosting.

Actually, it's quite simple: The source files for the site are hosted in a
[git repository on GitHub](https://github.com/thoemmi/thomasfreudenberg.com). The generated site is
hosted in Azure. Whenever I push changes to the git repository, the web site will be updated
automatically.

![Pretzel and Azure](/files/archive/pretzel-and-azure.png){: .align-center}

The setup is a two-stage process: first, you have to create a Azure App Service and connect it to
your git repository. The steps involved are documented very well in
[Continuous Deployment to Azure App Service](https://docs.microsoft.com/en-us/azure/app-service-web/app-service-continuous-deployment).

The second step is to execute Pretzel on the Azure side. Enter **Kudu**. Kudu is the engine
behind git deployments in Azure. It's well documented in the [wiki at GitHub](https://github.com/projectkudu/kudu/wiki).
[By default](https://github.com/projectkudu/kudu/wiki/Deployment), Kudu will locate the relevant
`csproj` file, compile it, and copy the artifacts to wwwroot. That's why many web sizes running on
Azure contain an empty "shim project".

However, you can simplify the setup by [customizing Kudu's behavior](https://github.com/projectkudu/kudu/wiki/Customizing-deployments).
In my case I want Kudu to run `pretzel.exe` to generate the static HTML files from my sources:

1. Add `pretzel.exe` (and all its dependencies) to your git repository (I've used a subfolder named
   `_pretzel`)

2. Add a batch file `deploy.cmd` to execute `pretzel.exe`:

   ```batch
   @echo off
   echo Running Pretzel...
   _pretzel\pretzel.exe bake --destination=%DEPLOYMENT_TARGET%
   ```

   `bake` is the Pretzel's command to generate the files, and the destination folder is `%DEPLOYMENT_TARGET%`,
   which is the wwwroot folder.

3. Instruct Kudu to execute that `deploy.cmd` by creating a file `.deployment` with following
   content:

   ```ini
   [config]
   command = deploy.cmd
   ```

That's all. Whenever I push changes to the git repository, Kudu will get the current files,
execute Pretzel, and the updated web site is public. The whole process takes less than a minute.

Of course this can be adapted to any other static site generator too, e.g. Jekyll.
