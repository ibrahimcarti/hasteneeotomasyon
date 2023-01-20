using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class SekreterDal : ISekreterDal
    {

        private string server = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\İbrahim\\Desktop\\GörselFinal\\HastaneVeriTabanı.mdb;";
        public void Add(Sekreter sekreter)
        {
            using (OleDbConnection connection = new OleDbConnection(server))
            {
                connection.Open();

                string check = "SELECT COUNT(*) FROM Sekreterler";
                OleDbCommand cmd = new OleDbCommand(check, connection);
                int count = (int)cmd.ExecuteScalar();

                if (count == 0)
                    sekreter.sekreter_id = 1;

                string query = "INSERT INTO Sekreterler (sekreter_adi, sekreter_soyadi, sekreter_tel) VALUES (@sekreteradi, @sekretersoyadi, @sekretertel)";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@sekreteradi", sekreter.sekreter_adi);
                    command.Parameters.AddWithValue("@sekretersoyadi", sekreter.sekreter_soyadi);
                    command.Parameters.AddWithValue("@sekretertel", sekreter.sekreter_tel);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int sekreter_id)
        {
            using (OleDbConnection connection = new OleDbConnection(server))
            {
                connection.Open();
                string query = "Delete from Sekreterler  WHERE sekreter_id = @sekreter_id";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@sekreter_id", sekreter_id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Sekreter> GetAllSekreter()
        {
            using (OleDbConnection connection = new OleDbConnection(server))
            {
                connection.Open();
                string query = "Select * from Sekreterler";
                List<Sekreter> sekreterlistesi = new List<Sekreter>();
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    OleDbDataReader getir = command.ExecuteReader();
                    while (getir.Read())
                    {
                        Sekreter sekreter = new Sekreter();
                        sekreter.sekreter_id = int.Parse(getir[0].ToString());
                        sekreter.sekreter_adi = getir[1].ToString();
                        sekreter.sekreter_soyadi =getir[2].ToString();
                        sekreter.sekreter_tel = getir[3].ToString();
                        sekreterlistesi.Add(sekreter);
                    }
                    return sekreterlistesi;
                }
            }
        }

        public void Update(Sekreter sekreter)
        {
            using (OleDbConnection connection = new OleDbConnection(server))
            {
                connection.Open();
                string query = "UPDATE Sekreterler SET sekreter_adi = @sekreteradi, sekreter_soyadi = @sekretersoyadi, sekreter_tel = @sekretertel WHERE sekreter_id = @sekreter_id";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@sekreteradi", sekreter.sekreter_adi);
                    command.Parameters.AddWithValue("@sekretersoyadi", sekreter.sekreter_soyadi);
                    command.Parameters.AddWithValue("@sekreterid", sekreter.sekreter_id);
                    command.Parameters.AddWithValue("@sekretertel", sekreter.sekreter_tel);
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
