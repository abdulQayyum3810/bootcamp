using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace StaffRecord
{
    
    public partial class StaffList : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            
                staffList.DataSource = Session["staffData"];
                staffList.DataBind();
            
        }
        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(staffList, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }
        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            string id = staffList.SelectedRow.Cells[0].Text;
            Session["id"] = id;
            Response.Redirect("DetailPage.aspx");
        }

        protected void staffList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            staffList.PageIndex = e.NewPageIndex;
            this.DataBind();
        }
    }
}