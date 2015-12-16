---
layout: post
title: 'New Features in CS 3.0'
date: 2006-10-23 10:03:00 +02
comments: true
disqus_identifier: 18062
categories: [Community Server]
redirect_from:
  - /blog/archive/2006/10/23/New-Features-in-CS-3.0.aspx
---

Scott posted his [three favorite new features in Community Server 3.0](http://scottwater.com/blog/archive/cs-3-0-update.aspx), one of which is

> 1.  **Configuration Merge** - one of the deployment things I hate is managing configuration files. We now support placing configuration overrides in an optional "\_override" file. At runtime, CS will attempt to override default settings with changes found in the override file. The override file uses a pretty simple schema/structure along with XPath.  (Note: as in previous releases, each version places less in configuration files, but there are some cases where this is not feasible, hence the need for a way to manage it a little better). Also of interest, we have moved the connectionstring to a separate file. This is fully supported by ASP.Net out of the box. Our initial thought was this would be for development only and when we shipped we would move it back. Having used this system for a couple weeks, I am starting to think we should keep it for the long haul. The connectionstring is generally the only thing users had to change in the web.config, with this now external, it makes it much easier to deploy updates and new versions.

Great news for all developers who extend CS with jobs, modules etc, because users do not have to edit CS' configuration files anymore. E.g. in the past you had to add the module type to the *CSModules* section in *communityserver.config*. As far as I understand, with CS 3.0 you can simply drop your *CSMVPs\_communityserver\_override.config* (or whatever the naming schema is) into the root folder of your CS installation, and CS will pick up your modules/jobs automatically. I'm curious about the implementation.

