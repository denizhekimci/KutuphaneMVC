using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityDataModelBookstore.Models;

namespace EntityDataModelBookstore
{
    public partial class Books : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["catid"] != null)
            {
                int id = int.Parse(Request.QueryString["catid"].ToString());
                LoadBooks(id);
            }
            else
            {
                LoadBooks();
            }
        }

        private void LoadBooks(int id)
        {
            using (dbModelContainer db = new dbModelContainer())
            {
                var books = db.Book.Where(i=>i.Id==id).ToList();
                BookList.DataSource = books;
                BookList.DataBind();
            }
        }

        private void LoadBooks()
        {
            using (dbModelContainer db = new dbModelContainer())
            {
                var books = db.Book.ToList();
                BookList.DataSource = books;
                BookList.DataBind();
            }
        }
    }
}