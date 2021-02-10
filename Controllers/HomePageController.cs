using ManagerVanzari.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerVanzari.Controllers
{
    public class HomePageController
    {

        private readonly Service Service;
        private HomePage View;

        public VanzariAziController Home_VanzariAziViewController;

        public HomePageController(ref Service s, HomePage v)
        {
            this.View = v;
            this.Service = s;

            View.HomePageLoaded += OnHomePageLoaded;
            View.ButtonInregistrareVanzarePressed += OnButtonInregistrareVanzarePressed;
            View.BindGridProduseServicii += OnBindGridProduseServicii;
            View.VanzariAziRequested += OnVanzariAziRequested;
        }

        public HomePageController(ref Service s)
        {
            this.Service = s;
            this.View = null;
        }

        public void setView(HomePage v)
        {
            this.View = v;
            
            View.HomePageLoaded += OnHomePageLoaded;
            View.ButtonInregistrareVanzarePressed += OnButtonInregistrareVanzarePressed;
            View.BindGridProduseServicii += OnBindGridProduseServicii;
            View.VanzariAziRequested += OnVanzariAziRequested;
        }

        public HomePage getView()
        {
            return this.View;
        }



        private void OnHomePageLoaded(object sender, EventArgs e)
        {
            
            if (Service.AttemptDatabaseConnection())
            {

                View.DatabaseConnectionOk();

            }
            else
            {

                View.DatabaseConnectionFailed();
            }


            GetClientiTable();
            GetNrInmatriculareTable();

            if (View.DataTableClienti.Rows.Count > 0 && View.DataTableNrInm.Rows.Count > 0 && View.global_flag_Unusable == false && View.globalDBConnection == true)
            {

                BindGridProduse();
                BindGridServicii();


                View.AllDataReadSuccesfullOnLoad();

            }
            else
            {
                View.AllDataReadFailedOnLoad();

            }

        }


        private void GetClientiTable()
        {
            View.DataTableClienti = Service.ExecuteGetNumeClientiProcedure();

        }


        private void GetNrInmatriculareTable()
        {
            View.DataTableNrInm = Service.ExecuteGetNumereInmatriculareProcedure();
        }

        public void BindGridProduse()
        {

            DataTable QueryResult = Service.ExecuteSelectProduseImaginiPretProcedure();

            if(QueryResult.Rows.Count>0)
            {

                View.BindDTtoGridProduse(QueryResult);
            }
            else
            {
                View.ProduseReadFailed();

            }

        }

        private void BindGridServicii()
        {

            DataTable QueryResult = Service.ExecuteSelectServiciiPretProcedure();

            if (QueryResult.Rows.Count > 0)
            {
                View.BindDTtoGridServicii(QueryResult);

            }
            else
            {
                View.ServiciiReadFailed();

            }

        }

        private void OnButtonInregistrareVanzarePressed(object sender, EventArgs e)
        {

            Vanzare();

            VanzareProdus();

            VanzareServiciu();

            View.ClearRowsTotalClient();

            View.CalcularePretTotal();

            BindGridProduse();
            BindGridServicii();



        }


        private void Vanzare()
        {
            bool Status;
            int IdVanzare;
                
                
            (Status,IdVanzare) = Service.ExecuteInsertVanzareProcedure(View.Client_Ales_int,View.Pret_Total_Decimal,View.NrMasina_Ales_String);

            if(Status)
            {
                View.globalIdVanzare = IdVanzare;

                View.VanzareInregistrataSuccessfull();

            }
            else
            {
                View.VanzareInregistrataFailed();

            }

        }


        private void VanzareProdus()
        {

            View.View_VanzareProdus();

            StringBuilder ProdusePeBon = new StringBuilder();

            int NumarVanzariProduse = 0;

            foreach (ItemGVTotalModel Produs in View.globalTotalProduse_Bon_List)
            {


                ProdusePeBon.Append(Produs.Nume + "(" + "x" + Produs.Cantitate + ")");
                ProdusePeBon.Append("\n");


                Service.ExecuteInsertVanzareProdusProcedure(Produs,View.globalIdVanzare);

                Service.ExecuteScadereStocProcedure(Produs);

                NumarVanzariProduse += 1;

            }


            View.DisplayStatusVanzareProdusInregistrata(NumarVanzariProduse, ProdusePeBon);

            
            View.globalTotalProduse_Bon_List.Clear();

        }


        private void VanzareServiciu()
        {

            View.View_VanzareServiciu();

            StringBuilder ServiciiPeBon = new StringBuilder();

            int NumarVanzariServicii = 0;

            foreach (ItemGVTotalModel Serviciu in View.globalTotalServicii_Bon_List)
            {

                ServiciiPeBon.Append(Serviciu.Nume + "(" + "x" + Serviciu.Cantitate + ")");
                ServiciiPeBon.Append("\n");


                Service.ExecuteInsertVanzareServiciuProcedure(Serviciu,View.globalIdVanzare);

                 NumarVanzariServicii += 1;

            }


            View.DisplayStatusVanzareServiciuInregistrata(NumarVanzariServicii, ServiciiPeBon);

            View.globalTotalServicii_Bon_List.Clear();

        }


        private void OnBindGridProduseServicii(object sender, EventArgs e)
        {
            BindGridProduse();
            BindGridServicii();
        }

        private void OnVanzariAziRequested(object sender, EventArgs e)
        {

            VanzariAzi VanzariAzi_View = new VanzariAzi(View.getThisForm());

            Home_VanzariAziViewController.setView(VanzariAzi_View);

            Home_VanzariAziViewController.getView().Show();


        }
    }
}
