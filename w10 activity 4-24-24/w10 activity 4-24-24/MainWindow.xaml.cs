using System;
using System.Windows;
using System.Windows.Controls;

namespace InventorySystem
{
    public partial class MainWindow : Window
    {
        public static int MaxInventoryCapacity = 100;
        public static string[,] inventory = new string[MaxInventoryCapacity, 3];
        public static int numItems = 0;
        private InventoryAddManager inventoryManager;

        public MainWindow()
        {
            InitializeComponent();
            inventoryManager = new InventoryAddManager();
        }

        private void Additem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                InventoryAddManager.AddItem(ItemNameTxtBox.Text, PriceTxtBox.Text, QuanTxtBox.Text);
                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Displayinventory_Click(object sender, RoutedEventArgs e)
        {
            InventoryDisplayManager.DisplayInventory(InventoryListBox);
        }

        private void Printbill_Click(object sender, RoutedEventArgs e)
        {
            BillingManager.PrintBilling(ItemNameTxtBox.Text, QuanTxtBox.Text, InventoryListBox);
            ClearInputFields();
        }

        private void ClearInputFields()
        {
            ItemNameTxtBox.Clear();
            PriceTxtBox.Clear();
            QuanTxtBox.Clear();
        }

        private void RemovePlaceholder(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Enter Item Name" || textBox.Text == "Enter Price" || textBox.Text == "Enter Quantity")
            {
                textBox.Text = "";
                textBox.Foreground = System.Windows.Media.Brushes.Black;
            }
        }

        private void AddPlaceholder(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                if (textBox == ItemNameTxtBox)
                    textBox.Text = "Enter Item Name";
                else if (textBox == PriceTxtBox)
                    textBox.Text = "Enter Price";
                else if (textBox == QuanTxtBox)
                    textBox.Text = "Enter Quantity";

                textBox.Foreground = System.Windows.Media.Brushes.Gray;
            }
        }

        private void ExitApp_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
