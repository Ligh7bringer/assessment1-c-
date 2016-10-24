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

/********************************************************************************
* Author: Svetlozar Georgiev, 40203970                                          *
* Date of last change: 08/10/2017                                               *
* Main window                                                                   *
* Handles adding of attendees, getting certificates and invoices                *
********************************************************************************/

namespace cw1_cs
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Attendee attendee1 = new Attendee();
        private void btn_set_Click(object sender, RoutedEventArgs e)
        {
            //create new attendee object and set the parameters to user input
            try
            {
                attendee1.AttendeeRef = Int32.Parse(txtbox_ref.Text);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                attendee1.FirstName = txtbox_firstn.Text;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                attendee1.SecondName = txtbox_lastn.Text;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }

            attendee1.InstitutionName = txtbox_institution.Text;

            try
            {
                attendee1.ConferenceName = txtbox_conference.Text;

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }

            attendee1.Paid = false;
            if(cbox_paid.IsChecked.Value)
            {
                attendee1.Paid = true;
            }
            attendee1.Presenter = false;
            if (cbox_presenter.IsChecked.Value)
            {
                attendee1.Presenter = true;
            }

            try
            {
                attendee1.PaperTitle = txtbox_paper.Text;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btn_clear_Click(object sender, RoutedEventArgs e)
        {
            txtbox_firstn.Clear();
            txtbox_lastn.Clear();
            txtbox_ref.Clear();
            txtbox_institution.Clear();
            txtbox_conference.Clear();
            txtbox_regtype.Clear();
            txtbox_paper.Clear();
            cbox_paid.IsChecked = false;
            cbox_presenter.IsChecked = false;

        }
    }
}
