using System;

namespace ManagerVanzari
{
    public class ItemGVTotalModel
    {

        private string nume;
        private int id;
        private string tip;
        private Decimal pret;
        private int cantitate;

        public ItemGVTotalModel(string nume, int id, string tip, decimal pret, int cantitate)
        {
            this.nume = nume;
            this.id = id;
            this.tip = tip;
            this.pret = pret;
            this.cantitate = cantitate;
        }

        public string Nume { get => nume; set => nume = value; }
        public int Id { get => id; set => id = value; }
        public string Tip { get => tip; set => tip = value; }
        public decimal Pret { get => pret; set => pret = value; }
        public int Cantitate { get => cantitate; set => cantitate = value; }
    }
}