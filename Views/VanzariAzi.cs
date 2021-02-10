using ManagerVanzari.Views;
using System;
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
    public partial class VanzariAzi : Form, VanzariAzi_I
    {


        public event EventHandler VanzariAziLoaded;
        public event EventHandler StergeVanzareToolStripPressed;

        private HomePage HomepageInstance = null;

        public int IndexRand_int = 0;
        public int IdAles_int = 0;

        public bool VanzareStearsa;

        public VanzariAzi(HomePage HPInstance)
        {
            InitializeComponent();

            HomepageInstance = HPInstance;
        }

        private void VanzariAzi_Form_Load(object sender, EventArgs e)
        {
            if(VanzariAziLoaded!= null)
            {
                VanzariAziLoaded(sender,e);
            }
        }


        private void SergeVanzareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.contextMenuStripStergeVanzare.Hide();


            if (!VanzareStearsa)
            {

                if (this.IndexRand_int >= 0 && this.IndexRand_int <= dataGridViewVanzari.RowCount)
                {

                    DialogResult dresult = MessageBox.Show("Stergi vanzare din baza de date? ", "Atentie!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dresult == DialogResult.OK)
                    {


                        if(StergeVanzareToolStripPressed != null)
                        {
                            StergeVanzareToolStripPressed(sender, e);
                        }

                        HomepageInstance.BindGrids();

                    }

                }
            }
            else
            {
                MessageBox.Show("Vanzare deja stearsa. Nu poti sterge!", "Operatie nereusita!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewVanzari_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex <= dataGridViewVanzari.RowCount)
            {

                if (e.Button == MouseButtons.Right)
                {
                    this.dataGridViewVanzari.Rows[e.RowIndex].Selected = true;


                    this.IndexRand_int = e.RowIndex;

                    this.IdAles_int = Convert.ToInt32(dataGridViewVanzari.Rows[e.RowIndex].Cells[0].Value);

                    this.VanzareStearsa = Convert.ToBoolean(dataGridViewVanzari.Rows[e.RowIndex].Cells[5].Value);

                    this.contextMenuStripStergeVanzare.Show(this.dataGridViewVanzari, e.Location);

                    contextMenuStripStergeVanzare.Show(Cursor.Position);
                }
            }
        }

        public void BindDTtoGridVanzari(DataTable DT)
        {
            dataGridViewVanzari.AutoGenerateColumns = false;
            dataGridViewVanzari.DataSource = DT;

        }

        public void VanzariReadFailed()
        {
            MessageBox.Show("Nici o vanzare inregistrata azi!", "Nu exista vanzari in baza de date!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            dataGridViewVanzari.DataSource = null;

        }


        public void DeleteVanzareSuccessfull()
        {
            MessageBox.Show("Vanzare stearsa din baza de date!", "Vanzare stearsa!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (!this.dataGridViewVanzari.Rows[this.IndexRand_int].IsNewRow)
            {
                this.dataGridViewVanzari.Rows.RemoveAt(this.IndexRand_int);
            }

        }

        public void DeleteVanzareFailed()
        {

            MessageBox.Show("Stergere vanzare nereusita!", "Stergere nereusita!", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

    }
}
