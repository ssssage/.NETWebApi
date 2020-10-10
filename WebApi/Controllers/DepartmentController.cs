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
    public class DepartmentController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();
            const string query = "select DepartmentID, DepartmentName from dbo.Departments";
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BestEmployeeAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);

        }

        public string Post(Department departmet)
        {
            try
            {
                DataTable table = new DataTable();
                 string query = "insert into dbo.Departments Values ('" + departmet.DepartmentName + "')";
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

                return "Failed to Add";
            }
        }

        public string Put(Department departmet)
        {
            try
            {
                DataTable table = new DataTable();
                string query = "update dbo.Departments SET DepartmentName = '" + departmet.DepartmentName + "' Where DepartmentID = '" + departmet.DepartmentID + "' ";
                    
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
                string query = "delete from dbo.Departments Where DepartmentID = " + id;

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
