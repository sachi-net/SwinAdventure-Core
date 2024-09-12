namespace SwinAdventureLibrary;

public class IdentifiableObject
{
    private List<string> _identifiers = new();

    public string FirstId { 
        get
        {
            if (_identifiers.Any())
            {
                return _identifiers.First();
            }
            else
            {
                return string.Empty;
            }
        }
    }

    public IdentifiableObject(string[] idents)
    {
        foreach (string id in idents) 
        { 
            AddIdentifier(id);
        }
    }

    public void AddIdentifier(string id)
    {
        _identifiers.Add(id.Trim().ToLower());
    }

    public bool AreYou(string id)
    {
        return _identifiers.Contains(id.Trim().ToLower());
    }

    public void PrivilegeEscalation(string pin)
    {
        string tutorialId = "COS20007";
        string studentIdString = "7903";

        if (studentIdString.Equals(pin))
        {
            _identifiers[0] = tutorialId;
        }
    }
}
