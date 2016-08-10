using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.ComponentModel;

namespace CompareValidatorHelper
{
    [DefaultProperty("Value"), ValidationProperty("Value"), ToolboxData("<{0}:VHiddenField runat=server></{0}:VHiddenField>")]

    public class VHiddenField : System.Web.UI.WebControls.HiddenField
    {
    }
}