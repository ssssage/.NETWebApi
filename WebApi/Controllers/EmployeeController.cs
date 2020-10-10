using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();
            const string query = "Select EmployeeID, EmployeeName, Department, MailID, DOJ FROM dbo.Employees";
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BestEmployeeAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);

        }

        public string Post(Employee employee)
        {
            try
            {
                DataTable table = new DataTable();
                string query = "insert into dbo.Employees Values('" + employee.EmployeeName + "','" + employee.Department + "','" + employee.MailID + "','" + employee.DOJ + "')";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BestEmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Added Successfully";
            }
            catch (Exception)
            {

                return "Failed To Add";
            }
        }


        public string Put(Employee employee)
        {
            try
            {
                DataTable table = new DataTable();
                string query = "update dbo.Employees SET Department = '" + employee.Department + "' Where EmployeeID = '" + employee.EmployeeID + "' ";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BestEmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Updated Successfully";
            }
            catch (Exception)
            {

                return "Failed to Update";
            }
        }

        public string Delete(int id)
        {
            try
            {
                DataTable table = new DataTable();
                string query = "delete from dbo.Employees Where EmployeeID = " + id;

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BestEmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Record Deleted Successfully";
            }
            catch (Exception)
            {

                return "Failed to Delete";
            }
        }
    }
}
