using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Drawing;
using BE;
using BL;
namespace WebApplication1
{
    public partial class Employee : System.Web.UI.Page
    {
        private string constr = "Data Source=.;Initial Catalog=traing18;Integrated Security=SSPI;User ID = ;Password = ;";
        private SqlConnection conn12 = new SqlConnection("Data Source=DESKTOP-H3R9HVQ;Initial Catalog=traing18;Integrated Security=SSPI;User ID = ;Password = ;");
        protected void Page_Load(object sender, EventArgs e)
        {

           if (!this.IsPostBack)
            {
                BindGridview();
                pnlGrid.Visible = true;
                pnlForm.Visible = false;
            }
        }

        protected void BindGridview()
        {

            DataSet ds = new DataSet();
            //            string constr = @"Data Source=NITLAP95;Initial Catalog=TestDB;
            //                    Integrated Security=SSPI;
            //                    User ID = sa;
            //                    Password = navayuga;";
            //string constr = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select EmpId, EmpFirstName, EmpLastName , Salary, DeptId from Employee"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvEmployee.DataSource = ds;
                        gvEmployee.DataBind();
                    }
                    con.Close();
                }
            }
        }


        protected void gvEmployee_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmployee.PageIndex = e.NewPageIndex;
            BindGridview();
        }

        protected void lnkView_Click(object sender, EventArgs e)
        {
            lblResult.Text = "";
            GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
            string strEmployeeId = grdrow.Cells[0].Text.Trim();
            string strFirstName = grdrow.Cells[1].Text.Trim();
            string strLastName = grdrow.Cells[2].Text.Trim();
            string strSalary = grdrow.Cells[3].Text.Trim();
            string strDept = grdrow.Cells[4].Text.Trim();

            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeId.Enabled = false;
            txtFirstName.Text = strFirstName;
            txtFirstName.Enabled = false;
            txtLastName.Text = strLastName;
            txtLastName.Enabled = false;
            txtSalary.Text = strSalary;
            txtSalary.Enabled = false;
            txtDept.Text = strDept;
            txtDept.Enabled = false;

            btnSave.Enabled = false;
            btnUpdate.Enabled = false;
            pnlGrid.Visible = false;
            pnlForm.Visible = true;

        }

        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            lblResult.Text = "";
            GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
            string strEmployeeId = grdrow.Cells[0].Text.Trim();
            string strFirstName = grdrow.Cells[1].Text.Trim();
            string strLastName = grdrow.Cells[2].Text.Trim();
            string strSalary = grdrow.Cells[3].Text.Trim();
            string strDept = grdrow.Cells[4].Text.Trim();

            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeId.Enabled = false;
            txtFirstName.Text = strFirstName;
            txtFirstName.Enabled = true;
            txtLastName.Text = strLastName;
            txtLastName.Enabled = true;
            txtSalary.Text = strSalary;
            txtSalary.Enabled = true;
            txtDept.Text = strDept;
            txtDept.Enabled = true;
            btnSave.Enabled = false;
            btnUpdate.Enabled = true;
            pnlGrid.Visible = false;
            pnlForm.Visible = true;
        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            SqlConnection connection = new SqlConnection(constr);

            try
            {
                GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
                string strEmployeeId = grdrow.Cells[0].Text.Trim();

                connection.Open();
                string query = "select count(*) from Employee where EmpId='" + strEmployeeId + "'";
                SqlCommand selcmd = new SqlCommand(query, connection);
                int records = Convert.ToInt16(selcmd.ExecuteScalar());
                if (records > 0)
                {

                    string delQuery = "delete from Employee  where  EmpId = '" + strEmployeeId + "' ";

                    SqlCommand cmdInsert = new SqlCommand(delQuery, connection);

                    cmdInsert.ExecuteNonQuery();
                    lblResult.Text = "Deleted successfully";
                    lblResult.ForeColor = Color.Green;
                }
                else
                {
                    lblResult.Text = "No data available";
                    lblResult.ForeColor = Color.Red;
                }
                connection.Close();


                BindGridview();

            }
            catch (Exception ex)
            {
                lblResult.Text = "Error : " + ex.Message;
                lblResult.ForeColor = Color.Red;

            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                lblResult.Text = "";

                string strEmployeeId = txtEmployeeId.Text.Trim();

                string strFirstName = txtFirstName.Text.Trim();
                string strLastName = txtLastName.Text.Trim();
                string strSalary = txtSalary.Text.Trim();
                string strDept = txtDept.Text.Trim();


                string con123 = @"Data Source=DESKTOP-H3R9HVQ;Initial Catalog=traing18;
                    Integrated Security=SSPI;
                    User ID = ;
                    Password = ;";
                SqlConnection connection = new SqlConnection(con123);
                connection.Open();

                string query = "select count(*) from Employee where EmpId='" + strEmployeeId + "'";
                SqlCommand selcmd = new SqlCommand(query, connection);
                int records = Convert.ToInt16(selcmd.ExecuteScalar());
                // int records = 0;

                if (records == 0)
                {

                    string insQuery = "insert into Employee (EmpId, EmpFirstName,EmpLastName , Salary, DeptId) values ('" + strEmployeeId + "', '" + strFirstName + "', ' " + strLastName + "', '" + strSalary + "', '" + strDept + "')";

                    SqlCommand cmdInsert = new SqlCommand(insQuery, connection);

                    cmdInsert.ExecuteNonQuery();
                    lblResult.Text = "Inserted successfully";
                    lblResult.ForeColor = Color.Green;
                }
                else
                {
                    lblResult.Text = "Duplicate Data";
                    lblResult.ForeColor = Color.Red;
                }
                connection.Close();

                BindGridview();
                pnlGrid.Visible = true;
                pnlForm.Visible = false;
            }
            catch (Exception ex)
            {
                lblResult.Text = "Error : " + ex.Message;
                lblResult.ForeColor = Color.Red;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            try
            {

                string strEmployeeId = txtEmployeeId.Text.Trim();

                string strFirstName = txtFirstName.Text.Trim();

                string strLastName = txtLastName.Text.Trim();
                string strSalary = txtSalary.Text.Trim();
                string strDept = txtDept.Text.Trim();


                string con = @"Data Source=DESKTOP-H3R9HVQ;Initial Catalog=traing18;
                    Integrated Security=SSPI;
                    User ID = ;
                    Password = ;";
                SqlConnection connection = new SqlConnection(con);
                connection.Open();

                string query = "select count(*) from Employee where EmpId='" + strEmployeeId + "'";
                SqlCommand selcmd = new SqlCommand(query, connection);
                int records = Convert.ToInt16(selcmd.ExecuteScalar());


                if (records > 0)
                {

                    string updQuery = "update Employee set EmpFirstName = '" + strFirstName + "',EmpLastName = '" + strLastName + "', salary = '" + strSalary + "' where  EmpId = '" + strEmployeeId + "' ";

                    SqlCommand cmdUpdate = new SqlCommand(updQuery, connection);

                    cmdUpdate.ExecuteNonQuery();
                    lblResult.Text = "Updated successfully";
                    lblResult.ForeColor = Color.Green;
                }
                else
                {
                    lblResult.Text = "No Data Available";
                    lblResult.ForeColor = Color.Red;
                }
                connection.Close();

                BindGridview();
                pnlGrid.Visible = true;
                pnlForm.Visible = false;

            }
            catch (Exception ex)
            {
                lblResult.Text = "Error : " + ex.Message + " - " + ex.StackTrace;
                lblResult.ForeColor = Color.Red;
            }
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            pnlGrid.Visible = false;
            pnlForm.Visible = true;

            btnSave.Enabled = true;
            btnUpdate.Enabled = false;

            clearAll();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clearAll();
            pnlGrid.Visible = true;
            pnlForm.Visible = false;

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void clearAll()
        {
            txtEmployeeId.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtSalary.Text = "";
            txtDept.Text = "";
            lblResult.Text = "";
        }

        protected void btnSave_3_Click(object sender, EventArgs e)
        {
            BEEmployee objBEEmp = new BEEmployee();
            BLEmployee objBLEmp = new BLEmployee();

            objBEEmp.strEmployeeId = txtEmployeeId.Text.Trim();

            objBEEmp.strFirstName = txtFirstName.Text.Trim();

            objBEEmp.strLastName = txtLastName.Text.Trim();
            objBEEmp.strSalary = txtSalary.Text.Trim();
            objBEEmp.strDept = txtDept.Text.Trim();
            string strResult = objBLEmp.insertEmp(objBEEmp);
            lblResult.Text = strResult;


        }

        protected void btnUpdate_3_Click(object sender, EventArgs e)
        {
            BEEmployee objBEEmp = new BEEmployee();
            BLEmployee objBLEmp = new BLEmployee();

            objBEEmp.strEmployeeId = txtEmployeeId.Text.Trim();

            objBEEmp.strFirstName = txtFirstName.Text.Trim();

            objBEEmp.strLastName = txtLastName.Text.Trim();
            objBEEmp.strSalary = txtSalary.Text.Trim();
            objBEEmp.strDept = txtDept.Text.Trim();
            string strResult = objBLEmp.updateEmp(objBEEmp);
            lblResult.Text = strResult;
        }


    }
}