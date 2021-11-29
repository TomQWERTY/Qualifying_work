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

        public void StartWork()
        {
            conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=qualifyin;User ID=postgres;Password=123456789;");
            conn.Open();
            comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            dt = new DataTable();
            Query("SET datestyle TO 'SQL,mdy';");
        }

        public DataTable Query(string queryText)
        {
            comm.CommandText = queryText;
            try
            {
                dtrdr = comm.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            dt = new DataTable();
            dt.Load(dtrdr);
            return dt;
        }

        public void FinishWork()
        {
            comm.Dispose();
            conn.Close();
        }
    }
}
