using ManagerVanzari.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerVanzari.Controllers
{
    public class VanzariAziController
    {

        private readonly Service Service;
        private VanzariAzi View;
        private List<ProdusDeUpdatatInStocModel> ProdusedeUpdatatInStoc_List = new List<ProdusDeUpdatatInStocModel>();

        public VanzariAziController(ref Service s, VanzariAzi v)
        {
            this.View = v;
            this.Service = s;

            View.VanzariAziLoaded += OnVanzariAziLoaded;
            View.StergeVanzareToolStripPressed += OnStergeVanzareToolStripPressed;


        }

        public VanzariAziController(ref Service s)
        {
            this.Service = s;
            this.View = null;
        }

        public void setView(VanzariAzi v)
        {
            this.View = v;
            View.VanzariAziLoaded += OnVanzariAziLoaded;
            View.StergeVanzareToolStripPressed += OnStergeVanzareToolStripPressed;

        }

        public VanzariAzi getView()
        {
            return this.View;
        }

        private void OnVanzariAziLoaded(object sender, EventArgs e)
        {
            BindGridVanzari();
        }

        private void BindGridVanzari()
        {

            DataTable QueryResult = Service.ExecuteSelectAllVanzariAzi();

            if (QueryResult.Rows.Count > 0)
            {

                View.BindDTtoGridVanzari(QueryResult);
            }
            else
            {
                View.VanzariReadFailed();

            }

        }

        private void OnStergeVanzareToolStripPressed(object sender, EventArgs e)
        {
            if(Service.ExecuteDeleteVanzareProcedure(View.IdAles_int))
            {

                View.DeleteVanzareSuccessfull();

                BindGridVanzari();

                if (CheckIfRelatedVanzariProduseExistAndGetProduseDeUpdatat())
                {
                    DeleteRelatedVanzareProdus();

                    CresteCantitatiStoc();


                }
                else
                {


                }

                if (CheckIfRelatedVanzariServiciiExist())
                {

                    DeleteRelatedVanzareServiciu();

                }
                else
                {


                }

            }
            else
            {

                View.DeleteVanzareFailed();

            }
        }


        private bool CheckIfRelatedVanzariProduseExistAndGetProduseDeUpdatat()
        {
            bool retVal;


            DataTable QueryResult = Service.ExecuteCheckIfRelatedVanzariProduseExistProcedure(View.IdAles_int);

            if (QueryResult.Rows.Count > 0)
            {


                //View.ExistaVanzariProduseRelationate(QueryResult.Rows.Count);
                ProdusedeUpdatatInStoc_List = GetProduseDeUpdatatInStoc(QueryResult);

                retVal = true;

            }
            else
            {
                //View.NuExistaVanzariProduseRelationate();

                retVal = false;
            }

            return retVal;
        }


        private List<ProdusDeUpdatatInStocModel> GetProduseDeUpdatatInStoc(DataTable DT)
        {
            List<ProdusDeUpdatatInStocModel> localProdusedeUpdatatInStoc = new List<ProdusDeUpdatatInStocModel>();

            foreach (DataRow row in DT.Rows)
            {
                ProdusDeUpdatatInStocModel local_ProdusDeUpdatatInStoc = new ProdusDeUpdatatInStocModel(Convert.ToInt32(row["IdProdus"].ToString()), Convert.ToInt32(row["Cantitate"].ToString()));

                localProdusedeUpdatatInStoc.Add(local_ProdusDeUpdatatInStoc);

            }

            return localProdusedeUpdatatInStoc;
        }


        private void DeleteRelatedVanzareProdus()
        {

            if (Service.ExecuteDeleteVanzareProdusFromDeleteVanzareProcedure(View.IdAles_int))
            {

                //View.VanzariProduseRelationateDeletedSuccessfull();
            }
            else
            {

                //View.VanzariProduseRelationateDeletedFailed();
            }

        }


        private void CresteCantitatiStoc()
        {
            foreach (ProdusDeUpdatatInStocModel PDU in ProdusedeUpdatatInStoc_List)
            {

                if (Service.ExecuteCresteStocProcedure(PDU))
                {

                    //View.CresteStocSuccessfull(PDU);
                }
                else
                {
                    //View.CresteStocFailed();

                }

            }


            ProdusedeUpdatatInStoc_List.Clear();

        }

        private bool CheckIfRelatedVanzariServiciiExist()
        {
            bool retVal;


            DataTable QueryResult = Service.ExecuteCheckIfRelatedVanzariServiciiExistProcedure(View.IdAles_int);

            if (QueryResult.Rows.Count > 0)
            {

                //View.ExistaVanzariServiciiRelationate(QueryResult.Rows.Count);
                retVal = true;

            }
            else
            {
                //View.NuExistaVanzariServiciiRelationate();
                retVal = false;
            }

            return retVal;
        }


        private void DeleteRelatedVanzareServiciu()
        {
            if (Service.ExecuteDeleteVanzareServiciuFromDeleteVanzareProcedure(View.IdAles_int))
            {

                //View.VanzariServiciiRelationateDeletedSuccessfull();
            }
            else
            {

                //View.VanzariServiciiRelationateDeletedFailed();
            }

        }


    }
}
