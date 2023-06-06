// See https://aka.ms/new-console-template for more information

using Inventory_Management;

public class Program
{
    static void Main()
    {
        Item NewItem2 = new Item("1ABC", "Yksi", 1);
        Item NewItem3 = new Item("2ABC", "Kaksi", 5);
        Item NewItem = new Item("3ABC", "Kolme", 10);
        Item NewItem4 = new Item("4ABC", "Neljä", 4);
        Printer printer = new Printer();
        Inventory Inventory = Inventory.Instance;

        Inventory.AddItem(NewItem, NewItem.GetQuantity);
        Inventory.AddItem(NewItem2, NewItem2.GetQuantity);
        Inventory.AddItem(NewItem3, NewItem3.GetQuantity);

        //Increasing this affects the quantity in Inventory, yet currentInventoryQuantity remains unchanged...
        //A solution would be have increase quantity in item to also take inventory as an arg. Any idea? :)
        // NewItem.IncreaseQuantity(3);

        Inventory.AddItem(NewItem3, NewItem3.GetQuantity);
        Inventory.RemoveItem("9ABC");
        Inventory.IncreaseQuantity(3, "3ABC");
        Inventory.DecreaseQuantity(2, "3ABC");
        Inventory.ViewInventory();
        printer.PrintInventory(Inventory);
        printer.PrintItem(NewItem3);
    }
}
