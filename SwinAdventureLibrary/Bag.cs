using System.Text;

namespace SwinAdventureLibrary;

public class Bag : Item
{
    private Inventory _inventory;

    public Inventory Inventory { get { return _inventory; } }

    public override string FullDescription
    {
        get
        {
            StringBuilder description = new();
            return description
                .AppendLine($"In the {Name}, you can see")
                .Append(_inventory.ItemList)
                .ToString();
        }
    }

    public Bag(string[] idents, string name, string description) : base(idents, name, description)
    {
        _inventory = new();
    }

    public GameObject Locate(string id)
    {
        GameObject @object = null;

        if (AreYou(id))
        {
            return this;
        }
        else
        {
            @object = _inventory.Fetch(id);
        }

        return @object;
    }
}
