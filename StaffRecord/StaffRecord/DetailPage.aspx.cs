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
        List<StaffRecord.Employee> dataInsessionList;
        protected void Page_Load(object sender, EventArgs e)
        {
           
         
            
            string idStr = Session["id"].ToString();
            int id = Convert.ToInt32(idStr);

            dataInSession = Session["staffData"];
            dataInsessionList = (List<StaffRecord.Employee>)dataInSession;
            var employee = from emp in dataInsessionList
                           where emp.Id == id
                           select emp;
            Employee empd = employee.First<Employee>();
            employeeDetails = new List<Employee>() { empd };
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
            int id = Convert.ToInt32(idStr);

            dataInSession = Session["staffData"];
            dataInsessionList = (List<StaffRecord.Employee>)dataInSession;

            dataInsessionList.Where(w => w.Id == id).ToList().ForEach(i =>
           { i.Name = name.Text;
               i.Role = role.Text;
               i.Salary = Convert.ToDouble(salary.Text);
               i.Address = address.Text;

           });

            var employee = from emp in dataInsessionList
                           where emp.Id == id
                           select emp;

            Employee updatingEmpolyee = employee.First<Employee>();

            Session["staffData"] = dataInsessionList;
            employeeDetails = new List<Employee>() { updatingEmpolyee };
            detailGrid.EditIndex = -1;
            detailGrid.DataSource = employeeDetails;
            detailGrid.DataBind();




        }

        protected void detailGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string idL = Session["id"].ToString();

            int id = Convert.ToInt32(idL);
            dataInSession = Session["staffData"];
            dataInsessionList = (List<Employee>)dataInSession;
            dataInsessionList.RemoveAll(s => s.Id == id);
            DeleteNote.Text = "Deleted Successfully";
            Session["staffData"] = dataInsessionList;
            detailGrid.Visible = false;
            


            //DeleteNote
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("staffList.aspx");
        }

        protected void detailGrid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}