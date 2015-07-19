---
layout: post
title: 'Honeypot Captcha for Community Server'
date: 2007-09-17 11:34:00 +02
comments: true
disqus_identifier: 40205
categories: []
redirect_from:
  - /blog/archive/2007/09/17/honeypot-captcha-for-community-server.aspx/
---

A few days ago [Phil Haack](http://haacked.com/) wrote about [Honeypot Captcha](http://haacked.com/archive/2007/09/11/honeypot-captcha.aspx):

> At the same time, spam bots tend to ignore CSS. For example, if you use CSS to hide a form field (especially via CSS in a separate file), they have a really hard time knowing that the field is not supposed to be visible.
>
> To exploit this, you can create a *honeypot* form field that *should be left blank* and then use CSS to hide it from human users, but not bots. When the form is submitted, you check to make sure the value of that form field is blank.

A great idea, which didn’t occur to me before. And Phil wasn’t even the first one with that idea.

I added a “regular” captcha control to my site some time ago, but removed it again after a couple of days. Why burden the innocent commentor? He’s not the problem. The comment spammers are.

So I took the idea of the honeypot and leveraged Community Server’s spam filtering capabilities.

First, I replaced the original Community Server’s [WeblogPostCommentForm](http://code.communityserver.org/?path=CS+Tree%5cCS+2007+3.0%5cBlogs%5cControls%5cForms%5cWeblogPostCommentForm.cs) with my own version by simply copying it to my own assembly. (If you build CS from the SDK, you can also just edit the existing one.)

1.  Added the private member

    ``` csharp
    private TextBox HoneyPot;
    ```

2.  Added the property `HoneyPotTextBoxId`, which references the actual TextBox in the form:

    ``` csharp
    public string HoneyPotTextBoxId
    {
        get { return ((string)ViewState["HoneyPotTextBoxId"]) ?? string.Empty; }
        set { ViewState["HoneyPotTextBoxId"] = value; }
    }
    ```

3.  Added following lines to the method `AttachChildControls`:

    ``` csharp
    HoneyPot = WeblogControlUtility.Instance().FindControl(this, HoneyPotTextBoxId) as TextBox;
    StringBuilder sb = new StringBuilder();
    sb.AppendLine("\n<script type=\"text/javascript\">");
    sb.AppendLine("document.getElementById(\"" + HoneyPot.ClientID + "\").style.display = \"none\";");
    sb.AppendLine("</script>");
    CSControlUtility.Instance().RegisterStartupScript(HoneyPot, typeof (TextBox), "honeypot", sb.ToString(), false);
    ```

    You see that the honeypot field is hidden dynamically via JavaScript. No CSS is giving a hint to the spammer that the control will not be visible. Instead, as soon as the page is loaded, the textbox will be hidden programmatically.

4.  Added following lines in `Submit_Click` right before `WeblogPosts.Add` is called:

    ``` csharp
    if (!string.IsNullOrEmpty(HoneyPot.Text)) { 
        EventLogs.Info("Spammer entered \"" + HoneyPot.Text + "\" in the honey pot", "Spam Rules", 0); 
        c.SetExtendedAttribute("GotchaInMyHoneyPot", "trapped"); 
    }
    ```

    So whenever the honeypot textbox is filled in, the comment gets an extended attribute named `GotchaInMyHoneyPot`.

Now this new form must be used on the actual page. There’s only one page (per theme), which allows visitors to leave comments, which is `post.aspx`. Unfortunately, this must be done for every theme.

So open `post.aspx` and replace the original `WeblogPostCommentForm` with our new one, add the `HoneyPotTextBoxId` attribute to the form, and add the textbox. Don’t forget to use the same id for the textbox (this example uses `tbBody`, which shouldn’t ring a bell for the spammer.) Here’s the modified form declaration from the PaperClip theme:

``` xml
<tfr:HoneyPotWeblogPostCommentForm runat="server" ValidationGroup="CreateCommentForm" 
    MessageTextBoxId="tbComment" 
    NameTextBoxId="tbName" 
    RememberCheckboxId="chkRemember" 
    SubjectTextBoxId="tbTitle" 
    SubmitButtonId="btnSubmit" 
    UrlTextBoxId="tbUrl" 
    ControlIdsToHideFromRegisteredUsers="RememberWrapper" 
    HoneyPotTextBoxId="tbBody" 
    > 
    <SuccessActions> 
        <CSControl:GoToModifiedUrlAction runat="server" QueryStringModification="CommentPosted=true" TargetLocationModification="commentmessage" /> 
    </SuccessActions> 
    <FormTemplate> 
        <fieldset id="commentform"> 
        <legend><CSControl:ResourceControl runat="server" ResourceName="Weblog_CommentForm_WhatDoYouThink" id="rc_think"/></legend> 
            <p /> 
            <div><CSControl:FormLabel runat="server" ResourceName="Title" LabelForId="tbTitle" /> <em>(<CSControl:ResourceControl runat="server" ResourceName="Required"/>)</em><asp:RequiredFieldValidator runat="server" ErrorMessage="*" ControlToValidate="tbTitle" ValidationGroup="CreateCommentForm" /></div> 
            <div><asp:TextBox id="tbTitle" runat="server" CssClass="smallbox" ValidationGroup="CreateCommentForm" /></div> 
            <p /> 
            <div id="NameTitle" runat="server"><CSControl:FormLabel LabelForId="tbName" runat="server" ResourceName="Weblog_CommentForm_Name" /> <em>(<CSControl:ResourceControl runat="server" ResourceName="Required" />)</em><asp:RequiredFieldValidator runat="server" ErrorMessage="*" ControlToValidate="tbName" ValidationGroup="CreateCommentForm" /></div> 
            <div id="NameDesc" runat="server"><asp:TextBox id="tbName" runat="server" CssClass="smallbox" ValidationGroup="CreateCommentForm" /></div> 
            <p /> 
            <div><CSControl:FormLabel runat="server" LabelForId="tbUrl" ResourceName="Weblog_CommentForm_YourUrl" /> <em>(<CSControl:ResourceControl runat="server" ResourceName="Optional" /></em>)</div> 
            <div><asp:TextBox id="tbUrl" runat="server" CssClass="smallbox" ValidationGroup="CreateCommentForm" /></div> 
            <%-- the honeybot textbox --%> 
            <asp:TextBox id="tbBody" runat="server" CssClass="smallbox" ValidationGroup="CreateCommentForm" /> 
            <p /> 
            <div><CSControl:FormLabel LabelForId="tbComment" runat="server" ResourceName="Weblog_CommentForm_Comments" /> <em>(<CSControl:ResourceControl runat="server" ResourceName="Required" />)</em><asp:RequiredFieldValidator runat="server" ErrorMessage="*" ControlToValidate="tbComment" ValidationGroup="CreateCommentForm" /></div> 
            <div><asp:TextBox id="tbComment" runat="server" Rows="5" Columns="25" TextMode="MultiLine" ValidationGroup="CreateCommentForm" /></div> 
            <asp:PlaceHolder runat="server" id="RememberWrapper"> 
                <p /> 
                <div><asp:CheckBox id="chkRemember" runat="server" Text="Remember Me?" ValidationGroup="CreateCommentForm"></asp:CheckBox></div> 
            </asp:PlaceHolder> 
            <p /> 
            <asp:Button id="btnSubmit" runat="server" Text="Submit" ValidationGroup="CreateCommentForm"></asp:Button> 
        </fieldset> 
    </FormTemplate> 
</tfr:HoneyPotWeblogPostCommentForm>
```

But that’s only the first half. Now whenever the honeypot field is filled with some text the comment will have an extended attribute `GotchaInMyHoneyPot`.

The second step is to give the comment “spam points”, which is done by a CS spam rule. [Keyvan Nayyeri](http://nayyeri.net/) published a [complete tutorial](http://nayyeri.net/archive/2006/09/15/CS-Dev-Guide_3A00_-How-to-Write-a-Spam-Rule.aspx) how to write your own spam rules, so I won’t get into details. Here’s the complete code for the new rule:

``` csharp
public class HoneyPotRule : BlogSpamRule { 
    private static readonly Guid _ruleId = new Guid("57E216D4-D100-468d-BB37-1B7A0A103CEF"); 
    private const int _defaultPoints = 10; 

    public override ArrayList GetAvailableSettings() { 
        ArrayList list = new ArrayList(); 
        list.Add(new RuleSetting(_ruleId, "points", "Points", _defaultPoints.ToString())); 
        return list; 
    } 
    
    public override int CalculateSpamScore(WeblogPost weblogPost, CSPostEventArgs e) { 
        if (weblogPost.BlogPostType == BlogPostType.Comment) { 
            if (!String.IsNullOrEmpty(weblogPost.GetExtendedAttribute("GotchaInMyHoneyPot"))) { 
                EventLogs.Info("A spammer fell for the honey pot", "Spam Rules", 0); 
                return Globals.SafeInt(GetSettingValue("points"), _defaultPoints); 
            } 
        } 

        return base.CalculateSpamScore(weblogPost, e); 
    } 

    public override string Name { 
        get { return "HoneyPot"; } 
    } 

    public override string Description { 
        get { return "HoneyPot description"; } 
    } 

    public override Guid RuleID { 
        get { return _ruleId; } 
    } 
}
```

I’m running this solution for a couple of days now on my site, and it works pretty well. It’s amazing how many spam bots fill each and every textbox they can find. But I admit that a lot of steps are involved in my solution, there’s lot of programming required. However, I decided against publishing an all-inclusive package, because I’d like to add this solution to next release of either the [CSMVP CSModules](http://www.codeplex.com/CSModulesRepository) or [Community Server Stuff](http://www.codeplex.com/csstuff). So either follow my instructions above, wait for an official release, or leverage [Phil](http://haacked.com/)’s honeypot control which is part of the [Subkismet](http://www.codeplex.com/subkismet) project (not released yet too, but you can already get the sources.)

