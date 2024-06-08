using Crud_Project.Model;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Crud_Project.DB
{
    public class DBRegister
    {
        String con;
        public void connectionString(String conn)
        {
            con = conn;
        }
        public String Post(ModelRegister reg,String con)
        {
            String Results;
            try
            {
                SqlConnection sql = new SqlConnection(con);
                sql.Open();
                SqlCommand cmd = new SqlCommand("proc_Register", sql);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", reg.Name.ToString());
                cmd.Parameters.AddWithValue("@Id", reg.Id.ToString());
                cmd.Parameters.AddWithValue("@Mobile_No", reg.Mobile_No.ToString());
                cmd.Parameters.AddWithValue("@Email", reg.Email.ToString());
                cmd.Parameters.AddWithValue("@Gender", reg.Gender.ToString());
                cmd.Parameters.AddWithValue("@UserName", reg.UserName.ToString());
                cmd.Parameters.AddWithValue("@Password", reg.Password.ToString());
                cmd.Parameters.AddWithValue("@UserType", reg.UserType.ToString());
                cmd.Parameters.AddWithValue("@Type", "I");
                cmd.Parameters.Add("@Result", SqlDbType.NVarChar, 400).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Results = cmd.Parameters["@Result"].Value.ToString();
                sql.Close();
               
            }
            catch(Exception ex)
            {
                Results = ex.Message;
            }
             return Results; ;
        }

        public String Put(ModelRegister reg, String con,int Id)
        {
            String Results;
            try
            {
                SqlConnection sql = new SqlConnection(con);
                sql.Open();
                SqlCommand cmd = new SqlCommand("proc_Register", sql);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@Name", reg.Name.ToString());
                cmd.Parameters.AddWithValue("@Mobile_No", reg.Mobile_No.ToString());
                cmd.Parameters.AddWithValue("@Email", reg.Email.ToString());
                cmd.Parameters.AddWithValue("@Gender", reg.Gender.ToString());
                cmd.Parameters.AddWithValue("@UserName", reg.UserName.ToString());
                cmd.Parameters.AddWithValue("@Password", reg.Password.ToString());
                cmd.Parameters.AddWithValue("@UserType", reg.UserType.ToString());
                cmd.Parameters.AddWithValue("@Type", "U");
                cmd.Parameters.Add("@Result", SqlDbType.NVarChar, 400).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Results = cmd.Parameters["@Result"].Value.ToString();
                sql.Close();

            }
            catch (Exception ex)
            {
                Results = ex.Message;
            }
            return Results; ;
        }


        public IEnumerable<ModelRegister> getRegisterData()
        {
            List<ModelRegister> list = new List<ModelRegister>();
            SqlConnection sql = new SqlConnection(con);
            sql.Open();
            SqlCommand cmd = new SqlCommand("proc_Register", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@type", "S");
            SqlDataReader sd = cmd.ExecuteReader();
            while (sd.Read())
            {

                ModelRegister md = new ModelRegister();
                md.Name = sd["Name"].ToString();
                md.Mobile_No = sd["Mobile_No"].ToString();
                md.Email = sd["Email"].ToString();
                md.Gender = sd["Gender"].ToString();
                md.UserName = sd["UserName"].ToString();
                md.Password = sd["Password"].ToString();
                md.UserType = sd["UserType"].ToString();
                list.Add(md);
            }
            sql.Close();
            return list.ToArray();
        }


        public String Delete( int Id)
        {
            String Results;
            try
            {
                SqlConnection sql = new SqlConnection(con);
                sql.Open();
                SqlCommand cmd = new SqlCommand("proc_Register", sql);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);              
                cmd.Parameters.AddWithValue("@type", "D");
                cmd.Parameters.Add("@Result", SqlDbType.NVarChar, 400).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Results = cmd.Parameters["@Result"].Value.ToString();
                sql.Close();

            }
            catch (Exception ex)
            {
                Results = ex.Message;
            }
            return Results; ;
        }


    }
}
