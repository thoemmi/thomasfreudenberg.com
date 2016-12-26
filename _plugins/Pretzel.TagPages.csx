using Pretzel.Logic.Extensibility.Extensions;

public class TagConstants {
    public const string Folder = "tag";
    public const string Layout = "tag";
}

public class CreateTagLinkFilter : IFilter {
    public string Name => "CreateTagLink";

    public static List<string> CreateTagLink(List<string> tags) {
        if (tags == null) {
            return null;
        }

        return tags
            .Select(tag => $"<a href=\"/{TagConstants.Folder}/{SlugifyFilter.Slugify(tag)}\">{tag}</a>")
            .ToList();
    }
}

public class TagPagesGenerator : IBeforeProcessingTransform {
    public void Transform(SiteContext context) {

        var tagPages = context
            .Posts
            .SelectMany(page => page.Tags.Select(tag => new {Tag = tag, Post = page}))
            .GroupBy(o => SlugifyFilter.Slugify(o.Tag.ToLowerInvariant()));

        foreach (var tagPage in tagPages) {
            var slug = tagPage.Key;
            var name = tagPage.First().Tag;

            Tracing.Debug($"Generating page for tag \"{name}\"");

            var p = new Page {
                Content = $"---\r\nlayout: {TagConstants.Layout}\r\ntag: {name} \r\n---\r\n",
                File = Path.Combine(context.SourceFolder, TagConstants.Folder, slug, "index.html"),
                Filepath = Path.Combine(context.OutputFolder, TagConstants.Folder, slug, "index.html"),
                OutputFile = Path.Combine(context.OutputFolder, TagConstants.Folder, slug, "index.html"),
                Bag = $"---\r\nlayout: {TagConstants.Layout}\r\ntag: {name}\r\n---\r\n".YamlHeader()
            };

            p.Bag.Add("pages", tagPage.Select(t => t.Post).ToList());
            p.Url = new LinkHelper().EvaluateLink(context, p);

            context.Pages.Add(p);
        }
    }
}
