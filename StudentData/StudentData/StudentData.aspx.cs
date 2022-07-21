using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

namespace StudentData
{
    public class Student
    {
        public int RollNo { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
    }
    public partial class StudentData : System.Web.UI.Page
    {
        protected static List<Student> studentList;
        protected void Page_Load(object sender, EventArgs e)
        {
            var s1 = new Student() { RollNo = 1, Name = "Abdullah", Department = "Mechatronics" };
            var s2 = new Student() { RollNo = 2, Name = "Ahmad", Department = "Electrical" };
            var s3 = new Student() { RollNo = 3, Name = "Fuqan", Department = "Electrical" };
            var s4 = new Student() { RollNo = 4, Name = "Khuram", Department = "Computer Science" };
            var s5 = new Student() { RollNo = 5, Name = "Abdul Qayyum", Department = "Mechatronics" };
            var s6 = new Student() { RollNo = 6, Name = "Shahbaz", Department = "Civil" };
            var s7 = new Student() { RollNo = 7, Name = "Daim", Department = "IT" };
            var s8 = new Student() { RollNo = 8, Name = "Huzaifa", Department = "Automation" };

            studentList = new List<Student>() { s1, s2, s3, s4, s5, s6, s7, s8 };
            StudentListDropDown.DataSource = studentList;
            StudentListDropDown.DataTextField = "Name";
            StudentListDropDown.DataValueField = "RollNo";
            StudentListDropDown.DataBind();

        }
        [WebMethod]
        public static Student GetStudentData(string rollNo)
        {
            foreach (var student in studentList)
            {
                if (student.RollNo == Convert.ToInt32(rollNo))
                {
                    return student;
                }
            }
            return new Student();
        }
    }
}