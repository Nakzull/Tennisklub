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
    public partial class Kreditkort : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Her oprettes den class der skal bruges til at kommunikere med databasen.
            SqlConnection sqlCon = null;
            //Her oplyser jeg hvilken database der skal kommunikeres med.
            String SqlconString = ConfigurationManager.ConnectionStrings["Tennisklubben"].ConnectionString;
            string kortnummer = Kortnummer.Text;           
            Kortvalidering kortvalidering = new Kortvalidering();
            bool check = false;

            //Her validerers det hvorvidt det indtaste kortnummer er gyldigt.
            char kontrolciffer = kortvalidering.KontrolCiffer(kortnummer);
            kortnummer = kortvalidering.FjernKontrolCiffer(kortnummer);
            kortnummer = kortvalidering.VendNummer(kortnummer);
            kortnummer = kortvalidering.NummerDoubler(kortnummer);
            check = kortvalidering.SidsteCheck(kortnummer, kontrolciffer);

            //Validering af bruger input før der sendes noget til databasen.
            if (Udløbsdato.SelectedDate <= DateTime.Now)
            {
                check = true;
            }

            //Validering omkring om felterne er tomme.
            if (Navn.Text.Length <= 0)
                check = false;
            if (Kortnummer.Text.Length <= 0)
                check = false;
            if (Udløbsdato.SelectedDate == null)
                check = false;

            //Hvis valideringen går igennem oprettes der forbindelse til databasen, og der benyttes parametre og en stored procedure til at overføre de indtastede data til databasen.
            if (check == true)
            {
                using (sqlCon = new SqlConnection(SqlconString))
                {
                    sqlCon.Open();
                    SqlCommand sql_cmnd = new SqlCommand("TilføjKort", sqlCon);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;
                    sql_cmnd.Parameters.AddWithValue("@Navn", SqlDbType.NVarChar).Value = Navn.Text;
                    sql_cmnd.Parameters.AddWithValue("@Kortnummer", SqlDbType.NVarChar).Value = Kortnummer.Text;
                    sql_cmnd.Parameters.AddWithValue("@UdløbsdatoÅr", SqlDbType.Date).Value = Udløbsdato.SelectedDate.Year;
                    sql_cmnd.Parameters.AddWithValue("@UdløbsdatoMåned", SqlDbType.Date).Value = Udløbsdato.SelectedDate.Month;
                    sql_cmnd.ExecuteNonQuery();
                    sqlCon.Close();
                }
            }
        }
    }
}