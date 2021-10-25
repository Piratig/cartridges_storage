namespace Сartridges_storage.Model
{
    public class Cartridge
    {
        private int cartridgeId;
        private string title;
        private string printer;
        private string cartridgeColor;
        private int storageNum;
        private int warehouseNume;

        public int CartridgeId
        {
            get { return cartridgeId; }
            set { cartridgeId = value; }
        }
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
        public string CartridgeColor
        {
            get { return cartridgeColor; }
            set { cartridgeColor = value; }
        }
        public int StorageNum
        {
            get { return storageNum; }
            set { storageNum = value; }
        }
        public int WarehouseNume
        {
            get { return warehouseNume; }
            set { warehouseNume = value; }
        }
    }
}
