using System;
using System.Data;
using System.Data.SQLite;

namespace MvcLotterDal
{
    public partial class SQLiteHelper
    {
        private const string ConnectionString = "Data Source=D:\\SqlLites.db;Version=3;UseUTF16Encoding=True";

        public static SQLiteDataReader ExecuteReader(string sqlstring, params SQLiteParameter[] cmdParms)
        {
            SQLiteConnection connection = new SQLiteConnection(ConnectionString);
            SQLiteCommand cmd = new SQLiteCommand();
            try
            {
                PrepareCommand(cmd, connection, null, sqlstring, cmdParms);
                SQLiteDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return myReader;
            }
            catch (SQLiteException ex)
            {
                throw ex;
            }
        }

        private static void PrepareCommand(SQLiteCommand cmd, SQLiteConnection conn, SQLiteTransaction trans, string cmdText, SQLiteParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null) cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;
            if (cmdParms != null)
            {


                foreach (SQLiteParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }
    }
}
