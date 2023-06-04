// See https://aka.ms/new-console-template for more information

public class Item
{
    private int _barcode;
    private string _name;
    private int _quantity;

    public Item(int barcode, string name, int quantity)
    {
        _barcode = barcode;
        _name = name;
        _quantity = quantity;
    }

    public void IncreaseQuantity()
    {
        _quantity += 1;
    }

    public void DecreaseQuantity()
    {
        _quantity -= 1;
    }

    public string GetItemName
    {
        get { return _name; }
    }

    public int GetQuantity
    {
        get { return _quantity; }
    }

    public int GetBarcode
    {
        get { return _barcode; }
    }
}

public class Program
{
    static void Main()
    {
        Item NewItem = new Item(3, "Test", 10);
        NewItem.DecreaseQuantity();
        Console.WriteLine(NewItem.GetQuantity);
    }
}
