using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EntityDataModelBookstore.layout.masterpage
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string keyword = TxtSearch.Text.Trim();
                string url = String.Format("~/Books.aspx?keyword={0}",keyword);
                Response.Redirect(url);
            }
        }
    }
}