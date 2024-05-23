using InterfaceLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess
{
    public class CarNewsDataRemover : ICarNewsDataRemover
    {
        private SqlConnection connectionString;

        public CarNewsDataRemover()
        {
            connectionString = new SqlConnection("Server=mssqlstud.fhict.local;Database=dbi530410_carapp;User Id=dbi530410_carapp;Password=Fontyspass;TrustServerCertificate=True;");
        }

        public void RemoveNews(int NewsId)
        {
            int rows = -1;
            try
            {
                connectionString.Open();
                var sql = "DELETE FROM [dbo].[News] WHERE [NewsId] = @NewsId";
                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@NewsId", NewsId);
                rows = cmd.ExecuteNonQuery();

                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally { connectionString.Close(); }
        }

        public void RemoveComment(int CommentId)
        {
            int rows = -1;
            try
            {
                connectionString.Open();
                var sql = "DELETE FROM [dbo].[Comments] WHERE [CommentId] = @CommentId";
                SqlCommand cmd = new SqlCommand(sql, connectionString);
                cmd.Parameters.AddWithValue("@CommentId", CommentId);
                rows = cmd.ExecuteNonQuery();

                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally { connectionString.Close(); }
        }
    }
}
