using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemLibDTO;
using System.Data.SqlClient;

namespace SystemLibDAL
{
    public class dataAccess
    {
        public static AuthorDTO getAuthor(int aId)
        {
            AuthorDTO dto = null;
            string _connectionString = DataSource.GetConnectionString("AdminConnection");
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM author WHERE aid = " + Convert.ToString(aId) + ";", con);
            try
            {
                con.Open();
                SqlDataReader dar = cmd.ExecuteReader();
                if (dar.Read())
                {
                    dto = new AuthorDTO();
                    dto._aId = (int)dar["Aid"];
                    dto._lastName = dar["LastName"] as string;
                    dto._firstName = dar["FirstName"] as string;
                    dto._birthYear = (dar["BirthYear"] == DBNull.Value) ? 0 : Convert.ToInt32(dar["BirthYear"].ToString());
                }
            }
            catch (Exception eObj)
            {
                throw eObj;
            }
            finally
            {
                con.Close();
            }
            return dto;
        }

        public static List<AuthorDTO> getAuthors()
        {
            string SQL = "SELECT * FROM AUTHOR";
            List<AuthorDTO> authorList = new List<AuthorDTO>();
            string _connectionString = DataSource.GetConnectionString("AdminConnection");
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand(SQL, con);
            try
            {
                con.Open();
                SqlDataReader dar = cmd.ExecuteReader();
                while (dar.Read())
                {
                    AuthorDTO aDTO = new AuthorDTO();
                    aDTO._aId = Convert.ToInt32(dar["Aid"] as string);
                    authorList.Add(aDTO);
                }
            }
            catch (Exception er)
            {
                throw er;
            }
            finally
            {
                con.Close();
            }
            return authorList;
        }
    }
}
