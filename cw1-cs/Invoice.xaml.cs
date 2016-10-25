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

/********************************************************************************
* Author: Svetlozar Georgiev, 40203970                                          *
* Date of last change: 25/10/2016                                               *
* Invoice window                                                                *
* Displays an invoice with the attendee's information and the price they need   *
* to                                                                            *
********************************************************************************/

namespace cw1_cs
{
    public partial class Invoice : Window
    {
        public Invoice()
        {
            InitializeComponent();
        }

        //close window on button click
        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
