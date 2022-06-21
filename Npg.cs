using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;
using System.Windows.Forms;

namespace Qualifying_work
{
    public class Npg
    {
        NpgsqlConnection conn;
        NpgsqlCommand comm;
        NpgsqlDataReader dtrdr;
        DataTable dt;

        public Npg()
        {
            comm = new NpgsqlCommand();
            dt = new DataTable();
            conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=qualifyin;User ID=postgres;Password=123456789;");
            conn.Open();
            conn.Close();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
        }

        public void StartWork()
        {
            conn.Open();
        }

        public DataTable Query(string queryText)
        {
            bool wasError = false;
            comm.CommandText = queryText;
            try
            {
                dtrdr = comm.ExecuteReader();
            }
            catch (PostgresException pe)
            {
                wasError = true;
                if (pe.SqlState == "23505" && pe.ConstraintName == "unique_username")
                {
                    throw new Exception("login_taken");
                }
                else
                {
                    MessageBox.Show(pe.Message);
                }
            }
            if (!wasError)
            {
                dt = new DataTable();
                dt.Load(dtrdr);
                return dt;
            }
            return null;
        }

        public void FinishWork()
        {
            conn.Close();
        }
    }
}
