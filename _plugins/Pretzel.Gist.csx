#r System.Web
#r "Octokit.dll"

public class GistTagFactory : TagFactoryBase
{
    public GistTagFactory() : base("Gist") {}

    public override ITag CreateTag() {
        string gitHubToken;
        object obj;
        if (SiteContext.Config.TryGetValue("GitHubToken", out obj) && obj is string) {
            gitHubToken = (string)obj;
            Tracing.Debug($"Read GitHub token from config");
        } else {
            gitHubToken = System.Environment.GetEnvironmentVariable("GitHubToken");
            if (!string.IsNullOrEmpty(gitHubToken)) {
                Tracing.Debug($"Read GitHub token from environment variable");
            } else {
                Tracing.Debug($"No GitHub token provided.");
            }
        }

        return new GistTag(gitHubToken);
    }
}

public class GistTag : DotLiquid.Tag, Pretzel.Logic.Extensibility.ITag {
    private string _gistId;
    private string _filename;
    private string _githubToken;

    public new string Name => "Gist";

    public GistTag(string gitHubToken) {
        _githubToken = gitHubToken;
    }

    public override void Initialize(string tagName, string markup, List<string> tokens) {
        var arguments = markup.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        if (arguments.Length < 1 || arguments.Length > 2) {
            throw new ArgumentException("Expected syntax: {% gist gist_id [filename] %}");
        }

        _gistId = arguments[0];
        _filename = arguments.Length == 2 ? arguments[1] : null;
    }

    public override void Render(Context context, TextWriter result) {
        var url = $"https://gist.github.com/{_gistId}.js";
        if (!string.IsNullOrEmpty(_filename)) {
            url += "?file=" + _filename;
        }
        result.Write($"<script src=\"{url}\"></script>");

        if (string.IsNullOrEmpty(_githubToken)){
            return;
        }

        var gistFiles = GetGistFiles(_gistId, _filename);
        result.Write("<noscript>");
        foreach (var gistFile in gistFiles){
            result.Write(Environment.NewLine);
            result.Write($"```{gistFile.Language?.ToLowerInvariant()}");
            result.Write(Environment.NewLine);
            result.Write(gistFile.Content);
            result.Write(Environment.NewLine);
            result.Write("```");
            result.Write(Environment.NewLine);
        }
        result.Write("</noscript>");
    }

    private IEnumerable<Octokit.GistFile> GetGistFiles(string gistId, string filename = null) {
        var client = new Octokit.GitHubClient(new Octokit.ProductHeaderValue("Pretzel.Gist")) {
            Credentials = new Octokit.Credentials(_githubToken)
        };

        var gist = client.Gist.Get(gistId).Result;

        Octokit.GistFile gistFile;
        if (filename != null && gist.Files.TryGetValue(filename, out gistFile)) {
            return new[] { gistFile };
        } else {
            return gist.Files.Values;
        }
    }
}