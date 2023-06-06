using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Management
{
    public class Inventory
    {
        private List<Item> _items;
        private int maxCapacity;
        private int currentInventoryQuantity;
        private static readonly Inventory instance = new Inventory(100);

        private Inventory(int capacity)
        {
            maxCapacity = capacity;
            currentInventoryQuantity = 0;

            Console.WriteLine("Capacity: {0}", maxCapacity);

            _items = new List<Item>();
        }

        public List<Item> GetAllItems
        {
            get { return _items; }
        }
        public int GetQuantity
        {
            get { return currentInventoryQuantity; }
        }

        public static Inventory Instance
        {
            get { return instance; }
        }

        public bool AddItem(Item item, int quantity)
        {
            if (currentInventoryQuantity + quantity > maxCapacity)
            {
                Console.WriteLine("Inventory capacity exceeded!");

                return false;
            }
            if (_items.Any(existingItem => existingItem.GetBarcode == item.GetBarcode))
            {
                int index = _items.FindIndex(i => i.GetBarcode == item.GetBarcode);
                currentInventoryQuantity = currentInventoryQuantity - _items[index].GetQuantity;
                if (index != -1)
                {
                    _items[index] = item;
                }

                Console.WriteLine("Replaced item");
            }
            else
            {
                _items.Add(item);
                Console.WriteLine("Added item");
            }
            currentInventoryQuantity = currentInventoryQuantity + quantity;
            return true;
        }

        public bool RemoveItem(string barcodeToDelete)
        {
            Item itemToRemove;
            try
            {
                itemToRemove = _items.Single(item => item.GetBarcode == barcodeToDelete);
            }
            catch (System.InvalidOperationException)
            {
                Console.WriteLine("Item not found in inventory!");

                return false;
            }
            _items.Remove(itemToRemove);
            foreach (var listitem in _items)
            {
                Console.WriteLine(
                    $"{listitem.GetItemName} {listitem.GetBarcode} {listitem.GetQuantity}"
                );
            }
            return true;
        }

        public bool IncreaseQuantity(int newQuantity, string newBarcode)
        {
            Console.WriteLine($"\ncurrentInventoryQuantity: {currentInventoryQuantity}");

            int findItem;
            if (!_items.Any(item => item.GetBarcode == newBarcode))
            {
                Console.WriteLine("Barcode not found in inventory!");
                return false;
            }
            try
            {
                findItem = _items.FindIndex(item => item.GetBarcode == newBarcode);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Item not found in inventory!");

                return false;
            }

            Console.WriteLine($"Increasing: {currentInventoryQuantity} + {newQuantity}");

            currentInventoryQuantity += newQuantity;
            _items[findItem].IncreaseQuantity(newQuantity);

            Console.WriteLine("Item quantity has been increased!");

            return true;
        }

        public bool DecreaseQuantity(int newQuantity, string newBarcode)
        {
            int findItem;
            if (!_items.Any(item => item.GetBarcode == newBarcode))
            {
                Console.WriteLine("Barcode not found in inventory!");
                return false;
            }
            try
            {
                findItem = _items.FindIndex(item => item.GetBarcode == newBarcode);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Item not found in inventory!\n");
                return false;
            }
            Console.WriteLine($"Decreasing: {currentInventoryQuantity} - {newQuantity}\n");

            currentInventoryQuantity -= newQuantity;
            _items[findItem].DecreaseQuantity(newQuantity);

            Console.WriteLine("Item quantity has been decreased!\n");

            return true;
        }

        public void ViewInventory()
        {
            foreach (var listitem in _items)
            {
                Console.WriteLine(
                    $"Barcode: {listitem.GetBarcode} Name: {listitem.GetItemName} Quantity: {listitem.GetQuantity}"
                );
            }
        }

        ~Inventory()
        {
            Console.WriteLine("Inventory has been destroyed.");
        }
    }
}
