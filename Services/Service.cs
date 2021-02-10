//#define DEV
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerVanzari.Services
{

    public sealed class Service
    {
#if !DEV
        private SqlConnection DataBaseConnection_SqlCOnnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database\Database1.mdf;Integrated Security = True");
#else
        private SqlConnection DataBaseConnection_SqlCOnnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dean\source\repos\ManagerStoc\ManagerStoc\Database1.mdf;Integrated Security = True");
#endif

        //thread safe singleton even if app is ST
        private static Service instance = null;
        private static readonly object padlock = new object();


        public static Service Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Service();
                    }
                    return instance;
                }
            }
        }



        public bool AttemptDatabaseConnection()
        {
            bool retVal;

            try
            {
                DataBaseConnection_SqlCOnnection.Open();

                if (DataBaseConnection_SqlCOnnection.State == ConnectionState.Open)
                {

                    retVal = true;
                }
                else
                {

                    retVal = false;
                }

                DataBaseConnection_SqlCOnnection.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                retVal = false;
            }


            return retVal;
        }



        public DataTable ExecuteGetNumeClientiProcedure()
        {
            DataTable DataTable_retVal = new DataTable();

            try
            {

                using (SqlCommand SqlCommand_SC = new SqlCommand("GetNumeClienti", DataBaseConnection_SqlCOnnection))
                {
                    SqlCommand_SC.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter DataAdapeter_SqlDataAdapter = new SqlDataAdapter(SqlCommand_SC);

                    DataTable DataTable_DT = new DataTable();

                    DataBaseConnection_SqlCOnnection.Open();
                    SqlCommand_SC.ExecuteNonQuery();
                    DataBaseConnection_SqlCOnnection.Close();
                    DataAdapeter_SqlDataAdapter.Fill(DataTable_DT);


                    if (DataTable_DT.Rows.Count > 0)
                    {
                        DataTable_retVal = DataTable_DT;

                    }
                    else
                    {



                    }
                }


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return DataTable_retVal;

        }


        public DataTable ExecuteGetNumereInmatriculareProcedure()
        {
            DataTable DataTable_retVal = new DataTable();

            try
            {

                using (SqlCommand SqlCommand_SC = new SqlCommand("GetNumereInmatriculareProc", DataBaseConnection_SqlCOnnection))
                {
                    SqlCommand_SC.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter DataAdapeter_SqlDataAdapter = new SqlDataAdapter(SqlCommand_SC);

                    DataTable DataTable_DT = new DataTable();

                    DataBaseConnection_SqlCOnnection.Open();
                    SqlCommand_SC.ExecuteNonQuery();
                    DataBaseConnection_SqlCOnnection.Close();
                    DataAdapeter_SqlDataAdapter.Fill(DataTable_DT);


                    if (DataTable_DT.Rows.Count > 0)
                    {
                        DataTable_retVal = DataTable_DT;

                    }
                    else
                    {



                    }
                }


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return DataTable_retVal;
        }



        public DataTable ExecuteSelectProduseImaginiPretProcedure()
        {
            DataTable DataTable_retVal = new DataTable();

            try
            {

                using (SqlCommand SqlCommand_SC = new SqlCommand("SelectProduseImaginiDescPretProc", DataBaseConnection_SqlCOnnection))
                {
                    SqlCommand_SC.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter DataAdapeter_SqlDataAdapter = new SqlDataAdapter(SqlCommand_SC);

                    DataTable DataTable_DT = new DataTable();

                    DataBaseConnection_SqlCOnnection.Open();
                    SqlCommand_SC.ExecuteNonQuery();
                    DataBaseConnection_SqlCOnnection.Close();
                    DataAdapeter_SqlDataAdapter.Fill(DataTable_DT);


                    if (DataTable_DT.Rows.Count > 0)
                    {
                        DataTable_retVal = DataTable_DT;

                    }
                    else
                    {


                    }
                }


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            return DataTable_retVal;
        }




        public DataTable ExecuteSelectServiciiPretProcedure()
        {
            DataTable DataTable_retVal = new DataTable();


            try
            {

                using (SqlCommand SqlCommand_SC = new SqlCommand("SelectServiciiPretProc", DataBaseConnection_SqlCOnnection))
                {
                    SqlCommand_SC.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter DataAdapeter_SqlDataAdapter = new SqlDataAdapter(SqlCommand_SC);

                    DataTable DataTable_DT = new DataTable();

                    DataBaseConnection_SqlCOnnection.Open();
                    SqlCommand_SC.ExecuteNonQuery();
                    DataBaseConnection_SqlCOnnection.Close();
                    DataAdapeter_SqlDataAdapter.Fill(DataTable_DT);


                    if (DataTable_DT.Rows.Count > 0)
                    {

                        DataTable_retVal = DataTable_DT;

                    }
                    else
                    {


                    }
                }


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            return DataTable_retVal;
        }




        public (bool,int) ExecuteInsertVanzareProcedure(int IdClient, Decimal PretTotal, String NrMasinaAles)
        {
            bool retVal;
            int IdVanzareInregistrata;

            try
            {

                using (SqlCommand SqlCommand_SC = new SqlCommand("InsertVanzareProc", DataBaseConnection_SqlCOnnection))
                {
                    SqlCommand_SC.CommandType = CommandType.StoredProcedure;

                    SqlCommand_SC.Parameters.AddWithValue("@inputdataora", System.DateTime.Now);
                    SqlCommand_SC.Parameters.AddWithValue("@inputidclient", IdClient);
                    SqlCommand_SC.Parameters.AddWithValue("@inputprettotal", PretTotal);
                    SqlCommand_SC.Parameters.AddWithValue("@inputnrmasina", NrMasinaAles);


                    SqlCommand_SC.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;


                    DataBaseConnection_SqlCOnnection.Open();
                    SqlCommand_SC.ExecuteNonQuery();

                    DataBaseConnection_SqlCOnnection.Close();

                    IdVanzareInregistrata = Convert.ToInt32(SqlCommand_SC.Parameters["@id"].Value.ToString());

                    retVal = true;
                }


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                retVal = false;
                IdVanzareInregistrata = -1;
            }

            return (retVal, IdVanzareInregistrata);

        }

        public void ExecuteInsertVanzareProdusProcedure(ItemGVTotalModel Produs, int IdVanzare)
        {

            try
            {

                using (SqlCommand SqlCommand_SC = new SqlCommand("InsertVanzareProdusProc", DataBaseConnection_SqlCOnnection))
                {
                    SqlCommand_SC.CommandType = CommandType.StoredProcedure;

                    SqlCommand_SC.Parameters.AddWithValue("@inputidprodus", Produs.Id);
                    SqlCommand_SC.Parameters.AddWithValue("@inputcantitate", Produs.Cantitate);
                    SqlCommand_SC.Parameters.AddWithValue("@inputprettotal", Produs.Pret);
                    SqlCommand_SC.Parameters.AddWithValue("@inputidvanzare", IdVanzare);


                    DataBaseConnection_SqlCOnnection.Open();
                    SqlCommand_SC.ExecuteNonQuery();

                    DataBaseConnection_SqlCOnnection.Close();

                }
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void ExecuteScadereStocProcedure(ItemGVTotalModel Produs)
        {

            try
            {

                using (SqlCommand SqlCommand_SC = new SqlCommand("ScadereStocProc", DataBaseConnection_SqlCOnnection))
                {
                    SqlCommand_SC.CommandType = CommandType.StoredProcedure;

                    SqlCommand_SC.Parameters.AddWithValue("@inputidprodus", Produs.Id);
                    SqlCommand_SC.Parameters.AddWithValue("@inputcantitate", Produs.Cantitate);


                    DataBaseConnection_SqlCOnnection.Open();
                    SqlCommand_SC.ExecuteNonQuery();

                    DataBaseConnection_SqlCOnnection.Close();

                }


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void ExecuteInsertVanzareServiciuProcedure(ItemGVTotalModel Serviciu, int IdVanzare)
        {

            try
            {

                using (SqlCommand SqlCommand_SC = new SqlCommand("InsertVanzareServiciuProc", DataBaseConnection_SqlCOnnection))
                {
                    SqlCommand_SC.CommandType = CommandType.StoredProcedure;

                    SqlCommand_SC.Parameters.AddWithValue("inputidserviciu", Serviciu.Id);
                    SqlCommand_SC.Parameters.AddWithValue("@inputcantitate", Serviciu.Cantitate);
                    SqlCommand_SC.Parameters.AddWithValue("@inputprettotal", Serviciu.Pret);
                    SqlCommand_SC.Parameters.AddWithValue("@inputidvanzare", IdVanzare);


                    DataBaseConnection_SqlCOnnection.Open();
                    SqlCommand_SC.ExecuteNonQuery();

                    DataBaseConnection_SqlCOnnection.Close();

                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        public DataTable ExecuteSelectAllVanzariAzi()
        {
            DataTable DataTable_retVal = new DataTable();
            try
            {

                using (SqlCommand SqlCommand_SC = new SqlCommand("SelectVanzariDataAziProc", DataBaseConnection_SqlCOnnection))
                {
                    SqlCommand_SC.CommandType = CommandType.StoredProcedure;

                    SqlCommand_SC.Parameters.AddWithValue("@inputdataazi", DateTime.Today.Date);

                    SqlDataAdapter DataAdapeter_SqlDataAdapter = new SqlDataAdapter(SqlCommand_SC);

                    DataTable DataTable_DT = new DataTable();

                    DataBaseConnection_SqlCOnnection.Open();
                    SqlCommand_SC.ExecuteNonQuery();
                    DataBaseConnection_SqlCOnnection.Close();
                    DataAdapeter_SqlDataAdapter.Fill(DataTable_DT);


                    if (DataTable_DT.Rows.Count > 0)
                    {
                        DataTable_retVal = DataTable_DT;

                    }
                    else
                    {

                    }
                }


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return DataTable_retVal;

        }



        public bool ExecuteDeleteVanzareProcedure(int IdVanzare)
        {
            bool retVal;

            try
            {

                using (SqlCommand SqlCommand_SC = new SqlCommand("DeleteVanzareProc", DataBaseConnection_SqlCOnnection))
                {
                    SqlCommand_SC.CommandType = CommandType.StoredProcedure;

                    SqlCommand_SC.Parameters.AddWithValue("@inputid", IdVanzare);


                    DataBaseConnection_SqlCOnnection.Open();

                    SqlCommand_SC.ExecuteNonQuery();

                    DataBaseConnection_SqlCOnnection.Close();

                    retVal = true;
                }

            }

            catch (SqlException ex) when (ex.Number == 547)
            {
                retVal = false;
            }

            return retVal;

        }


        public DataTable ExecuteCheckIfRelatedVanzariProduseExistProcedure(int IdVanzare)
        {

            DataTable DataTable_retVal = new DataTable();

            try
            {
                using (SqlCommand SqlCommand_SC = new SqlCommand("CheckIfRelatedVanzariProduseExistProc", DataBaseConnection_SqlCOnnection))
                {
                    SqlCommand_SC.CommandType = CommandType.StoredProcedure;

                    SqlCommand_SC.Parameters.AddWithValue("@inputidvanzare", IdVanzare);

                    SqlDataAdapter DataAdapeter_SqlDataAdapter = new SqlDataAdapter(SqlCommand_SC);

                    DataTable DataTable_DT = new DataTable();

                    DataBaseConnection_SqlCOnnection.Open();
                    SqlCommand_SC.ExecuteNonQuery();

                    DataBaseConnection_SqlCOnnection.Close();

                    DataAdapeter_SqlDataAdapter.Fill(DataTable_DT);

                    if (DataTable_DT.Rows.Count > 0)
                    {

                        DataTable_retVal = DataTable_DT;

                    }
                    else
                    {

                    }

                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

            return DataTable_retVal;
        }

        public bool ExecuteDeleteVanzareProdusFromDeleteVanzareProcedure(int IdVanzare)
        {
            bool retVal;


            try
            {

                using (SqlCommand SqlCommand_SC = new SqlCommand("DeleteVanzareProdusFromDeleteVanzareProc", DataBaseConnection_SqlCOnnection))
                {
                    SqlCommand_SC.CommandType = CommandType.StoredProcedure;

                    SqlCommand_SC.Parameters.AddWithValue("@inputid", IdVanzare);


                    DataBaseConnection_SqlCOnnection.Open();

                    SqlCommand_SC.ExecuteNonQuery();

                    DataBaseConnection_SqlCOnnection.Close();

                    retVal = true;
                }


            }

            catch (SqlException ex) when (ex.Number == 547)
            {
                DataBaseConnection_SqlCOnnection.Close();
                retVal = false;
            }

            return retVal;
        }

        public bool ExecuteCresteStocProcedure(ProdusDeUpdatatInStocModel PDUModel)
        {
            bool retVal;

            try
            {

                using (SqlCommand SqlCommand_SC = new SqlCommand("CrestereStocProc", DataBaseConnection_SqlCOnnection))
                {
                    SqlCommand_SC.CommandType = CommandType.StoredProcedure;

                    SqlCommand_SC.Parameters.AddWithValue("@inputidprodus", PDUModel.IdProdus);
                    SqlCommand_SC.Parameters.AddWithValue("@inputcantitate", PDUModel.Cantitate);


                    DataBaseConnection_SqlCOnnection.Open();

                    SqlCommand_SC.ExecuteNonQuery();

                    DataBaseConnection_SqlCOnnection.Close();

                    retVal = true;
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                retVal = false;
            }

            return retVal;

        }


        public DataTable ExecuteCheckIfRelatedVanzariServiciiExistProcedure(int IdVanzare)
        {

            DataTable DataTable_retVal = new DataTable();

            try
            {
                using (SqlCommand SqlCommand_SC = new SqlCommand("CheckIfRelatedVanzariServiciiExistProc", DataBaseConnection_SqlCOnnection))
                {
                    SqlCommand_SC.CommandType = CommandType.StoredProcedure;

                    SqlCommand_SC.Parameters.AddWithValue("@inputidvanzare", IdVanzare);

                    SqlDataAdapter DataAdapeter_SqlDataAdapter = new SqlDataAdapter(SqlCommand_SC);

                    DataTable DataTable_DT = new DataTable();

                    DataBaseConnection_SqlCOnnection.Open();
                    SqlCommand_SC.ExecuteNonQuery();

                    DataBaseConnection_SqlCOnnection.Close();

                    DataAdapeter_SqlDataAdapter.Fill(DataTable_DT);

                    if (DataTable_DT.Rows.Count > 0)
                    {

                        DataTable_retVal = DataTable_DT;

                    }
                    else
                    {

                    }

                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

            return DataTable_retVal;
        }


        public bool ExecuteDeleteVanzareServiciuFromDeleteVanzareProcedure(int IdVanzare)
        {
            bool retVal;

            try
            {

                using (SqlCommand SqlCommand_SC = new SqlCommand("DeleteVanzareServiciuFromDeleteVanzareProc", DataBaseConnection_SqlCOnnection))
                {
                    SqlCommand_SC.CommandType = CommandType.StoredProcedure;

                    SqlCommand_SC.Parameters.AddWithValue("@inputid", IdVanzare);


                    DataBaseConnection_SqlCOnnection.Open();

                    SqlCommand_SC.ExecuteNonQuery();

                    DataBaseConnection_SqlCOnnection.Close();

                    retVal = true;
                }


            }

            catch (SqlException ex) when (ex.Number == 547)
            {
                DataBaseConnection_SqlCOnnection.Close();
                retVal = false;
            }
            return retVal;
        }


    }




}

