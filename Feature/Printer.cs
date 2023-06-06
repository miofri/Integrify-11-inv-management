using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Management
{
    public class Printer
    {
        public void PrintItem(Item itemToPrint)
        {
            Console.WriteLine("\n- - Printer in action - -");
            Console.WriteLine(
                $"Barcode: {itemToPrint.GetBarcode} Name: {itemToPrint.GetItemName} Quantity: {itemToPrint.GetQuantity}"
            );
        }

        public void PrintInventory(Inventory inventory)
        {
            Console.WriteLine("\n- - Printer in action - -");

            var uniqueItem = inventory.GetAllItems.Count;
            var totalQuantity = inventory.GetQuantity;
            inventory.ViewInventory();

            Console.WriteLine($"Unique items: {uniqueItem}. Total items: {totalQuantity}");
        }
    }
}
