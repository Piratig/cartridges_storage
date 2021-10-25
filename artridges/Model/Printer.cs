namespace Сartridges_storage.Model
{
    class Printer
    {
        private int inventory_number;
        private string p_compony;
        private string p_name;
        private int printer_Id;


        public int Inventory_number
        {
            get { return inventory_number; }
            set { inventory_number = value; }
        }
        public string P_compony
        {
            get { return p_compony; }
            set { p_compony = value; }
        }
        public string P_name
        {
            get { return p_name; }
            set { p_name = value; }
        }
        public int Printer_Id
        {
            get { return printer_Id; }
            set { printer_Id = value; }
        }

    }
}
