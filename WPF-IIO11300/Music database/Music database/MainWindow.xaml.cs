﻿using System;
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
using MySql.Data.MySqlClient;
using System.Data;

namespace MusicDatabase {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private List<Artist> artists;
        public MainWindow() {
            InitializeComponent();
        }

        private void btnSearchFromDatabase_Click(object sender, RoutedEventArgs e) {

        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e) {

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e) {

        }

        private void testConnection_Click(object sender, RoutedEventArgs e) {
            try {
                artists = Artist.GetArtists();
                dgTest.DataContext = artists;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}