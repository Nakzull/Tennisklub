using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tennisklub
{
    public partial class AddUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TilføjSpillerKnap_Click(object sender, EventArgs e)
        {
            //Her oprettes den class der skal bruges til at kommunikere med databasen.
            SqlConnection sqlCon = null;
            //Her oplyser jeg hvilken database der skal kommunikeres med.
            String SqlconString = ConfigurationManager.ConnectionStrings["Tennisklubben"].ConnectionString;
            bool check = false;
            int alder = Convert.ToInt32(Alder.Text);

            //Validering af bruger input før der sendes noget til databasen.
            if (alder > 0 && alder < 130)
            {
                if (Email.Text.Contains("@") && Email.Text.Contains("."))
                {
                    if (Telefon.Text.Length > 7 && Telefon.Text.Length < 21)
                    {
                        check = true;
                    }
                }
            }

            //Validering omkring om felterne er tomme.
            if (Fornavn.Text.Length <= 0)
                check = false;
            if (Efternavn.Text.Length <= 0)
                check = false;
            if (Adresse.Text.Length <= 0)
                check = false;
            if (Indmeldelsesdato.SelectedDate == null)
                check = false;

            //Hvis valideringen går igennem oprettes der forbindelse til databasen, og der benyttes parametre og en stored procedure til at overføre de indtastede data til databasen.
            if (check == true)
            {
                using (sqlCon = new SqlConnection(SqlconString))
                {
                    sqlCon.Open();
                    SqlCommand sql_cmnd = new SqlCommand("TilføjSpiller", sqlCon);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;
                    sql_cmnd.Parameters.AddWithValue("@Fornavn", SqlDbType.NVarChar).Value = Fornavn.Text;
                    sql_cmnd.Parameters.AddWithValue("@Efternavn", SqlDbType.NVarChar).Value = Efternavn.Text;
                    sql_cmnd.Parameters.AddWithValue("@Adresse", SqlDbType.NVarChar).Value = Adresse.Text;
                    sql_cmnd.Parameters.AddWithValue("@Telefon", SqlDbType.NVarChar).Value = Telefon.Text;
                    sql_cmnd.Parameters.AddWithValue("@Email", SqlDbType.NVarChar).Value = Email.Text;
                    sql_cmnd.Parameters.AddWithValue("@Indmeldelsesdato", SqlDbType.Date).Value = Indmeldelsesdato.SelectedDate;
                    sql_cmnd.Parameters.AddWithValue("@Alder", SqlDbType.Int).Value = Alder.Text;
                    sql_cmnd.ExecuteNonQuery();
                    sqlCon.Close();
                }
            }
        }
    }
}