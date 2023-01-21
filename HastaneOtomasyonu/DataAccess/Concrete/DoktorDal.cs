﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class DoktorDal : IDoktorDal
    {
        private string server = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\İbrahim\\Desktop\\GörselFinal\\HastaneVeriTabanı.mdb;";
        public void Add(Doktor doktor)
        {
            using (OleDbConnection connection = new OleDbConnection(server))
            {
                connection.Open();

                string check = "SELECT COUNT(*) FROM Sekreterler";
                OleDbCommand cmd = new OleDbCommand(check, connection);
                int count = (int)cmd.ExecuteScalar();

                if (count == 0)
                    doktor.doktor_id = 1;

                string query = "INSERT INTO Doktorlar (doktor_adi, doktor_soyadi, doktor_tel, doktor_brans) VALUES (@doktoradi, @doktorsoyadi, @doktortel, @doktorbrans)";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@doktoradi", doktor.doktor_adi);
                    command.Parameters.AddWithValue("@doktorsoyadi", doktor.doktor_soyadi);
                    command.Parameters.AddWithValue("@doktortel", doktor.doktor_tel);
                    command.Parameters.AddWithValue("@doktorbrans", doktor.doktor_brans);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int doktor_id)
        {
            using (OleDbConnection connection = new OleDbConnection(server))
            {
                connection.Open();
                string query = "Delete from Doktorlar  WHERE doktor_id = @doktorid";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@doktorid", doktor_id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Doktor> GetAllDoktor()
        {
            using (OleDbConnection connection = new OleDbConnection(server))
            {
                connection.Open();
                string query = "Select * from Doktorlar";
                List<Doktor> doktorlistesi = new List<Doktor>();
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    OleDbDataReader getir = command.ExecuteReader();
                    while (getir.Read())
                    {
                        Doktor doktor = new Doktor();
                        doktor.doktor_id = int.Parse(getir[0].ToString());
                        doktor.doktor_adi = getir[1].ToString();
                        doktor.doktor_soyadi = getir[2].ToString();
                        doktor.doktor_tel = getir[3].ToString();
                        doktor.doktor_brans = getir[4].ToString();
                        doktorlistesi.Add(doktor);
                    }
                    return doktorlistesi;
                }
            }
        }

        public void Update(Doktor doktor)
        {
            using (OleDbConnection connection = new OleDbConnection(server))
            {
                connection.Open();
                string query = "UPDATE Doktorlar SET doktor_adi = @doktoradi, doktor_soyadi = @doktorsoyadi, doktor_tel = @doktortel, doctor_brans = @doktorbrans WHERE doktor_id = @doktorid";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@doktoradi", doktor.doktor_adi);
                    command.Parameters.AddWithValue("@doktorsoyadi", doktor.doktor_soyadi);
                    command.Parameters.AddWithValue("@doktortel", doktor.doktor_tel);
                    command.Parameters.AddWithValue("@doktorbrans", doktor.doktor_brans);
                    command.Parameters.AddWithValue("@doktorid", doktor.doktor_id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
