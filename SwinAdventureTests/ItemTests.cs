using SwinAdventureLibrary;

namespace SwinAdventureTests;

[TestFixture]
public class ItemTests
{
    Item item;

    [SetUp]
    public void Setup()
    {
        string[] idents = new[]{ "sword" };
        item = new(idents, "a bronze sword", "closed combat weapon");
    }

    [Test(Description = "The item responds correctly to 'Are You' requests based on the identifiers it is created with")]
    public void TestItemIdentifiable()
    {
        bool result = item.AreYou("sword");
        Assert.That(result, Is.True);
    }

    [Test(Description = "The game object's short description returns the string 'a name (first-id)'")]
    public void TestShortDescriptioin()
    {
        string expected = "a bronze sword (sword)";
        string actual = item.ShortDescription;
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test(Description = "Returns the item's description.")]
    public void TestFullDescriptioin()
    {
        string expected = "closed combat weapon";
        string actual = item.FullDescription;
        Assert.That(actual, Is.EqualTo(expected));
    }
}
