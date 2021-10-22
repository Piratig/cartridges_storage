using System;
using System.Collections.Generic;
using System.Text;

namespace Сartridges_storage.Model
{
    class Cartridge
    {
        private string title;
        private string printer;
        private string c_color;
        private int storage_num;
        private int warehouse_nume;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Printer
        {
            get { return printer; }
            set { printer = value; }
        }
        public string C_color
        {
            get { return c_color; }
            set { c_color = value; }
        }
        public int Storage_num
        {
            get { return storage_num; }
            set { storage_num = value; }
        }
        public int Warehouse_nume
        {
            get { return warehouse_nume; }
            set { warehouse_nume = value; }
        }
    }
}
