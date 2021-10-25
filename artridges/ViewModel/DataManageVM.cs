using Сartridges_storage.Model;
using Сartridges_storage.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;

namespace Сartridges_storage.ViewModel
{
    public class DataManageVM : INotifyPropertyChanged
    {
        #region Declaration

        List<ForPie> p_com = new List<ForPie>();
        private List<Cartridge> cartridgesByInvList = new List<Cartridge>();
        private List<Cartridge> cartridgesList = new List<Cartridge>();
        private List<Transaction> inventaryCheck = new List<Transaction>();
        public List<Cartridge> CartridgesByInvList
        {
            get { return cartridgesByInvList; }
            set
            {
                cartridgesByInvList = value;
                NotifyPropertyChanged("CartridgesByInvList");
            }
        }
        public List<Cartridge> CartridgesList
        {
            get { return cartridgesList; }
            set
            {
                cartridgesList = value;
                NotifyPropertyChanged("CartridgesList");
            }
        }
        public List<Transaction> InventaryCheck
        {
            get { return inventaryCheck; }
            set
            {
                inventaryCheck = value;
                NotifyPropertyChanged("InventaryCheck");
            }
        }
        public SeriesCollection SeriesCollection { get; set; }

        Grid goDelivery = new Grid();
        Grid goDigest = new Grid();
        Grid goOrder = new Grid();
        Grid goPurchase = new Grid();

        private Grid goDigestV;
        private Grid goDeliveryV;
        private Grid goOrderV;
        private Grid goPurchaseV;
        private int warehouseMax;
        private int warehouseValue;
        private int storageMax;
        private int storageValue;
        private int invCheck;
        private string cartringeByInv;

        public Grid GoDigestV
        {
            get { return goDigestV; }
            set
            {
                goDigestV = value;
                NotifyPropertyChanged("GoDigestV");
            }
        }
        public Grid GoDeliveryV
        {
            get { return goDeliveryV; }
            set
            {
                goDeliveryV = value;
                NotifyPropertyChanged("GoDeliveryV");
            }
        }
        public Grid GoOrderV
        {
            get { return goOrderV; }
            set
            {
                goOrderV = value;
                NotifyPropertyChanged("GoOrderV");
            }
        }
        public Grid GoPurchaseV
        {
            get { return goPurchaseV; }
            set
            {
                goPurchaseV = value;
                NotifyPropertyChanged("GoPurchaseV");
            }
        }
        public int InvCheck
        {
            get { return invCheck; }
            set
            {
                invCheck = value;
                NotifyPropertyChanged("InvCheck");
            }
        }
        public int WarehouseMax
        {
            get { return warehouseMax; }
            set
            {
                warehouseMax = value;
                NotifyPropertyChanged("WarehouseMax");
            }
        }
        public int WarehouseValue
        {
            get { return warehouseValue; }
            set
            {
                warehouseValue = value;
                NotifyPropertyChanged("WarehouseValue");
            }
        }
        public int StorageMax
        {
            get { return storageMax; }
            set
            {
                storageMax = value;
                NotifyPropertyChanged("StorageMax");
            }
        }
        public int StorageValue
        {
            get { return storageValue; }
            set
            {
                storageValue = value;
                NotifyPropertyChanged("StorageValue");
            }
        }
        public string CartringeByInv
        {
            get { return cartringeByInv; }
            set
            {
                cartringeByInv = value;
                NotifyPropertyChanged("CartringeByInv");
            }
        }

        #endregion

        private RelayCommand inventaryCheckCommand;
        public RelayCommand InventaryCheckCommand
        {
            get
            {
                return inventaryCheckCommand ?? new RelayCommand(obj =>
                {
                    InventoryCheckMethod();
                });
            }
        }


        #region Load
        // Load command
        private RelayCommand loadedCommand;
        public RelayCommand LoadedCommand
        {
            get
            {
                return loadedCommand ?? new RelayCommand(obj =>
                {
                    OpenDigestWidgetMethod();
                    PieFiller();
                    DigestCartridgeList();
                });
            }
        }

        #endregion

        #region COMMANDS TO CHANGE WIDGET

        private RelayCommand openDigestWidget;
        public RelayCommand OpenDigestWidget
        {
            get
            {
                return openDigestWidget ?? new RelayCommand(obj =>
                {
                    OpenDigestWidgetMethod();
                });
            }
        }
        private RelayCommand openDeliveryWidget;
        public RelayCommand OpenDeliveryWidget
        {
            get
            {
                return openDeliveryWidget ?? new RelayCommand(obj =>
                {
                    OpenDeliveryWidgetMethod();
                });
            }
        }
        private RelayCommand openOrderWidget;
        public RelayCommand OpenOrderWidget
        {
            get
            {
                return openOrderWidget ?? new RelayCommand(obj =>
                {
                    OpenOrderWidgetMethod();
                });
            }
        }
        private RelayCommand openPurchaseWidget;
        public RelayCommand OpenPurchaseWidget
        {
            get
            {
                return openPurchaseWidget ?? new RelayCommand(obj =>
                {
                    OpenPurchaseWidgetMethod();
                });
            }
        }
        #endregion

        #region MATHODS
        public void DigestCartridgeList()
        {
            CartridgesList = Queries.List_output();
        }

        public void PieFiller()
        {
            p_com = Queries.PrintersForPie();
            SeriesCollection = new SeriesCollection();

            foreach (ForPie i in p_com)
            {
                SeriesCollection.Add(new PieSeries()
                {
                    Title = i.PrinterName,
                    Values = new ChartValues<ObservableValue> { new ObservableValue(i.PrinterNum) },
                    DataLabels = true
                });
            }
            NotifyPropertyChanged("SeriesCollection");
            StorageValue = Queries.StorageValue();
            WarehouseValue = Queries.WarehouseValue();
            StorageMax = 500;
            WarehouseMax = 1000;
        }

        public void InventoryCheckMethod()
        {
            InventaryCheck = Queries.PrintersInventoryNumberCheck(InvCheck);
            if (InvCheck > 0)
            {
                CartridgesByInvList = Queries.CartridgesByInventoryNumberCheck(InvCheck);
            }
        }

        private void OpenDigestWidgetMethod()
        {
            goDigest.Visibility = Visibility.Visible;
            goDelivery.Visibility = Visibility.Hidden;
            goOrder.Visibility = Visibility.Hidden;
            goPurchase.Visibility = Visibility.Hidden;
            GoDigestV = goDigest;
            GoDeliveryV = goDelivery;
            GoOrderV = goOrder;
            GoPurchaseV = goPurchase;
        }
        private void OpenDeliveryWidgetMethod()
        {
            goDigest.Visibility = Visibility.Hidden;
            goDelivery.Visibility = Visibility.Visible;
            goOrder.Visibility = Visibility.Hidden;
            goPurchase.Visibility = Visibility.Hidden;
            GoDigestV = goDigest;
            GoDeliveryV = goDelivery;
            GoOrderV = goOrder;
            GoPurchaseV = goPurchase;
        }
        private void OpenOrderWidgetMethod()
        {
            goDigest.Visibility = Visibility.Hidden;
            goDelivery.Visibility = Visibility.Hidden;
            goOrder.Visibility = Visibility.Visible;
            goPurchase.Visibility = Visibility.Hidden;
            GoDigestV = goDigest;
            GoDeliveryV = goDelivery;
            GoOrderV = goOrder;
            GoPurchaseV = goPurchase;
        }
        private void OpenPurchaseWidgetMethod()
        {
            goDigest.Visibility = Visibility.Hidden;
            goDelivery.Visibility = Visibility.Hidden;
            goOrder.Visibility = Visibility.Hidden;
            goPurchase.Visibility = Visibility.Visible;
            GoDigestV = goDigest;
            GoDeliveryV = goDelivery;
            GoOrderV = goOrder;
            GoPurchaseV = goPurchase;
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
