<%@ Page Language="C#"%>
<script runat="server">
private void Page_Load(object sender, System.EventArgs e)
{
    Response.StatusCode = 301;
    Response.Status = "301 Moved Permanently";
    Response.AddHeader("Location","/");
    Response.End();
}
</script>