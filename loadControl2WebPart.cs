[ToolboxItemAttribute(false)]
public class VisualWebPart1 : WebPart
{
    private const string _ascxPath = @"~/_CONTROLTEMPLATES/CS/VisualWebPart1/VisualWebPart1UserControl.ascx";

    public VisualWebPart1()
    {
    }

    protected override void CreateChildControls()
    {
        Control control = this.Page.LoadControl(_ascxPath);
        Controls.Add(control);
        base.CreateChildControls();
    }

    protected override void RenderContents(HtmlTextWriter writer)
    {
        base.RenderContents(writer);
    }
    
}
