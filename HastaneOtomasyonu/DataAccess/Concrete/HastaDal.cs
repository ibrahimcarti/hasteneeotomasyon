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
    public class HastaDal : IHastaDal

    {
        private string server = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\İbrahim\\Desktop\\GörselFinal\\HastaneVeriTabanı.mdb;";
        public void Add(Hasta hasta)
        {
            using (OleDbConnection connection = new OleDbConnection(server))
            {
                connection.Open();

                string check = "SELECT COUNT(*) FROM Hastalar";
                OleDbCommand cmd = new OleDbCommand(check, connection);
                int count = (int)cmd.ExecuteScalar();

                if (count == 0)
                    hasta.hasta_id = 1;

                string query = "INSERT INTO Hastalar (hasta_adi, hasta_soyadi, hasta_tel, hasta_gittigibolum) VALUES (@hastaadi, @hastasoyadi, @hastatel, @hastagittigibolum)";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@hastaadi", hasta.hasta_adi);
                    command.Parameters.AddWithValue("@hastasoyadi", hasta.hasta_soyadi);
                    command.Parameters.AddWithValue("@hastatel", hasta.hasta_tel);
                    command.Parameters.AddWithValue("@hastagittigibolum", hasta.hasta_gittigibolum);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int hasta_id)
        {
            using (OleDbConnection connection = new OleDbConnection(server))
            {
                connection.Open();
                string query = "Delete from Hastalar  WHERE hasta_id = @id";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", hasta_id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Hasta> GetAllHasta()
        {
            using (OleDbConnection connection = new OleDbConnection(server))
            {
                connection.Open();
                string query = "Select * from Hastalar";
                List<Hasta> hastalistesi = new List<Hasta>();
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    OleDbDataReader getir = command.ExecuteReader();
                    while (getir.Read())
                    {
                        Hasta hasta = new Hasta();
                        hasta.hasta_id = int.Parse(getir[0].ToString());
                        hasta.hasta_adi = getir[1].ToString();
                        hasta.hasta_soyadi = getir[2].ToString();
                        hasta.hasta_tel = getir[3].ToString();
                        hasta.hasta_gittigibolum = getir[4].ToString();
                        hastalistesi.Add(hasta);
                    }
                    return hastalistesi;
                }
            }
        }

        public void Update(Hasta hasta)
        {
            using (OleDbConnection connection = new OleDbConnection(server))
            {
                connection.Open();

                string query = "UPDATE Hastalar SET hasta_adi = @hastaadi, hasta_soyadi = @hastasoyadi, hasta_tel= @hastatel, hasta_gittigibolum = @hastagittigibolum WHERE hasta_id = @id";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@hastaadi", hasta.hasta_adi);
                    command.Parameters.AddWithValue("@hastasoyadi", hasta.hasta_soyadi);
                    command.Parameters.AddWithValue("@hastatel", hasta.hasta_tel);
                    command.Parameters.AddWithValue("@hastagittigibolum", hasta.hasta_gittigibolum);
                    command.Parameters.AddWithValue("@id", hasta.hasta_id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
