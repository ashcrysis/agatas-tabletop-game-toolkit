using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewClass", menuName = "RPG/Character Class")]
public class CharacterClass : ScriptableObject
{
    public string ClassName;
    public string Description;

    [SerializeField]
    public List<Attribute> Attributes = new List<Attribute>
    {
        new Attribute { Name = "Strength", Value = 0 },
        new Attribute { Name = "Dexterity", Value = 0 },
        new Attribute { Name = "Constitution", Value = 0 },
        new Attribute { Name = "Intelligence", Value = 0 },
        new Attribute { Name = "Wisdom", Value = 0 },
        new Attribute { Name = "Charisma", Value = 0 },
    };

    [SerializeField]
    public List<string> TrainedSkills = new List<string>();
    
    [SerializeField]
    public List<string> TrainedAttributes = new List<string>(); 
    public int GetAttributeValue(string name)
    {
        var attribute = Attributes.Find(attr => attr.Name == name);
        return attribute != null ? attribute.Value : 0;
    }

    public int GetAttributeModifier(string name)
    {
        var attribute = Attributes.Find(attr => attr.Name == name);
        return attribute != null ? attribute.GetModifier() : 0;
    }
}
