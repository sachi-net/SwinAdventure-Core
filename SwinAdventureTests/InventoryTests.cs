using SwinAdventureLibrary;

namespace SwinAdventureTests;

[TestFixture]
public class InventoryTests
{
    Inventory inventory;

    [SetUp]
    public void Setup()
    {
        inventory = new();
        List<Item> items = new()
        {
            new(new[]{ "shovel" }, "a shovel", "utility tool"),
            new(new[]{ "sword" }, "a sword", "closed combat weapon"),
            new(new[]{ "pc" }, "a small computer", "electronic device")
        };

        foreach (Item item in items)
        {
            inventory.Put(item);
        }
    }

    [Test(Description = "The Inventory has items that are put in it")]
    public void TestFindItem()
    {
        bool itemExists = inventory.HasItem("sword");
        Assert.That(itemExists, Is.True);
    }

    [Test(Description = "The Inventory does not have items it does not contain")]
    public void TestNoItems ()
    {
        inventory = new();
        bool result = inventory.HasItem("bow");
        Assert.That(result, Is.False);
    }

    [Test(Description = "Returns items it has, and the item remains in the inventory")]
    public void TestFetchItem()
    {
        string sword = "sword";
        Item item = inventory.Fetch(sword);
        bool itemExists = inventory.HasItem(sword);
        Assert.That(item.FirstId, Is.EqualTo(sword));
        Assert.That(itemExists, Is.True);
    }

    [Test(Description = "Returns the item, and the item is no longer in the inventory")]
    public void TestTakeItem()
    {
        string sword = "sword";
        Item item = inventory.Take(sword);
        bool itemExists = inventory.HasItem(sword);
        Assert.That(item.FirstId, Is.EqualTo(sword));
        Assert.That(itemExists, Is.False);
    }

    [Test(Description = "Returns a string containing multiple lines. Each line contains a tab-indented short description of an item in the Inventory")]
    public void TestItemList()
    {
        string expected = "\ta shovel (shovel)" + Environment.NewLine +
            "\ta sword (sword)" + Environment.NewLine +
            "\ta small computer (pc)" + Environment.NewLine;
        string actual = inventory.ItemList;
        Assert.That (actual, Is.EqualTo(expected));
    }
}
