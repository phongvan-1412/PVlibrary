using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using pvlibrary.Model.entities;
using System.Linq;
using System;
using System.Windows;

namespace pvlibrary.View
{
    public partial class Dashboard : UserControl
    {
        private static PVLibraryEntities pv = new PVLibraryEntities();

        //CartesianChart
        public SeriesCollection SalesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }

        //PieChart
        public SeriesCollection CategoryCollection { get; set; }

        //Top5Customer
        public List<CustomerStatistic> listCus = new List<CustomerStatistic>();

        public Dashboard()
        {
            InitializeComponent();
            Top5Customer();
            RevenueStatistic();
            CartesianChart();
            PieChart();
        }
        public void CartesianChart()
        {
            SalesCollection = new SeriesCollection();
            for (int i = DateTime.Today.Year - 3; i <= DateTime.Today.Year; i++)
            {
                var revenue = new ChartValues<decimal>();
                decimal monthRevenue = 0;

                for (int j = 1; j <= 12; j++)
                {
                    foreach (var item in pv.Bills)
                    {
                        if (DateTime.Parse(item.created_time).Year == i && DateTime.Parse(item.created_time).Month == j)
                        {
                            monthRevenue += item.bill_total;
                        }
                    }
                    revenue.Add(monthRevenue);
                    monthRevenue = 0;
                }

                var lineItem = new LineSeries
                {
                    Title = i.ToString(),
                    Values = revenue,
                    PointGeometry = DefaultGeometries.None,
                    PointGeometrySize = 10,
                };
                SalesCollection.Add(lineItem);
            }

            Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May", "June", "July", "Aug", "Sep", "Oct", "Nov", "Dec" };
            YFormatter = value => value.ToString("C");
            DataContext = this;
        }

        public void PieChart()
        {
            CategoryCollection = new SeriesCollection();
            foreach (var item in pv.Categories)
            {
                if (pv.Categories.First(a => a.cate_name.Equals(item.cate_name)).Books.Count() <= 0 ||
                    pv.BillDetails.Where(a => a.Book.Category.cate_name.Equals(item.cate_name)).Count() <= 0)
                    continue;
                var pieItem = new PieSeries
                {
                    Title = item.cate_name,
                    Values = new ChartValues<ObservableValue>
                        {new ObservableValue(CountSoldProduct(item.cate_name))},
                    DataLabels = true,
                };
                CategoryCollection.Add(pieItem);
            }
            DataContext = this;
        }
        private double CountSoldProduct(string cateName)
        {
            var list = pv.BillDetails.Where(a => a.Book.Category.cate_name.Equals(cateName));
            bool ck = Double.TryParse(list.Sum(b => b.bid_amount).ToString(), out double quantity);

            return quantity;
        }

        public void Top5Customer()
        {
            foreach (var item in pv.Customers)
                listCus.Add(new CustomerStatistic(item));

            foreach (var item in listCus.OrderByDescending(b => b.CusTotal).Take(5))
                ListCustomer.Items.Add(item);
        }

        public void RevenueStatistic()
        {
            //Total Books
            int bookSold = pv.BillDetails.Sum(bid => bid.bid_amount);
            lbBooksSold.Content = bookSold;

            //Total Revenue
            decimal totalRevenue = pv.Bills.Sum(b => b.bill_total);
            lbTotalRevenue.Content = $"{totalRevenue:C}";

            //Last year Revenue
            decimal lastYearRevenue = 0;

            foreach (var b in pv.Bills)
                if (DateTime.Parse(b.created_time).Year == DateTime.Today.Year - 1)
                    lastYearRevenue += b.bill_total;

            lbLastYearRevenue.Content = $"{lastYearRevenue:C}";
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            PageControl.Instance.Logout();
        }
    }
}
