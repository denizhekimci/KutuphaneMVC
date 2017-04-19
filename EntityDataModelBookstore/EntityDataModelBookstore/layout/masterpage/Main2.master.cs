using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityDataModelBookstore.Models;

namespace EntityDataModelBookstore.layout.masterpage
{
    public partial class Main2 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategories();
            }
        }

        private void LoadCategories()
        {
            using (dbModelContainer db = new dbModelContainer())
            {
                var categories = db.Category.ToList();
                CategoryList.DataSource = categories;
                CategoryList.DataBind();
            }
        }
    }
}