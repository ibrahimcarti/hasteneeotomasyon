using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class RandevuDal : IRandevuDal
    {
        private string server = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\İbrahim\\Desktop\\GörselFinal\\HastaneVeriTabanı.mdb;";
        public void Add(Randevu randevu)
        {
            using (OleDbConnection connection = new OleDbConnection(server))
            {
                connection.Open();

                //string check = "SELECT COUNT(*) FROM Randevular";
                //OleDbCommand cmd = new OleDbCommand(check, connection);
                //int count = (int)cmd.ExecuteScalar();

                //if (count == 0)
                //    randevu.randevu_id = 1;

                string query = "INSERT INTO Randevular (hasta_id, randevu_tarih, randevu_brans, doktor_id) VALUES (@hastaid, @randevutarih, @randevubrans, @id)";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@hastaid", randevu.hasta_id);
                    command.Parameters.AddWithValue("@randevutarih", randevu.randevu_tarih);
                    command.Parameters.AddWithValue("@randevubrans", randevu.randevu_brans);
                    command.Parameters.AddWithValue("@id", randevu.doktor_id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
