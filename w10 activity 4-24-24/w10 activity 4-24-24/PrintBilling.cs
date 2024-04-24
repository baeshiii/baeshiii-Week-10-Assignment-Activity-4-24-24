using System;
using System.Windows.Controls;
using System.Windows;

namespace InventorySystem
{
    public class BillingManager
    {
        public static void PrintBilling(string itemName, string quantity, ListBox listBox)
        {
            int desiredQuantity;

            if (!int.TryParse(quantity, out desiredQuantity) || desiredQuantity <= 0)
            {
                MessageBox.Show("Please enter a valid positive quantity.");
                return;
            }

            int itemIndex = -1;

            for (int i = 0; i < MainWindow.numItems; i++)
            {
                if (MainWindow.inventory[i, 0] == itemName)
                {
                    itemIndex = i;
                    break;
                }
            }

            if (itemIndex == -1)
            {
                MessageBox.Show("Item not found in inventory.");
                return;
            }

            int availableQuantity = int.Parse(MainWindow.inventory[itemIndex, 2]);

            if (availableQuantity < desiredQuantity)
            {
                MessageBox.Show("Insufficient quantity in inventory.");
                return;
            }

            double itemPrice = double.Parse(MainWindow.inventory[itemIndex, 1]);
            double totalAmount = itemPrice * desiredQuantity;

            listBox.Items.Add($"Billing for {itemName}:");
            listBox.Items.Add($"Quantity: {desiredQuantity}");
            listBox.Items.Add($"Unit Price: ${itemPrice}");
            listBox.Items.Add($"Total Amount: ${totalAmount}");

            MainWindow.inventory[itemIndex, 2] = (availableQuantity - desiredQuantity).ToString();
        }
    }
}