﻿using System.Data;
using System.Data.SqlClient;
using MvcCoreAdoNet.Models;

namespace MvcCoreAdoNet.Repositories
{
    public class RepositoryHospital
    {
        private SqlConnection cn;
        private SqlCommand com;
        private SqlDataReader reader;

        public RepositoryHospital()
        {
            string connectionString =
                @"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Password=MCSD2023";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }

        public List<Hospital> GetHospitales()
        {
            string sql = "SELECT * FROM HOSPITAL";
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<Hospital> hospitales = new List<Hospital>();
            while (this.reader.Read())
            {
                Hospital hospital = new Hospital();
                hospital.IdHospital = int.Parse(this.reader["HOSPITAL_COD"].ToString());
                hospital.Nombre = this.reader["NOMBRE"].ToString();
                hospital.Direccion = this.reader["DIRECCION"].ToString();
                hospital.Telefono = this.reader["TELEFONO"].ToString();
                hospital.Camas = int.Parse(this.reader["NUM_CAMA"].ToString());
                hospitales.Add(hospital);
            }
            this.reader.Close();
            this.cn.Close();
            return hospitales;
        }

        public Hospital FindHospital(int idhospital)
        {
            string sql = "SELECT * FROM HOSPITAL WHERE HOSPITAL_COD=@IDHOSPITAL";
            SqlParameter pamid = new SqlParameter("@IDHOSPITAL", idhospital);
            this.com.Parameters.Add(pamid);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            Hospital hospital = new Hospital();
            this.reader.Read();
            hospital.IdHospital = int.Parse(this.reader["HOSPITAL_COD"].ToString());
            hospital.Nombre = this.reader["NOMBRE"].ToString();
            hospital.Direccion = this.reader["DIRECCION"].ToString();
            hospital.Telefono = this.reader["TELEFONO"].ToString();
            hospital.Camas = int.Parse(this.reader["NUM_CAMA"].ToString());
            this.reader.Close();
            this.cn.Close();
            this.com.Parameters.Clear();
            return hospital;
        }

        public void CreateHospital(int idhospital, string nombre
            , string direccion, string telefono, int camas)
        {
            string sql = "INSERT INTO HOSPITAL VALUES (@ID, @NOMBRE, @DIRECCION, "
                + " @TELEFONO, @CAMAS)";
            this.com.Parameters.AddWithValue("@ID", idhospital);
            this.com.Parameters.AddWithValue("@NOMBRE", nombre);
            this.com.Parameters.AddWithValue("@DIRECCION", direccion);
            this.com.Parameters.AddWithValue("@TELEFONO", telefono);
            this.com.Parameters.AddWithValue("@CAMAS", camas);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
        }
    }
}
