using SwinAdventureLibrary;

namespace SwinAdventureTests;

[TestFixture]
public class PlayerTests
{
    Player player;

    [SetUp]
    public void Setup()
    {
        player = new("Sachi the mighty programmer", "the player");
        List<Item> items = new()
        {
            new(new[]{ "shovel" }, "a shovel", "utility tool"),
            new(new[]{ "sword" }, "a sword", "closed combat weapon"),
            new(new[]{ "pc" }, "a small computer", "electronic device")
        };

        foreach (Item item in items)
        {
            player.Inventory.Put(item);
        }
    }

    [Test(Description = "The player responds correctly to 'Are You' requests based on its default identifiers")]
    public void TestPlayerIdentifiable()
    {
        bool isMe = player.AreYou("me");
        bool isInventory = player.AreYou("inventory");
        Assert.That(isMe, Is.True);
        Assert.That(isInventory, Is.True);
    }

    [Test(Description = "The player can locate items in its inventory, this returns items the player has and the item remains in the player's inventory")]
    public void TestPlayerLocatesItems()
    {
        string sword = "sword";
        GameObject @object = player.Locate(sword);
        bool itemExists = player.Inventory.HasItem(sword);
        Assert.That(@object.FirstId, Is.EqualTo(sword));
        Assert.That(itemExists, Is.True);
    }

    [Test(Description = "The player returns itself if asked to locate")]
    public void TestPlayerLocatesItSelf()
    {
        string me = "me";
        GameObject @object = player.Locate(me);
        Assert.That(@object.FirstId, Is.EqualTo(me));
    }

    [Test(Description = "The player returns a null/nil object if asked to locate something it does not have")]
    public void TestPlayerLocatesNothing()
    {
        string bow = "bow";
        GameObject @object = player.Locate(bow);
        Assert.That(@object, Is.Null);
    }

    [Test(Description = "The player's full description contains the text")]
    public void TestPlayerFullDescription()
    {
        string expected = "You are Sachi the mighty programmer." + Environment.NewLine +
            "You are carrying" + Environment.NewLine +
            "\ta shovel (shovel)" + Environment.NewLine +
            "\ta sword (sword)" + Environment.NewLine +
            "\ta small computer (pc)" + Environment.NewLine;
        string actual = player.FullDescription;
        Assert.That(actual, Is.EqualTo(expected));
    }
}
