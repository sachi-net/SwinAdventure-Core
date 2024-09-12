using System.Text;

namespace SwinAdventureLibrary
{
    public class Player : GameObject
    {
        private Inventory _inventory;

        public Inventory Inventory { get { return _inventory; } }

        public override string FullDescription
        {
            get
            {
                StringBuilder description = new();
                return description
                    .AppendLine($"You are {Name}.")
                    .AppendLine("You are carrying")
                    .Append(_inventory.ItemList)
                    .ToString();
            }
        }

        public Player(string name, string description) : base(new[]{"me", "inventory"}, name, description)
        {
            _inventory = new();
        }

        public GameObject Locate(string id)
        {
            GameObject @object = null;
            
            if (AreYou(id))
            {
                @object = this;
            }
            else
            {
                @object = _inventory.Fetch(id);
            }

            return @object;
        }
    }
}
