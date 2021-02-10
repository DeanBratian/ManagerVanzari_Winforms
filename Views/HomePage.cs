
using ManagerVanzari.Classes;
using ManagerVanzari.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ManagerVanzari
{
    public partial class HomePage : Form, HomePage_I
    {


        public event EventHandler HomePageLoaded;
        public event EventHandler ButtonInregistrareVanzarePressed;
        public event EventHandler BindGridProduseServicii;
        public event EventHandler VanzariAziRequested;


        public DataTable DataTableClienti = new DataTable();
        public DataTable DataTableNrInm = new DataTable();


        public bool flagNoClientiNumere_bool = false;
        public bool global_flag_Unusable = false;


        public int Client_Ales_int;
        public int Contract_Ales_int;
        public String NrMasina_Ales_String;

        public Decimal Pret_Total_Decimal = 0;
        public int IndexRandAlex_int;
        public int globalIdVanzare;

        public bool globalDBConnection;

        public List<ItemGVTotalModel> globalTotalServicii_Bon_List = new List<ItemGVTotalModel>();

        public List<ItemGVTotalModel> globalTotalProduse_Bon_List = new List<ItemGVTotalModel>();

        public HomePage()
        {
            InitializeComponent();
        }



        private void HomePage_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            labelDB.Text = "";

            buttonFinalizare.Enabled = false;
            buttonFinalizare.BackColor = Color.Gray;


            if (HomePageLoaded != null)
            {

                HomePageLoaded(sender, e);
            }

        }



        private int FindElementIndex(object nume, object pret)
        {
            int retindex = 0;

            foreach (DataGridViewRow row in dataGridViewTotalClient.Rows)
            {
                if (
                    row.Cells[0].Value.ToString().Trim() == nume.ToString()
                    && row.Cells[2].Value.ToString().Trim() == pret.ToString()
                    )
                {

                    retindex = row.Index;

                }
                else
                {

                }


            }



            return retindex;

        }

        private bool ElementExists(object nume, object pret)
        {
            bool retval = false;
            int duplicatesfound = 0;

            foreach (DataGridViewRow row in dataGridViewTotalClient.Rows)
            {
                if (
                    row.Cells[0].Value.ToString().Trim() == nume.ToString().Trim()
                    && row.Cells[2].Value.ToString().Trim() == pret.ToString().Trim()
                    )
                {

                    duplicatesfound++;

                }
                else
                {

                }


            }


            if (duplicatesfound > 0)
            {
                retval = true;
            }
            else
            {

                retval = false;
            }


            return retval;
        }


        public void CalcularePretTotal()
        {
            Pret_Total_Decimal = 0;

            foreach (DataGridViewRow row in dataGridViewTotalClient.Rows)
            {

                Decimal pret = Decimal.Parse(row.Cells[2].Value.ToString().Trim());
                int cantitate = Convert.ToInt32(row.Cells[1].Value.ToString().Trim());

                Pret_Total_Decimal += pret * cantitate;


            }

            labelTotal.Text = Pret_Total_Decimal.ToString() + " lei";


        }

        private void ShowPanel(Panel subMenu)
        {

            if (subMenu.Visible == false)
            {

                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;

            }


        }

        private void labelTitluMeniu_Click(object sender, EventArgs e)
        {
            ShowPanel(panelSideMenu);
        }

        private void labelTitluDetalii_Click(object sender, EventArgs e)
        {
            ShowPanel(panelDetalii);
        }

        private void pictureBoxDetalii_Click(object sender, EventArgs e)
        {
            ShowPanel(panelDetalii);
        }

        private void pictureBoxMeniu_Click(object sender, EventArgs e)
        {
            ShowPanel(panelSideMenu);
        }


        private void stergeElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.dataGridViewTotalClient.Rows[this.IndexRandAlex_int].IsNewRow)
            {
                this.dataGridViewTotalClient.Rows.RemoveAt(this.IndexRandAlex_int);
            }

            CalcularePretTotal();

        }

        private void dataGridViewTotalClient_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex <= dataGridViewTotalClient.RowCount)
            {

                if (e.Button == MouseButtons.Right)
                {
                    this.dataGridViewTotalClient.Rows[e.RowIndex].Selected = true;

                    this.IndexRandAlex_int = e.RowIndex;

                    this.contextMenuStripStegeElement.Show(this.dataGridViewTotalClient, e.Location);

                    contextMenuStripStegeElement.Show(Cursor.Position);
                }
            }
        }


        private void buttonFinalizare_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Inregistrare vanzare?", "Bon consum vanzare", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)

            {

                if (this.dataGridViewTotalClient.Rows.Count > 0)
                {

                    if (ButtonInregistrareVanzarePressed != null)
                    {
                        ButtonInregistrareVanzarePressed(sender, e);
                    }

                    if ((Application.OpenForms["VanzariAzi"] as VanzariAzi) != null)
                    {
                        VanzariAzi VanzariAziInstance = (VanzariAzi)Application.OpenForms["VanzariAzi"];
                        VanzariAziInstance.Close();
                    }

                }

            }


        }


        private void closeFormVanzariAzi(object sender, EventArgs e)
        {
            VanzariAzi.ActiveForm.Dispose();
        }

        public void View_VanzareProdus()
        {

            foreach (DataGridViewRow row in dataGridViewTotalClient.Rows)
            {

                if (row.Cells[3].Value.ToString().Trim() == "p")
                {

                    String NumeProdus = row.Cells[0].Value.ToString().Trim();
                    int IdProdus = Convert.ToInt32(row.Cells[4].Value.ToString().Trim());
                    String Tip = row.Cells[3].Value.ToString().Trim();
                    int Cantitate = Convert.ToInt32(row.Cells[1].Value.ToString().Trim());
                    Decimal pretUnitate = Decimal.Parse(row.Cells[2].Value.ToString().Trim());
                    Decimal pretTotal = pretUnitate * Cantitate;

                    ItemGVTotalModel Produs = new ItemGVTotalModel(NumeProdus, IdProdus, Tip, pretTotal, Cantitate);

                    globalTotalProduse_Bon_List.Add(Produs);


                }

            }

        }

        public void View_VanzareServiciu()
        {

            foreach (DataGridViewRow row in dataGridViewTotalClient.Rows)
            {

                if (row.Cells[3].Value.ToString().Trim() == "s")
                {

                    String NumeServiciu = row.Cells[0].Value.ToString().Trim();
                    int IdServiciu = Convert.ToInt32(row.Cells[4].Value.ToString().Trim());
                    String Tip = row.Cells[3].Value.ToString().Trim();
                    int Cantitate = Convert.ToInt32(row.Cells[1].Value.ToString().Trim());
                    Decimal pretUnitate = Decimal.Parse(row.Cells[2].Value.ToString().Trim());
                    Decimal pretTotal = pretUnitate * Cantitate;


                    ItemGVTotalModel Serviciu = new ItemGVTotalModel(NumeServiciu, IdServiciu, Tip, pretTotal, Cantitate);
                    globalTotalServicii_Bon_List.Add(Serviciu);

                }


            }


        }

        private void dataGridViewTotalClient_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (this.dataGridViewTotalClient.Rows.Count == 0)
            {

                buttonFinalizare.Enabled = false;
                buttonFinalizare.BackColor = Color.Gray;
            }
        }

        private void comboBoxNrInmatriculare_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flagNoClientiNumere_bool == false)
            {
                NrMasina_Ales_String = (String)comboBoxNrInmatriculare.Text;
            }
        }

        private void comboBoxClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flagNoClientiNumere_bool == false)
            {
                Client_Ales_int = (int)comboBoxClient.SelectedValue;

            }
        }

        private void buttonSubMenuTotalZi_Click(object sender, EventArgs e)
        {

            if ((Application.OpenForms["VanzariAzi"] as VanzariAzi) != null)
            {

                VanzariAzi VanzariAziInstance = (VanzariAzi)Application.OpenForms["VanzariAzi"];
                VanzariAziInstance.BringToFront();

            }
            else
            {
                
                if(VanzariAziRequested != null)
                {

                    VanzariAziRequested(sender,e);
                }
                
            }


        }


        private void dataGridViewProduse_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (global_flag_Unusable == false)
            {

                if (e.RowIndex >= 0 && e.RowIndex <= dataGridViewProduse.RowCount)
                {
                    //get values from produse dgv
                    var Nume = dataGridViewProduse.Rows[e.RowIndex].Cells[0].Value;
                    var Pret = dataGridViewProduse.Rows[e.RowIndex].Cells[3].Value;

                    var Id = dataGridViewProduse.Rows[e.RowIndex].Cells[4].Value;

                    var Cantitate = dataGridViewProduse.Rows[e.RowIndex].Cells[5].Value;

                    if (ElementExists(Nume, Pret))
                    {


                        int index_element = FindElementIndex(Nume, Pret);

                        if (Convert.ToInt32(Cantitate) > Convert.ToInt32(dataGridViewTotalClient.Rows[index_element].Cells[1].Value))
                        {


                            String Cantitate_String_IN = dataGridViewTotalClient.Rows[index_element].Cells[1].Value.ToString();

                            int Cantitate_int_IN = Convert.ToInt32(Cantitate_String_IN);
                            Cantitate_int_IN += 1;

                            dataGridViewTotalClient.Rows[index_element].Cells[1].Value = Cantitate_int_IN;

                            CalcularePretTotal();

                            MessageBox.Show("Cantitate crescuta [" + Nume.ToString() + "]!","Cantitate crescuta!",MessageBoxButtons.OK,MessageBoxIcon.Information);


                            buttonFinalizare.Enabled = true;

                            buttonFinalizare.BackColor = Color.LimeGreen;
                        }
                        else
                        {
                            MessageBox.Show("Produsul nu a fost adaugat pe bon! Cantitate disponibila: " + Cantitate.ToString(), "Produsul nu a fost adaugat!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }


                    }
                    else
                    {

                        this.dataGridViewTotalClient.Rows.Add(Nume, 1, Pret, "p", Id);
                        CalcularePretTotal();

                        MessageBox.Show("Produs [" + Nume.ToString() + "] adaugat pe bon!", "Produse adaugat pe bon!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        buttonFinalizare.Enabled = true;

                        buttonFinalizare.BackColor = Color.LimeGreen;

                    }

                }

            }
        }

        private void dataGridViewServicii_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (global_flag_Unusable == false)
            {

                if (e.RowIndex >= 0 && e.RowIndex <= dataGridViewServicii.RowCount)
                {
                    //get values from servicii dgv
                    var Nume = dataGridViewServicii.Rows[e.RowIndex].Cells[0].Value;
                    var Pret = dataGridViewServicii.Rows[e.RowIndex].Cells[2].Value;

                    var Id = dataGridViewServicii.Rows[e.RowIndex].Cells[3].Value;


                    if (ElementExists(Nume, Pret))
                    {

                        int index_element = FindElementIndex(Nume, Pret);

                        String Cantitate_String_IN = dataGridViewTotalClient.Rows[index_element].Cells[1].Value.ToString();

                        int Cantitate_int_IN = Convert.ToInt32(Cantitate_String_IN);
                        Cantitate_int_IN += 1;

                        dataGridViewTotalClient.Rows[index_element].Cells[1].Value = Cantitate_int_IN;

                        CalcularePretTotal();

                        MessageBox.Show("Cantitate crescuta [" + Nume.ToString() + "]!", "Cantitate crescuta!", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        buttonFinalizare.Enabled = true;

                        buttonFinalizare.BackColor = Color.LimeGreen;
                    }
                    else
                    {

                        this.dataGridViewTotalClient.Rows.Add(Nume, 1, Pret, "s", Id);
                        CalcularePretTotal();


                        MessageBox.Show("Serviciu [" + Nume.ToString() + "] adaugat pe bon!", "Serviciul a fost adaugat pe bon!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        buttonFinalizare.Enabled = true;

                        buttonFinalizare.BackColor = Color.LimeGreen;

                    }

                }

            }
        }


        private void labelNrInmatriculare_Click(object sender, EventArgs e)
        {
            comboBoxNrInmatriculare.Focus();
        }

        private void labelClient_Click(object sender, EventArgs e)
        {
            comboBoxClient.Focus();
        }

        private void HomePage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {

                DialogResult dresult = MessageBox.Show("Inchideti aplicatia?", "Atentie!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dresult != DialogResult.OK)
                {
                    e.Cancel = true;
                }
                else
                {

                    Application.ExitThread();

                    Environment.Exit(Environment.ExitCode);

                }

            }
            if (e.CloseReason == CloseReason.WindowsShutDown)
            {


            }
        }

        private void pictureBoxRefreshPS_Click(object sender, EventArgs e)
        {

            if (!global_flag_Unusable && !flagNoClientiNumere_bool)
            {
                if(BindGridProduseServicii != null)
                {
                    BindGridProduseServicii(sender, e);

                }

                MessageBox.Show("Lista produse si servici reimprospatata!","Liste reimprospatate!",MessageBoxButtons.OK,MessageBoxIcon.Information);

            }


        }



        public void DatabaseConnectionOk()
        {
            labelDB.Text = "Conexiune la baza de date reusita!";
            pictureBoxDB.Visible = true;
            globalDBConnection = true;
        }

        public void DatabaseConnectionFailed()
        {
            labelDB.ForeColor = Color.Red;
            labelDB.Text = "Conexiune la baza de date nereusita!";
            globalDBConnection = false;

        }

        public void BindDTtoGridProduse(DataTable DT)
        {
            dataGridViewProduse.AutoGenerateColumns = false;
            dataGridViewProduse.DataSource = DT;

        }

        public void BindDTtoGridServicii(DataTable DT)
        {
            dataGridViewServicii.AutoGenerateColumns = false;
            dataGridViewServicii.DataSource = DT;

        }

        public void ProduseReadFailed()
        {
            MessageBox.Show("Nici un produs in stoc!", "Nu exista nici un produs in baza de date!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            dataGridViewProduse.DataSource = null;
            global_flag_Unusable = true;

        }

        public void ServiciiReadFailed()
        {

            dataGridViewServicii.DataSource = null;
            MessageBox.Show("Nici un serviciu in baza de date!", "Nu exista nici un serviciu in baza de date!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            global_flag_Unusable = true;
        }


        public void AllDataReadSuccesfullOnLoad()
        {

            flagNoClientiNumere_bool = false;
            global_flag_Unusable = false;

            comboBoxClient.DisplayMember = "NumeClient";
            comboBoxClient.ValueMember = "IdClient";
            comboBoxClient.DataSource = DataTableClienti;

            comboBoxClient.SelectedIndex = 0;

            comboBoxNrInmatriculare.DisplayMember = "NrInmatriculare";
            comboBoxNrInmatriculare.ValueMember = "IdNrInmatriculare";
            comboBoxNrInmatriculare.DataSource = DataTableNrInm;

            comboBoxNrInmatriculare.SelectedIndex = 0;

        }

        public void AllDataReadFailedOnLoad()
        {

            global_flag_Unusable = true;
            flagNoClientiNumere_bool = true;

            ComboBoxItemModel CBIModel = new ComboBoxItemModel();
            CBIModel.Text = "---";
            CBIModel.Value = 1;

            comboBoxClient.Items.Add(CBIModel);
            comboBoxClient.SelectedIndex = 0;

            comboBoxNrInmatriculare.Items.Add(CBIModel);
            comboBoxNrInmatriculare.SelectedIndex = 0;



            MessageBox.Show("Datele necesare nu exista in baza de date!\nContacteaza administrator!", "Datele necesare nu exista!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void VanzareInregistrataSuccessfull()
        {
            MessageBox.Show("Vanzare (" + Pret_Total_Decimal + "lei) inregistrata in baza de date!\n(" + System.DateTime.Now + ")", "Vanzare inregistrata cu sucess!", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        public void VanzareInregistrataFailed()
        {

            MessageBox.Show("Inregistrare vanzare esuata!", "Conexiune cu baza de date nereusita!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        public void DisplayStatusVanzareProdusInregistrata(int NumarVanzariProduse, StringBuilder ProdusePeBon)
        {

            MessageBox.Show("Numar produse pe bon" + ":" + NumarVanzariProduse.ToString() + "\n" + ProdusePeBon, "Bon consum produse", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void DisplayStatusVanzareServiciuInregistrata(int NumarVanzariServicii, StringBuilder ServiciiPeBon)
        {

            MessageBox.Show("Numar servicii pe bon" + ":" + NumarVanzariServicii.ToString() + "\n" + ServiciiPeBon, "Inregistrare vanzari servicii", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ClearRowsTotalClient()
        {
            dataGridViewTotalClient.Rows.Clear();
        }


        public void BindGrids()
        {

            if (BindGridProduseServicii != null)
            {
                BindGridProduseServicii(null, null);

            }

        }
        public HomePage getThisForm()
        {
            return this;
        }
    }

}



    
    
    
    
    
  
