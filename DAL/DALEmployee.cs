using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class DALEmployee
    {
        public string con123 = @"Data Source=(DESKTOP-H3R9HVQ);Initial Catalog=traing18;
                    Integrated Security=SSPI;
                    User ID = ;
                    Password = ;";
        public string insertEmp(BEEmployee objBEEmp)
        {

            try
            {
                string strEmployeeId = objBEEmp.strEmployeeId;

                string strFirstName = objBEEmp.strFirstName;
                string strLastName = objBEEmp.strLastName;
                string strSalary = objBEEmp.strSalary;
                string strDept = objBEEmp.strDept;

                SqlConnection connection = new SqlConnection(con123);
                connection.Open();

                string query = "select count(*) from employee where EmpId='" + strEmployeeId + "'";
                SqlCommand selcmd = new SqlCommand(query, connection);
                int records = Convert.ToInt16(selcmd.ExecuteScalar());
                // int records = 0;

                if (records == 0)
                {

                    string insQuery = "insert into Employee (EmpId, EmpFirstName,EmpLastName , Salary, DeptId) values ('" + strEmployeeId + "', '" + strFirstName + "', ' " + strLastName + "', '" + strSalary + "', '" + strDept + "')";

                    SqlCommand cmdInsert = new SqlCommand(insQuery, connection);

                    cmdInsert.ExecuteNonQuery();
                    return "Inserted successfully";

                }
                else
                {
                    return "Duplicate Data";

                }
                connection.Close();


            }
            catch (Exception ex1)
            {
                return "Error : " + ex1.Message;

            }

        }


        public string updateEmp(BEEmployee  objBEEmp)
        {

            try
            {
                string strEmployeeId = objBEEmp.strEmployeeId;

                string strFirstName = objBEEmp.strFirstName;
                string strLastName = objBEEmp.strLastName;
                string strSalary = objBEEmp.strSalary;
                string strDept = objBEEmp.strDept;

                SqlConnection connection = new SqlConnection(con123);
                connection.Open();

                string query = "select count(*) from employee where EmpId='" + strEmployeeId + "'";
                SqlCommand selcmd = new SqlCommand(query, connection);
                int records = Convert.ToInt16(selcmd.ExecuteScalar());
                // int records = 0;

                if (records > 0)
                {

                  string updQuery = "update Employee set EmpFirstName = '" + strFirstName + "',EmpLastName = '" + strLastName + "', salary = '" + strSalary + "' where  EmpId = '" + strEmployeeId + "' ";

                    SqlCommand cmdUpdate = new SqlCommand(updQuery, connection);

                    cmdUpdate.ExecuteNonQuery();
                    return "Updated successfully";
                    
                }
                else
                {
                    return "No Data Available";
                    
                }
                connection.Close();


            }
            catch (Exception ex1)
            {
                return "Error : " + ex1.Message;

            }

        }


    }
}
