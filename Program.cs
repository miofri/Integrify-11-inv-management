// See https://aka.ms/new-console-template for more information

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
            Console.WriteLine("Item not found in inventory!");
            return false;
        }
        currentInventoryQuantity -= newQuantity;
        _items[findItem].DecreaseQuantity(newQuantity);
        Console.WriteLine("Item quantity has been decreased!");
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

public class Program
{
    static void Main()
    {
        Item NewItem2 = new Item("1ABC", "Yksi", 1);
        Item NewItem3 = new Item("2ABC", "Kaksi", 5);
        Item NewItem = new Item("3ABC", "Kolme", 10);
        Item NewItem4 = new Item("4ABC", "Neljä", 4);

        Inventory Inventory = Inventory.Instance;
        Inventory.AddItem(NewItem, NewItem.GetQuantity);
        Inventory.AddItem(NewItem2, NewItem2.GetQuantity);
        Inventory.AddItem(NewItem3, NewItem3.GetQuantity);
        NewItem.IncreaseQuantity(3);
        Inventory.AddItem(NewItem3, NewItem3.GetQuantity);
        Inventory.RemoveItem("9ABC");
        Inventory.IncreaseQuantity(3, "3ABC");
        Inventory.DecreaseQuantity(2, "3ABC");
        Inventory.ViewInventory();
    }
}
