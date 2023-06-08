﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scala.Adovb5.Core.Services
{
    internal class DBServices
    {
        public static DataTable ExecuteSelect(string sqlInstruction)
        {
            DataSet dataSet = new DataSet();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlInstruction, Helper.GetConnectionString());
            try
            {
                sqlDataAdapter.Fill(dataSet);
            }
            catch (Exception error)
            {
                string errorMessage = error.Message;  // t.b.v. debugging
                return null;
            }
            return dataSet.Tables[0];
        }
        public static bool ExecuteCommand(string sqlInstruction)
        {
            SqlConnection sqlConnection = new SqlConnection(Helper.GetConnectionString());
            SqlCommand sqlCommand = new SqlCommand(sqlInstruction, sqlConnection);
            try
            {
                sqlCommand.Connection.Open();
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception error)
            {
                string errorMessage = error.Message;  // t.b.v. debugging
                return false;
            }
            finally
            {
                if (sqlConnection != null)
                    sqlConnection.Close();
            }
        }
        public static string ExecuteScalar(string sqlScalarInstruction)
        {
            SqlConnection sqlConnection = new SqlConnection(Helper.GetConnectionString());
            SqlCommand sqlCommand = new SqlCommand(sqlScalarInstruction, sqlConnection);
            sqlConnection.Open();
            try
            {
                return sqlCommand.ExecuteScalar().ToString();
            }
            catch (Exception error)
            {
                string errorMessage = error.Message;  // t.b.v. debugging
                return null;
            }
            finally
            {
                if (sqlConnection != null)
                    sqlConnection.Close();
            }
        }
    }
}
