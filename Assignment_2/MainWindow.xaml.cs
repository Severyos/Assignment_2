﻿using Assignment_2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Xml.Linq;

namespace Assignment_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<ContactPerson> contacts;

        public MainWindow()
        {
            InitializeComponent();
            contacts = new ObservableCollection<ContactPerson>();
            lv_Contacts.ItemsSource = contacts;
        }
        // Metod för att lägga till kontakter till listan (knapp)
        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            var contact = contacts.FirstOrDefault(x => x.Email == tb_Email.Text);
            if (contact == null)
            {
                contacts.Add(new ContactPerson
                {
                    FirstName = tb_FirstName.Text,
                    LastName = tb_LastName.Text,
                    Email = tb_Email.Text,
                    StreetName = tb_StreetName.Text,
                    PostalCode = tb_PostalCode.Text,
                    City = tb_City.Text
                });
            }
            else
            {
                MessageBox.Show("Det finns redan en kontakt med samma e-postadress.");
            }

            ClearFields();
        }
        // Rensar fälten där man skriver information om en kontakt
        private void ClearFields()
        {
            tb_FirstName.Text = "";
            tb_LastName.Text = "";
            tb_Email.Text = "";
            tb_StreetName.Text = "";
            tb_PostalCode.Text = "";
            tb_City.Text = "";
        }
        // Metod för att kunna ta bort kontaker från listan (knapp)
        private void btn_Remove_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var contact = (ContactPerson)button!.DataContext;

            contacts.Remove(contact);
        }
        // Ser all detaljerad information om en kontakt
        private void lv_Contacts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var contact = (ContactPerson)lv_Contacts.SelectedItems[0]!;
            tb_FirstName.Text = contact.FirstName;
            tb_LastName.Text = contact.LastName;
            tb_Email.Text = contact.Email;
            tb_StreetName.Text = contact.StreetName;
            tb_PostalCode.Text = contact.PostalCode;
            tb_City.Text = contact.City;

        }
        // Metod för att kunna uppdatera kontakternas information (knapp)
        private void btn_Update_Click(object sender, RoutedEventArgs e)
        {
            var contact = (ContactPerson)lv_Contacts.SelectedItems[0]!;
            
            {
                contact.FirstName = tb_FirstName.Text;
                contact.LastName = tb_LastName.Text;
                contact.Email = tb_Email.Text;
                contact.StreetName = tb_StreetName.Text;
                contact.PostalCode = tb_PostalCode.Text;
                contact.City = tb_City.Text;

                lv_Contacts.Items.Refresh();
            }

            ClearFields();
        }
    }
}

