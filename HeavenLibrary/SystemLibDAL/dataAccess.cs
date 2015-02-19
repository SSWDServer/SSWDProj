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
        public static List<AuthorDTO> getAuthors()
        {
            string SQL = "SELECT * FROM AUTHOR";
            List<AuthorDTO> authorList = new List<AuthorDTO>();
            SqlConnection con = new SqlConnection(@"Data Source=TESTSERVER\SQLEXPRESS;Initial Catalog=library;Integrated Security=True");
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
