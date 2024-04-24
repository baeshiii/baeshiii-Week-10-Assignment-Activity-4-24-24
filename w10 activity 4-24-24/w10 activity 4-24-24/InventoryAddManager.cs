using System;
using System.Windows;

namespace InventorySystem
{
    public class InventoryAddManager
    {
        public static void AddItem(string itemName, string price, string quantity)
        {
            double parsedPrice;
            int parsedQuantity;

            if (!double.TryParse(price, out parsedPrice) || parsedPrice <= 0)
            {
                MessageBox.Show("Please enter a valid positive price.");
                return;
            }

            if (!int.TryParse(quantity, out parsedQuantity) || parsedQuantity <= 0)
            {
                MessageBox.Show("Please enter a valid positive quantity.");
                return;
            }

            int index = MainWindow.numItems;
            do
            {
                if (MainWindow.inventory[index, 0] == null)
                {
                    break;
                }
                index++;
            } while (index < MainWindow.MaxInventoryCapacity);

            if (index == MainWindow.MaxInventoryCapacity)
            {
                MessageBox.Show("Inventory is full.");
                return;
            }

            MainWindow.inventory[index, 0] = itemName;
            MainWindow.inventory[index, 1] = parsedPrice.ToString();
            MainWindow.inventory[index, 2] = parsedQuantity.ToString();

            MainWindow.numItems++;
        }
    }
}
