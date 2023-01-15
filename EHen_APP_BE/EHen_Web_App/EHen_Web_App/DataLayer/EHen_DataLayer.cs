using EHen_Web_App.Model;
using System.Data;
using System.Data.SqlClient;

namespace EHen_Web_App.DataLayer
{
    public class EHen_DataLayer
    {
        String ConnectionString = "data source=LAPTOP-Q3E3C9NA;initial catalog=EHen_DB;trusted_connection=true";
        public DataTable Pindex_DL()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConnectionString;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Get_Price_index", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

            }

            finally { con.Close(); }
            return dt;
        }



        public int Edit_Pindex_DL(int ID,double Price)
        {
            int rowsAffected = 0;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConnectionString;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Edit_price_index", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@price", SqlDbType.VarChar).Value = Price;
                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = ID;

                 rowsAffected = cmd.ExecuteNonQuery(); 
            }

            finally { con.Close(); }
            return rowsAffected;
        }


        public DataSet Get_Hens_detail_DL(string Date=null)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConnectionString;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Get_Hens_Detail", con);
                cmd.CommandType = CommandType.StoredProcedure;

                if(Date != null)
                {
                    cmd.Parameters.Add("@Date", SqlDbType.Date).Value = Date;
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

            }

            finally { con.Close(); }

            return ds;


        }

        public int Add_Hens_DL (int Hierarchy_level, int Hen_count,bool New_Hierarchy)
        {
            int rowsAffected = 0;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConnectionString;
            string Stored_procedure_name = "";
            try
            {
                con.Open();
                if (New_Hierarchy == true)
                    Stored_procedure_name = "Edit_Hens_table_with_New_Hierarchy";
                else
                    Stored_procedure_name = "Add_Hens";

                SqlCommand cmd = new SqlCommand(Stored_procedure_name, con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Hierarchy_level", SqlDbType.VarChar).Value = Hierarchy_level;
                cmd.Parameters.Add("@Hen_count", SqlDbType.VarChar).Value = Hen_count;

                rowsAffected = cmd.ExecuteNonQuery();
            }

            finally { con.Close(); }
            return rowsAffected;
        }

        public int Edit_Hens_DL(int Hierarchy_level, int Hen_id,int Egg_count=0)
        {
            int rowsAffected = 0;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConnectionString;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Edit_hens", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Hierarchy_level", SqlDbType.VarChar).Value = Hierarchy_level;
               
                cmd.Parameters.Add("@Hen_ID", SqlDbType.VarChar).Value = Hen_id;

                if(Egg_count!=0)
                    cmd.Parameters.Add("@Egg_num", SqlDbType.VarChar).Value = Egg_count;

                rowsAffected = cmd.ExecuteNonQuery();
            }

            finally { con.Close(); }
            return rowsAffected;
        }
    }
}
