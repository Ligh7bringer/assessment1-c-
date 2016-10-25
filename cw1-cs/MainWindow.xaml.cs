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

        Attendee attendee1 = new Attendee(); //publicly accessible attendee object. does it go somewhere else?
        private void btn_set_Click(object sender, RoutedEventArgs e)
        {
            //set the parameters to user input and catch some exceptions (if any)
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

            try
            {
                attendee1.RegistrationType = txtbox_regtype.Text;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }

            attendee1.Paid = false;
            if (cbox_paid.IsChecked.Value)
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
            //clean up
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

        private void btn_get_Click(object sender, RoutedEventArgs e)
        {
            //load values from attendee1 into the textboxes and checkboxes
            txtbox_firstn.Text = attendee1.FirstName;
            txtbox_lastn.Text = attendee1.SecondName;
            txtbox_ref.Text = Convert.ToString(attendee1.AttendeeRef);
            txtbox_institution.Text = attendee1.InstitutionName;
            txtbox_conference.Text = attendee1.ConferenceName;
            txtbox_regtype.Text = attendee1.RegistrationType;
            txtbox_paper.Text = attendee1.PaperTitle;
            if(attendee1.Paid == true)
            {
                cbox_paid.IsChecked = true;
            } 
            else
            {
                cbox_paid.IsChecked = false;
            }

            if (attendee1.Presenter == true)
            {
                cbox_presenter.IsChecked = true;
            }
            else
            {
                cbox_presenter.IsChecked = false;
            }
        }

        //when button invoice is clicked
        private void btn_invoice_Click(object sender, RoutedEventArgs e)
        {
            Invoice InvoiceWin = new Invoice();

            //create invoice window, find it and change values in it
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(Invoice))
                {
                    (window as Invoice).lbox_fname.Items.Add(attendee1.FirstName + " " + attendee1.SecondName);
                    (window as Invoice).lbox_institution.Items.Add(attendee1.InstitutionName);
                    (window as Invoice).lbox_conference.Items.Add(attendee1.ConferenceName);
                    (window as Invoice).lbox_price.Items.Add("£" + attendee1.getCost());
                }
            }
            //show window and display stuff
            InvoiceWin.ShowDialog();
        }

        //when certificate button is clicked
        private void btn_cert_Click(object sender, RoutedEventArgs e)
        {
            //create a new window
            Certificate certWin = new Certificate();

            //pass values
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(Certificate))
                {
                    (window as Certificate).lbox_cert.Items.Add("This is to certify that " + attendee1.FirstName + " " + attendee1.SecondName + " attended " + attendee1.ConferenceName);
                    if (attendee1.Presenter)
                    {
                        (window as Certificate).lbox_cert.Items.Add(" and presented a paper entitled " + attendee1.PaperTitle);
                    }
                }
            }
            certWin.ShowDialog();
        }
    }
}
