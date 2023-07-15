using ControlzEx.Standard;
using pvlibrary.Model.entities;
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
using System.Windows.Shapes;

namespace pvlibrary.View
{
    /// <summary>
    /// Interaction logic for WaitListDetail.xaml
    /// </summary>
    public partial class WaitListDetail : Window
    {
        public WaitListDetail(BillDisplay bDisplay)
        {
            InitializeComponent();
            LoadData(bDisplay);
        }
        private void LoadData(BillDisplay bDisplay)
        {
            dgBidList.IsReadOnly = true;

            dgBidList.Items.Clear();
            foreach (var item in bDisplay.BidDisplays)
            {
                dgBidList.Items.Add(item);
            }
        }
    }
}
