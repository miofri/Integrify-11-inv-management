using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Management
{
    public class Item
    {
        private string _barcode;
        private string _name;
        private int _quantity;

        public Item(string barcode, string name, int quantity)
        {
            _barcode = barcode;
            _name = name;
            _quantity = quantity;
        }

        public void IncreaseQuantity(int quantity)
        {
            _quantity += quantity;
        }

        public void DecreaseQuantity(int quantity)
        {
            _quantity -= quantity;
        }

        public string GetItemName
        {
            get { return _name; }
        }

        public int GetQuantity
        {
            get { return _quantity; }
        }

        public string GetBarcode
        {
            get { return _barcode; }
        }
    }
}
