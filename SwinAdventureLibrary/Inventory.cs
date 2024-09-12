using System.Text;

namespace SwinAdventureLibrary;

public class Inventory
{
    private List<Item> _items;

    public string ItemList 
    { 
        get
        {
            StringBuilder items = new();
            foreach (var item in _items)
            {
                items.AppendLine($"\t{item.ShortDescription}");
            }
            return items.ToString();
        } 
    }

    public Inventory()
    {
        _items = new();
    }

    public bool HasItem(string id)
    {
        return _items.Find(x => x.AreYou(id)) is not null;
    }

    public void Put(Item item)
    {
        _items.Add(item);
    }

    public Item Take(string id)
    {
        Item item = _items.Find(x => x.AreYou(id));
        _items.Remove(item);
        return item;
    }

    public Item Fetch(string id)
    {
        Item item = _items.Find(x => x.AreYou(id));
        return item;
    }
}
