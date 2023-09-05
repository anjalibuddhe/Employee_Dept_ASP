using System.Data.SqlClient;

namespace EmployeecurdASP.Models

{
    public class DeparmentCurd
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;

        public DeparmentCurd(IConfiguration configuration) {

            this.configuration = configuration;
            con= new SqlConnection(this.configuration.GetConnectionString("DbConnection"));
        }
        public IEnumerable<Department> GetDepartments()
        {
            List<Department> list = new List<Department>();
            string qry = "select * from Department";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Department dept = new Department();
                    dept.DId = Convert.ToInt32(dr["did"]);
                    dept.Dname = dr["dname"].ToString();
                    list.Add(dept);
                }
            }
            con.Close();
            return list;
        }
        public Department GetDepartmentById(int id)
        {
            Department dept = new Department();
            string qry = "select * from Department where did=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    dept.DId = Convert.ToInt32(dr["did"]);
                    dept.Dname = dr["dname"].ToString();
                }
            }
            con.Close();
            return dept;
        }
        public int AddDepartment(Department dept)
        {
            int result = 0;
            string qry = "insert into Department values(@dname)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@dname", dept.Dname);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;

        }
        public int UpdateDepartment(Department dept)
        {
            int result = 0;
            string str = "update Department set dname=@dname where did=@did";
            cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@dname", dept.Dname);
            cmd.Parameters.AddWithValue("@did", dept.DId);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteDepartment(int did)
        {
            int result = 0;
            string str = "delete from  Department where did=@did";
            cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@did",did );
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }




    }
}
