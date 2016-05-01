using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;

public partial class _404 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.TrySkipIisCustomErrors = true;
        Response.Status = "404 Not Found";
        Response.StatusCode = 404;
        Response.WriteFile(Server.MapPath("/404.html"));
        Response.End();
    }
}