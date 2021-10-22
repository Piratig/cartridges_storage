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
        private RelayCommand loadedCommand;
        public RelayCommand LoadedCommand
        {
            get
            {
                return loadedCommand ?? new RelayCommand(obj =>
                {
                    PieFiller();
                });
            }
        }

        public SeriesCollection SeriesCollection { get; set; }

        public void PieFiller()
        {
            SeriesCollection = new SeriesCollection();

            SeriesCollection.Add(new PieSeries()
            {
                Title = "HP",
                Values = new ChartValues<ObservableValue> { new ObservableValue(25) },
                DataLabels = true
            });
            NotifyPropertyChanged("SeriesCollection");
            
        }

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
        Grid goDelivery = new Grid();
        Grid goDigest = new Grid();
        Grid goOrder = new Grid();
        Grid goPurchase = new Grid();

        private Grid goDigestV;
        private Grid goDeliveryV;
        private Grid goOrderV;
        private Grid goPurchaseV;

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
