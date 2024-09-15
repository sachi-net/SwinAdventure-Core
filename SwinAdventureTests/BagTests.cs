using SwinAdventureLibrary;
using System.Numerics;

namespace SwinAdventureTests;

[TestFixture]
public class BagTests
{
    Bag bag;

    [SetUp]
    public void Initialize()
    {
        bag = new(new[] { "satchel", "bag" }, "satchel", "a small bag");
        List<Item> items = new()
        {
            new(new[]{ "key" }, "a key", "master key to palace"),
            new(new[]{ "map" }, "a map", "map of the northern villege"),
            new(new[]{ "torch" }, "a flashlight", "hand-held electronic flashlight")
        };

        foreach (Item item in items)
        {
            bag.Inventory.Put(item);
        }
    }

    [Test(Description = "Bag locate items in its inventory, this returns items the bag has and the item remains in the bag's inventory")]
    public void TestBagLocatesItems()
    {
        string key = "key";
        GameObject @object = bag.Locate(key);
        bool itemExists = bag.Inventory.HasItem(key);
        Assert.That(@object.FirstId, Is.EqualTo(key));
        Assert.That(itemExists, Is.True);
    }

    [Test(Description = "The bag returns itself if asked to locate one of its identifiers")]
    public void TestBagLocatesItSelf()
    {
        string satchel = "satchel";
        GameObject @object = bag.Locate(satchel);
        Assert.That(@object.FirstId, Is.EqualTo(satchel));
    }

    [Test(Description = "The bag returns a null/nil object if asked to locate something it does not have")]
    public void TestBagLocatesNothing()
    {
        string notebook = "notebook";
        GameObject @object = bag.Locate(notebook);
        Assert.That(@object, Is.Null);
    }

    [Test(Description = "The bag's full description contains the text")]
    public void TestBagFullDescription()
    {
        string expected = "In the satchel, you can see" + Environment.NewLine +
            "\ta key (key)" + Environment.NewLine +
            "\ta map (map)" + Environment.NewLine +
            "\ta flashlight (torch)" + Environment.NewLine;
        string actual = bag.FullDescription;
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test(Description = "Test that bag can locate another bag inside and not it's items")]
    public void TestBagInBag()
    {
        Bag wallet = new(new[] { "wallet", "purse" }, "wallet", "a cash wallet");
        Item creditcard = new(new[] { "creditcard", "cashcard" }, "credit card", "a credit card");
        Item coin = new(new[] { "coin", "50cent" }, "50 cent coin", "a metal coin of 50 cents");
        
        wallet.Inventory.Put(creditcard);
        wallet.Inventory.Put(coin);
        bag.Inventory.Put(wallet);

        string keyInBag = "key";
        string walletInBag = "wallet";
        string coinInWallet = "coin";

        GameObject @objectInBag = bag.Locate(keyInBag);
        GameObject @bagInBag = bag.Locate(walletInBag);
        GameObject @objectInWallet = bag.Locate(coinInWallet);
        bool keyExists = bag.Inventory.HasItem(keyInBag);
        bool walletExists = bag.Inventory.HasItem(walletInBag);

        Assert.That(@bagInBag.FirstId, Is.EqualTo(walletInBag));
        Assert.That(objectInWallet, Is.Null);
        Assert.That(keyExists, Is.True);
        Assert.That(walletExists, Is.True);
    }
}
