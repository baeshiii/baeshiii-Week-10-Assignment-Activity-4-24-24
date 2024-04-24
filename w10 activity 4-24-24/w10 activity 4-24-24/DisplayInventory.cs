using System.Windows.Controls;

namespace InventorySystem
{
    public class InventoryDisplayManager
    {
        public static void DisplayInventory(ListBox listBox)
        {
            listBox.Items.Clear();

            if (MainWindow.numItems == 0)
            {
                listBox.Items.Add("Inventory is empty.");
            }
            else
            {
                for (int i = 0; i < MainWindow.MaxInventoryCapacity; i++)
                {
                    if (MainWindow.inventory[i, 0] != null)
                    {
                        listBox.Items.Add($"Item Name: {MainWindow.inventory[i, 0]} (${MainWindow.inventory[i, 1]}) x{MainWindow.inventory[i, 2]}");
                    }
                }
            }
        }
    }
}