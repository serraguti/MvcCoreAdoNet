using MvcCoreAdoNet.Models;
using System.Data;
using System.Data.SqlClient;

namespace MvcCoreAdoNet.Repositories
{
    public class RepositoryDoctores
    {
        private SqlConnection cn;
        private SqlCommand com;
        private SqlDataReader reader;

        public RepositoryDoctores()
        {
            string connectionString =
                            @"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Password=MCSD2023";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }

        public List<Doctor> GetDoctores()
        {
            string sql = "SELECT * FROM DOCTOR";
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<Doctor> doctores = new List<Doctor>();
            while (this.reader.Read())
            {
                Doctor doc = new Doctor();
                doc.IdDoctor = int.Parse(this.reader["DOCTOR_NO"].ToString());
                doc.Apellido = this.reader["APELLIDO"].ToString();
                doc.Especialidad = this.reader["ESPECIALIDAD"].ToString();
                doc.Salario = int.Parse(this.reader["SALARIO"].ToString());
                doc.IdHospital = int.Parse(this.reader["HOSPITAL_COD"].ToString());
                doctores.Add(doc);
            }
            this.reader.Close();
            this.cn.Close();
            return doctores;
        }

        public List<Doctor> GetDoctoresEspecialidad(string especialidad)
        {
            string sql = "SELECT * FROM DOCTOR WHERE ESPECIALIDAD=@ESPECIALIDAD";
            SqlParameter pamespe = new SqlParameter("@ESPECIALIDAD", especialidad);
            this.com.Parameters.Add(pamespe);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<Doctor> doctores = new List<Doctor>();
            while (this.reader.Read())
            {
                Doctor doc = new Doctor();
                doc.IdDoctor = int.Parse(this.reader["DOCTOR_NO"].ToString());
                doc.Apellido = this.reader["APELLIDO"].ToString();
                doc.Especialidad = this.reader["ESPECIALIDAD"].ToString();
                doc.Salario = int.Parse(this.reader["SALARIO"].ToString());
                doc.IdHospital = int.Parse(this.reader["HOSPITAL_COD"].ToString());
                doctores.Add(doc);
            }
            this.reader.Close();
            this.cn.Close();
            this.com.Parameters.Clear();
            return doctores;
        }

        public List<string> GetEspecialidades()
        {
            string sql = "SELECT DISTINCT ESPECIALIDAD FROM DOCTOR";
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<string> especialidades = new List<string>();
            while (this.reader.Read())
            {
                string especialidad = this.reader["ESPECIALIDAD"].ToString();
                especialidades.Add(especialidad);
            }
            this.reader.Close();
            this.cn.Close();
            return especialidades;
        }

        public List<Doctor> GetDoctoresHospital(int idhospital)
        {
            string sql = "SELECT * FROM DOCTOR WHERE HOSPITAL_COD=@IDHOSPITAL";
            SqlParameter pamid = new SqlParameter("@IDHOSPITAL", idhospital);
            this.com.Parameters.Add(pamid);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<Doctor> doctores = new List<Doctor>();
            while (this.reader.Read())
            {
                Doctor doc = new Doctor();
                doc.IdDoctor = int.Parse(this.reader["DOCTOR_NO"].ToString());
                doc.Apellido = this.reader["APELLIDO"].ToString();
                doc.Especialidad = this.reader["ESPECIALIDAD"].ToString();
                doc.Salario = int.Parse(this.reader["SALARIO"].ToString());
                doc.IdHospital = int.Parse(this.reader["HOSPITAL_COD"].ToString());
                doctores.Add(doc);
            }
            this.reader.Close();
            this.cn.Close();
            this.com.Parameters.Clear();
            return doctores;
        }



    }
}
