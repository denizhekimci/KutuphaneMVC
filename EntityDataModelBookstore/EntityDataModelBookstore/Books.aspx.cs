using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityDataModelBookstore.Models;
using System.Data.Sql;
using System.Data.Entity;
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
            else if(Request.QueryString["keyword"] != null)
            {
                string keyword = Request.QueryString["keyword"].ToString();
                LoadBooks(keyword);
            }
            else
            {
                LoadBooks();
            }
        }

        private void LoadBooks(string keyword)
        {
            using(dbModelContainer db = new dbModelContainer())
            {
                var books = (from i in db.Book
                             where i.BookName.Contains(keyword) || i.Description.Contains(keyword)
                             select i).ToList();
                BookList.DataSource = books;
                BookList.DataBind();
            }
        }

        private void LoadBooks(int id)
        {
            using (dbModelContainer db = new dbModelContainer())
            {
                var books = from c in db.Category.Where(c => c.Category_Book.Any())
                            from cb in db.Category_Book.Where(cb => cb.CategoryId.Equals(c.Id))
                            from b in db.Book.Where(b=>b.Id.Equals(cb.BookId))
                            where c.Id == id
                            select new { b.BookName, b.Price, b.Image };

                BookList.DataSource = books.ToList();
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