using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Configurations;
using LiveCharts.Defaults;
using LiveCharts.Wpf.Points;

namespace Сartridges_storage.View
{
    /// <summary>
    /// Логика взаимодействия для Digest.xaml
    /// </summary>
    public partial class Digest : UserControl
    {
        public Digest()
        {
            InitializeComponent();

            SeriesCollection = new SeriesCollection();

            SeriesCollection.Add(new PieSeries()
            {
                Title = t,
                Values = new ChartValues<ObservableValue> { new ObservableValue(a) },
                DataLabels = true
            }); ;

            DataContext = this;
        }


        int a = 54;
        string t = "HP";


        public SeriesCollection SeriesCollection { get; set; }

    }
}
