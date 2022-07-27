using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace StaffRecord
{
    public partial class DetailPage : System.Web.UI.Page
    {
        object dataInSession;
        List<Employee> employeeDetails;
        List<Employee> dataInsessionList;
        protected void Page_Load(object sender, EventArgs e)
        {

            
            string idStr = Session["id"].ToString();
            int id = Convert.ToInt32(idStr.Substring(0, idStr.Length - 2));
             dataInSession = Session["staffData"];
             dataInsessionList = (List<Employee>)dataInSession;
             employeeDetails = new List<Employee>() { dataInsessionList[id-1] };
            detailGrid.DataSource = employeeDetails;
            detailGrid.DataBind();
        }

        protected void detailGrid_RowEditing(object sender, GridViewEditEventArgs e)
        {
            detailGrid.EditIndex = e.NewEditIndex;
            detailGrid.DataSource = employeeDetails;
            detailGrid.DataBind();

        }

        protected void detailGrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            detailGrid.EditIndex = -1;
            detailGrid.DataSource = employeeDetails;
            detailGrid.DataBind();

        }

        protected void detailGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label idL = detailGrid.Rows[e.RowIndex].FindControl("IDLabel") as Label;
            TextBox name = detailGrid.Rows[e.RowIndex].FindControl("NameBox") as TextBox;
            TextBox role = detailGrid.Rows[e.RowIndex].FindControl("RoleBox") as TextBox;
            TextBox salary = detailGrid.Rows[e.RowIndex].FindControl("SalaryBox") as TextBox;
            TextBox address = detailGrid.Rows[e.RowIndex].FindControl("AddressBox") as TextBox;


            string idStr = Convert.ToString(idL.Text);
            int id = Convert.ToInt32(idStr.Substring(0, idStr.Length - 2));

            dataInSession = Session["staffData"];
            dataInsessionList = (List<Employee>)dataInSession;
            dataInsessionList = (List<Employee>)dataInSession;
            Employee updatingEmpolyee = dataInsessionList[id - 1];
            try
            {
            updatingEmpolyee.Name = name.Text;
            updatingEmpolyee.Role = role.Text;
            updatingEmpolyee.Salary = Convert.ToDouble(salary.Text);
            updatingEmpolyee.Address = address.Text;
            }
            catch
            {
                double orgSalary = 9;
            }
            

            dataInsessionList[id - 1] = updatingEmpolyee;
            Session["staffData"] = dataInsessionList;
            employeeDetails = new List<Employee>() { updatingEmpolyee };
            detailGrid.EditIndex = -1;
            detailGrid.DataSource = employeeDetails;
            detailGrid.DataBind();




        }

        protected void detailGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}