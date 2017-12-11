---
layout: post
title: 'ResourceLib, PE Format, and WiX'
comments: true
tags: [WiX, ResourceLib]
keywords: [WiX, ResourceLib, WiX toolset, wixtoolset, setup, installer, resources, win32]
disqus_identifier: 50008
---

*Some time ago I reported a bug and provided a pull request to
[**resourcelib**](https://github.com/resourcelib/resourcelib), a managed
library to read and write Win32 resources in executables or DLL's.
And unawarely, the next morning I was a maintainer of that library.*

*This blog post is about an issue we've received: someone tried to
patched the Win32 resources of a* setup.exe *, an executable installer
created with [WiX](http://wixtoolset.org/). However, after changing
the resources with resourdelib, the setup didn't work anymore.*

*I've spent some time investigating this issue using [`dumpbin`](https://msdn.microsoft.com/de-de/library/756as972.aspx)
and reading the [PE format specification](https://msdn.microsoft.com/en-us/library/windows/desktop/ms680547(v=vs.85).aspx#section_table__section_headers_).
Because I don't know how good Google is at indexing Github issues, I'll
also post my analysis here in my blog for reference. The original
thread is [here](https://github.com/resourcelib/resourcelib/issues/19#issuecomment-350891529).*

**TL;DR:** to me it looks like WiX is doing it wrong.

According to the output of `dumpbin` there are 7 sections in the executable the issuer provided:

| # | Name | Range |
|---|--------|--------|
| 1 | `.text` | 0x00000400 to 0x00049FFF |
| 2 | `.rdata` | 0x0004A000 to 0x00068DFF |
| 3 | `.data` | 0x00068E00 to 0x000697FF |
| 4 | `.wixburn` | 0x00069800 to 0x000699FF |
| 5 | `.tls` | 0x00069A00 to 0x00069BFF |
| 6 | `.rsrc` | 0x00069C00 to 0x0006D7FF |
| 7 | `.reloc` | 0x0006D800 to 0x000715FF |

In a hex viewer you can see that after the last section, the file continues for another **104205 bytes**, starting with 0x4D 0x53 0x43 0x46 (`MSCF`, the magic number starting a [cab file](https://de.wikipedia.org/wiki/CAB_(Dateiformat))).

I patched the `StringFileInfo` resource using **resourcelib**, which changed the content of the `.rsrc` section only. Afterwards the file ended at 0x000715FF, i.e. the following **104205 bytes** were missing.

By the way, the `.wixburn` section contains following bytes:

```
RAW DATA #4
  0046C000: 00 43 F1 00 02 00 00 00 04 12 28 81 2C 64 40 48  .C±.......(.,d@H
  0046C010: B2 B1 34 64 EC 08 65 64 00 16 07 00 00 00 00 00  ▓▒4d∞.ed........
  0046C020: 00 00 00 00 00 00 00 00 01 00 00 00 02 00 00 00  ................
  0046C030: 92 8E 01 00 7B 08 00 00                          ....{...
```
which means

| Field | Bytes | Value |
|-------|------:|----------|
| magic number | 0-3 | 0x00f14300 |
| Version | 4-7 | 0x00000002 |
| Bundled GUID | 8-23 | {81281204-642c-4840-b2b1-3464ec086564} |
| Engine (stub) size | 24-27 | 0x00071600 |
| Original checksum | 28-31 | 0x00000000 |
| Original signature offset | 32-35 | 0x00000000 |
| Original signature size | 36-39 | 0x00000000 |
| Container Type (1 = CAB) | 40-43 | 1 |
| Container Count | 44-47 | 2 |
| Byte count of manifest + UX container | 48-51 | 102,034 |
| Byte count of attached container | 52-55 | 2,171 |

### Intermediate result

* the `.wixburn` section points to 104,205 bytes (102,034 + 2,171), starting at 0x00071600.
* the last PE section ends at 0x000715ff.
* after using the official Win32 API to edit resources, the file ends at 0x000715ff, and the following 104,205 byte are gone.

So after editing the resources, the exact payload WiX is referring to is eliminated.

### Therefore my conclusion is that WiX

* adds a (small) section `.wixburn` pointing beyond the last section, and
* appends the payload (read: the cabinet file) at that location-

As far as I understand the specification, this procedure is not compliant with the PE format. That might be the reason why `EndUpdateResource` cuts the file after the last section when writing the changed resources.