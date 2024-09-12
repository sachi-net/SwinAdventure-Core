using SwinAdventureLibrary;

namespace SwinAdventureTests;

[TestFixture]
public class IdentifiableObjectTests
{
    IdentifiableObject idObject;

    [SetUp]
    public void Initialize()
    {
        idObject = new(new string[] { "104057903", "Niketha", "Nike" });
    }

    [Test]
    [Description("Check that it responds True to the Are You message where the request matches one of the object's identifiers")]
    public void TestAreYou()
    {
        // Arrange
        string id = "Niketha";

        // Act
        bool result = idObject.AreYou(id);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    [Description("Check that it responds False to the Are You message where the request does not match one of the object's identifiers")]
    public void TestNotAreYou()
    {
        // Arrange
        string id = "Sachi";

        // Act
        bool result = idObject.AreYou(id);

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    [Description("Check that it responds True to the Are You message where the request matches one of the object's identifiers where there is a mismatch in case")]
    public void TestAreYouWithLetterCase()
    {
        // Arrange
        string id = "NIKETHA";

        // Act
        bool result = idObject.AreYou(id);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    [Description("Check that the first id returns the first identifier in the list of identifiers")]
    public void TestFirstId()
    {
        // Arrange
        string expectedResult = "104057903";

        // Act
        string actualResult = idObject.FirstId;

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    [Description("Check that an empty string is returned if there are no identifiers in the list of identifiers")]
    public void TestFirstIdWithEmptyList()
    {
        // Arrange
        idObject = new(new string[] { });

        // Act
        string actualResult = idObject.FirstId;

        // Assert
        Assert.That(actualResult, Is.Empty);
    }

    [Test]
    [Description("Check that you can add identifiers to the object")]
    public void TestAddIdentifiers()
    {
        // Arrange
        string id1 = "Sachintha";
        string id2 = "Sachi";
        string id3 = "E1741054";

        // Act
        idObject.AddIdentifier(id1);
        idObject.AddIdentifier(id2);
        idObject.AddIdentifier(id3);

        // Assert
        Assert.That(idObject.AreYou(id1), Is.True);
        Assert.That(idObject.AreYou(id2), Is.True);
        Assert.That(idObject.AreYou(id3), Is.True);
    }

    [Test]
    [Description("Check that you can escalate your tutorial ID to be the first id")]
    public void TestPrivilegeEscalation()
    {
        // Arrange
        string pin = "7903";

        // Act
        idObject.PrivilegeEscalation(pin);
        string expectedResult = "COS20007";
        string actualResult = idObject.FirstId;

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}