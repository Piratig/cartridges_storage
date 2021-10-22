using Сartridges_storage.Model;
using Сartridges_storage.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Сartridges_storage.ViewModel
{
    public class DataManageVM : INotifyPropertyChanged
    {
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
        Delivery goDelivery = new Delivery();
        Digest goDigest = new Digest();
        Order goOrder = new Order();
        Purchase goPurchase = new Purchase();

        private void OpenDigestWidgetMethod()
        {
            goDigest.Visibility = Visibility.Visible;
            goDelivery.Visibility = Visibility.Hidden;
            goOrder.Visibility = Visibility.Hidden;
            goPurchase.Visibility = Visibility.Hidden;
        }
        private void OpenDeliveryWidgetMethod()
        {
            goDigest.Visibility = Visibility.Hidden;
            goDelivery.Visibility = Visibility.Visible;
            goOrder.Visibility = Visibility.Hidden;
            goPurchase.Visibility = Visibility.Hidden;
        }
        private void OpenOrderWidgetMethod()
        {
            goDigest.Visibility = Visibility.Hidden;
            goDelivery.Visibility = Visibility.Hidden;
            goOrder.Visibility = Visibility.Visible;
            goPurchase.Visibility = Visibility.Hidden;
        }
        private void OpenPurchaseWidgetMethod()
        {
            goDigest.Visibility = Visibility.Hidden;
            goDelivery.Visibility = Visibility.Hidden;
            goOrder.Visibility = Visibility.Hidden;
            goPurchase.Visibility = Visibility.Visible;
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
