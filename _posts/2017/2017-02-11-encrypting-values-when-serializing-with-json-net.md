---
layout: post
title: 'Encrypting values when serializing with JSON.NET'
comments: true
tags: [JSON.NET]
disqus_identifier: 50004
keywords: [json, json.net, encryption, secure, newtonsoft, JsonConverter]
---

In a small inhouse app I wrote recently I store the settings in a json file, using the
popular [Json.NET](http://www.newtonsoft.com/json) library. However, the settings
include a password, which should't appear as clear text in the json file.

I stumbled over [this](http://stackoverflow.com/a/29240043/4747) answer at Stack Overflow
by Brian Rogers. This solution uses a custom
[`IContractResolver`](http://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_Serialization_IContractResolver.htm)
and a new marker attribute `JsonEncryptAttribute`. Adding the attribute is quite easy:

```csharp
public class Settings {
    [JsonEncrypt]
    public string Password { get; set; }
}
```

But you have to remember to add the `ContractResolver` additionally:

```csharp
JsonConvert.SerializeObject(book, Formatting.Indented, new JsonSerializerSettings {
    ContractResolver = new EncryptedStringPropertyResolver ("#my*S3cr3t")
});
```

Though the solution is clever, I don't like the custom `IContractResolver`. Therefore
I read through Json.NET's documentation to find an easier way, i.e. by only applying
an attribute to the property to encrypt.

In fact, Json.NET supports custom converters by annotating properties with
[`JsonConverterAttribute`](http://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_JsonConverterAttribute.htm).
That attribute even allows you to pass additional parameters to your custom converter,
like in this case the encryption key.

Therefore I took Brian's code and converted it into a `JsonConverter` (also published as a
[Gist](https://gist.github.com/thoemmi/e118c15e7588750b1cc18dab00be31fd#file-encryptingjsonconverter-cs)):

{% gist e118c15e7588750b1cc18dab00be31fd EncryptingJsonConverter.cs %}

And the usage is pretty simple:

```csharp
public class Settings {
    [JsonConverter(typeof(EncryptingJsonConverter), "#my*S3cr3t")]
    public string Password { get; set; }
}
```

There's no need for any additional code like a custom `ContractResolver`.
And you can even use different encryption keys for different properties.

My code works only for `string` properties though, but that's all I needed.

