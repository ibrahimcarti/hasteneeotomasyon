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

        //public void Add(Doktor doktor)
        //{
        //    using (OleDbConnection connection = new OleDbConnection(server))
        //    {
        //        connection.Open();

        //        string check = "SELECT COUNT(*) FROM Doktorlar";
        //        OleDbCommand cmd = new OleDbCommand(check, connection);
        //        int count = (int)cmd.ExecuteScalar();

        //        if (count == 0)
        //            doktor.doktor_id = 1;

        //        string query = "INSERT INTO Doktorlar (doktor_adi, doktor_soyadi, doktor_tel, doktor_brans) VALUES (@doktoradi, @doktorsoyadi, @doktortel, @doktorbrans)";
        //        using (OleDbCommand command = new OleDbCommand(query, connection))
        //        {
        //            command.Parameters.AddWithValue("@doktoradi", doktor.doktor_adi);
        //            command.Parameters.AddWithValue("@doktorsoyadi", doktor.doktor_soyadi);
        //            command.Parameters.AddWithValue("@doktortel", doktor.doktor_tel);
        //            command.Parameters.AddWithValue("@doktorbrans", doktor.doktor_brans);
        //            command.ExecuteNonQuery();
        //        }
        //    }
        //}

        //public void Add(Hasta hasta)
        //{
        //    using (OleDbConnection connection = new OleDbConnection(server))
        //    {
        //        connection.Open();

        //        string check = "SELECT COUNT(*) FROM Hastalar";
        //        OleDbCommand cmd = new OleDbCommand(check, connection);
        //        int count = (int)cmd.ExecuteScalar();

        //        if (count == 0)
        //            hasta.hasta_id = 1;

        //        string query = "INSERT INTO Hastalar (hasta_adi, hasta_soyadi, hasta_tel, hasta_gittigibolum) VALUES (@hastaadi, @hastasoyadi, @hastatel, @hastagittigibolum)";
        //        using (OleDbCommand command = new OleDbCommand(query, connection))
        //        {
        //            command.Parameters.AddWithValue("@hastaadi", hasta.hasta_adi);
        //            command.Parameters.AddWithValue("@hastasoyadi", hasta.hasta_soyadi);
        //            command.Parameters.AddWithValue("@hastatel", hasta.hasta_tel);
        //            command.Parameters.AddWithValue("@hastagittigibolum", hasta.hasta_gittigibolum);
        //            command.ExecuteNonQuery();
        //        }
        //    }
        //}

        //public void Add(Randevu randevu)
        //{
        //    throw new NotImplementedException();
        //}

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

        //public void DeleteDoktor(int doktor_id)
        //{
        //    using (OleDbConnection connection = new OleDbConnection(server))
        //    {
        //        connection.Open();
        //        string query = "Delete from Doktorlar  WHERE doktor_id = @doktorid";
        //        using (OleDbCommand command = new OleDbCommand(query, connection))
        //        {
        //            command.Parameters.AddWithValue("@doktorid", doktor_id);
        //            command.ExecuteNonQuery();
        //        }
        //    }
        //}

        //public void DeleteHasta(int hasta_id)
        //{
        //    using (OleDbConnection connection = new OleDbConnection(server))
        //    {
        //        connection.Open();
        //        string query = "Delete from Hastalar  WHERE hasta_id = @id";
        //        using (OleDbCommand command = new OleDbCommand(query, connection))
        //        {
        //            command.Parameters.AddWithValue("@id", hasta_id);
        //            command.ExecuteNonQuery();
        //        }
        //    }
        //}

        //public List<Doktor> GetAllDoktor()
        //{
        //    using (OleDbConnection connection = new OleDbConnection(server))
        //    {
        //        connection.Open();
        //        string query = "Select * from Doktorlar";
        //        List<Doktor> doktorlistesi = new List<Doktor>();
        //        using (OleDbCommand command = new OleDbCommand(query, connection))
        //        {
        //            OleDbDataReader getir = command.ExecuteReader();
        //            while (getir.Read())
        //            {
        //                Doktor doktor = new Doktor();
        //                doktor.doktor_id = int.Parse(getir[0].ToString());
        //                doktor.doktor_adi = getir[1].ToString();
        //                doktor.doktor_soyadi = getir[2].ToString();
        //                doktor.doktor_tel = getir[3].ToString();
        //                doktor.doktor_brans = getir[4].ToString();
        //                doktorlistesi.Add(doktor);
        //            }
        //            return doktorlistesi;
        //        }
        //    }
        //}

        //public List<Hasta> GetAllHasta()
        //{
        //    using (OleDbConnection connection = new OleDbConnection(server))
        //    {
        //        connection.Open();
        //        string query = "Select * from Hastalar";
        //        List<Hasta> hastalistesi = new List<Hasta>();
        //        using (OleDbCommand command = new OleDbCommand(query, connection))
        //        {
        //            OleDbDataReader getir = command.ExecuteReader();
        //            while (getir.Read())
        //            {
        //                Hasta hasta = new Hasta();
        //                hasta.hasta_id = int.Parse(getir[0].ToString());
        //                hasta.hasta_adi = getir[1].ToString();
        //                hasta.hasta_soyadi = getir[2].ToString();
        //                hasta.hasta_tel = getir[3].ToString();
        //                hasta.hasta_gittigibolum = getir[4].ToString();
        //                hastalistesi.Add(hasta);
        //            }
        //            return hastalistesi;
        //        }
        //    }
        //}

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


        //public List<Doktor> GetDoktorbyBrans(string brans)
        //{
        //    using (OleDbConnection connection = new OleDbConnection(server))
        //    {
        //        connection.Open();
        //        string query = "Select doktor_id, doktor_adi, doktor_soyadi, doktor_brans FROM Doktorlar WHERE doktor_brans = @brans";
        //        List<Doktor> branslistesi = new List<Doktor>();
        //        using (OleDbCommand command = new OleDbCommand(query, connection))
        //        {
        //            command.Parameters.AddWithValue("@brans", brans);
        //            OleDbDataReader getir = command.ExecuteReader();
        //            while (getir.Read())
        //            {
        //                int id = getir.GetInt32(0);
        //                string ad = getir.GetString(1);
        //                string soyad = getir.GetString(2);
        //                string doktorbrans = getir.GetString(3);

        //                Doktor doktor = new Doktor
        //                {
        //                    doktor_id = id,
        //                    doktor_adi = ad,
        //                    doktor_soyadi = soyad,
        //                    doktor_brans= doktorbrans
        //                };
        //                branslistesi.Add(doktor);
        //            }
        //            return branslistesi;
        //        }
        //    }
        //}

        public void Update(Sekreter sekreter)
        {
            using (OleDbConnection connection = new OleDbConnection(server))
            {
                connection.Open();
                string query = "UPDATE Sekreterler SET sekreter_adi = @sekreteradi, sekreter_soyadi = @sekretersoyadi, sekreter_tel = @sekretertel WHERE sekreter_id = @sekreterid";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@sekreteradi", sekreter.sekreter_adi);
                    command.Parameters.AddWithValue("@sekretersoyadi", sekreter.sekreter_soyadi);
                    command.Parameters.AddWithValue("@sekretertel", sekreter.sekreter_tel);
                    command.Parameters.AddWithValue("@sekreterid", sekreter.sekreter_id);
                    command.ExecuteNonQuery();
                }
            }
        }

        //public void Update(Doktor doktor)
        //{
        //    using (OleDbConnection connection = new OleDbConnection(server))
        //    {
        //        connection.Open();

        //        string query = "UPDATE Doktorlar SET doktor_adi = @doktoradi, doktor_soyadi = @doktorsoyadi, doktor_tel= @doktortel, doktor_brans = @brans WHERE doktor_id = @id";
        //        using (OleDbCommand command = new OleDbCommand(query, connection))
        //        {
        //            command.Parameters.AddWithValue("@doktoradi", doktor.doktor_adi);
        //            command.Parameters.AddWithValue("@doktorsoyadi", doktor.doktor_soyadi);
        //            command.Parameters.AddWithValue("@doktortel", doktor.doktor_tel);
        //            command.Parameters.AddWithValue("@doktorbrans", doktor.doktor_brans);
        //            command.Parameters.AddWithValue("@id", doktor.doktor_id);
        //            command.ExecuteNonQuery();
        //        }
        //    }
        //}

        //public void Update(Hasta hasta)
        //{
        //    using (OleDbConnection connection = new OleDbConnection(server))
        //    {
        //        connection.Open();

        //        string query = "UPDATE Hastalar SET hasta_adi = @hastaadi, hasta_soyadi = @hastasoyadi, hasta_tel= @hastatel, hasta_gittigibolum = @hastagittigibolum WHERE hasta_id = @id";
        //        using (OleDbCommand command = new OleDbCommand(query, connection))
        //        {
        //            command.Parameters.AddWithValue("@hastaadi", hasta.hasta_adi);
        //            command.Parameters.AddWithValue("@hastasoyadi", hasta.hasta_soyadi);
        //            command.Parameters.AddWithValue("@hastatel", hasta.hasta_tel);
        //            command.Parameters.AddWithValue("@hastagittigibolum", hasta.hasta_gittigibolum);
        //            command.Parameters.AddWithValue("@id", hasta.hasta_id);
        //            command.ExecuteNonQuery();
        //        }
        //    }
        //}
    }
}
