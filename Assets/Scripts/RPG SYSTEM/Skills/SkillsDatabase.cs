using System.Collections.Generic;

public static class SkillsDatabase
{
    public static List<Skill> GetAllSkills(List<Attribute> attributes, List<string> trainedSkills)
    {
        List<Skill> skills = new List<Skill>();

        // Main Skills
        skills.Add(new Skill("Acrobatics", false, attributes.Find(a => a.Name == "Dexterity"))); // Acrobatics (Dex; penalty for armor)
        skills.Add(new Skill("Animal Handling", false, attributes.Find(a => a.Name == "Charisma"))); // Animal Handling (Cha)
        skills.Add(new Skill("Athletics", false, attributes.Find(a => a.Name == "Strength"))); // Athletics (Str; penalty for armor)
        skills.Add(new Skill("Riding", false, attributes.Find(a => a.Name == "Dexterity"))); // Riding (Dex)
        skills.Add(new Skill("Concentration", false, attributes.Find(a => a.Name == "Wisdom"))); // Concentration (Wis)
        skills.Add(new Skill("Healing", false, attributes.Find(a => a.Name == "Wisdom"))); // Healing (Wis)
        skills.Add(new Skill("Decipher Writing", false, attributes.Find(a => a.Name == "Intelligence"))); // Decipher Writing (Int)
        skills.Add(new Skill("Diplomacy", false, attributes.Find(a => a.Name == "Charisma"))); // Diplomacy (Cha)
        skills.Add(new Skill("Deception", false, attributes.Find(a => a.Name == "Charisma"))); // Deception (Cha)
        skills.Add(new Skill("Stealth", false, attributes.Find(a => a.Name == "Dexterity"))); // Stealth (Dex; penalty for armor)
        skills.Add(new Skill("Initiative", false, attributes.Find(a => a.Name == "Dexterity"))); // Initiative (Dex)
        skills.Add(new Skill("Intimidation", false, attributes.Find(a => a.Name == "Charisma"))); // Intimidation (Cha)
        skills.Add(new Skill("Perception", false, attributes.Find(a => a.Name == "Wisdom"))); // Perception (Wis)
        skills.Add(new Skill("Sabotage", false, attributes.Find(a => a.Name == "Intelligence"))); // Sabotage (Int)
        skills.Add(new Skill("Use Magic Device", false, attributes.Find(a => a.Name == "Charisma"))); // Use Magic Device (Cha)
        skills.Add(new Skill("Endurance", false, attributes.Find(a => a.Name == "Constitution"))); // Endurance (Con)
        skills.Add(new Skill("Sleight of Hand", false, attributes.Find(a => a.Name == "Dexterity"))); // Sleight of Hand (Dex)

        skills.Add(new Skill("Performing Arts", false, attributes.Find(a => a.Name == "Charisma"))); // Performing Arts (Cha)
        skills.Add(new Skill("Singing", false, attributes.Find(a => a.Name == "Charisma"))); // Singing (Cha)
        skills.Add(new Skill("Comedy", false, attributes.Find(a => a.Name == "Charisma"))); // Comedy (Cha)
        skills.Add(new Skill("Dancing", false, attributes.Find(a => a.Name == "Charisma"))); // Dancing (Cha)
        skills.Add(new Skill("String Instruments", false, attributes.Find(a => a.Name == "Charisma"))); // String Instruments (Cha)
        skills.Add(new Skill("Percussion Instruments", false, attributes.Find(a => a.Name == "Charisma"))); // Percussion Instruments (Cha)
        skills.Add(new Skill("Wind Instruments", false, attributes.Find(a => a.Name == "Charisma"))); // Wind Instruments (Cha)
        skills.Add(new Skill("Keyboard Instruments", false, attributes.Find(a => a.Name == "Charisma"))); // Keyboard Instruments (Cha)
        skills.Add(new Skill("Oratory", false, attributes.Find(a => a.Name == "Charisma"))); // Oratory (Cha)
        skills.Add(new Skill("Theater", false, attributes.Find(a => a.Name == "Charisma"))); // Theater (Cha)
        skills.Add(new Skill("Knowledge", false, attributes.Find(a => a.Name == "Intelligence"))); // Knowledge (Int)
        skills.Add(new Skill("Arcana", false, attributes.Find(a => a.Name == "Intelligence"))); // Arcana (Int)
        skills.Add(new Skill("Dungeons", false, attributes.Find(a => a.Name == "Intelligence"))); // Dungeons (Int)
        skills.Add(new Skill("Nature", false, attributes.Find(a => a.Name == "Intelligence"))); // Nature (Int)
        skills.Add(new Skill("Religion", false, attributes.Find(a => a.Name == "Intelligence"))); // Religion (Int)
        skills.Add(new Skill("Social", false, attributes.Find(a => a.Name == "Intelligence"))); // Social (Int)
        skills.Add(new Skill("Planes", false, attributes.Find(a => a.Name == "Intelligence"))); // Planes (Int)
        skills.Add(new Skill("Forgery", false, attributes.Find(a => a.Name == "Intelligence"))); // Forgery (Int)
        skills.Add(new Skill("Crafting", false, attributes.Find(a => a.Name == "Intelligence"))); // Crafting (Int)
        skills.Add(new Skill("Alchemy", false, attributes.Find(a => a.Name == "Intelligence"))); // Alchemy (Int)
        skills.Add(new Skill("Armors", false, attributes.Find(a => a.Name == "Intelligence"))); // Armors (Int)
        skills.Add(new Skill("Weapons", false, attributes.Find(a => a.Name == "Intelligence"))); // Weapons (Int)
        skills.Add(new Skill("Common Items", false, attributes.Find(a => a.Name == "Intelligence"))); // Common Items (Int)
        skills.Add(new Skill("Mechanisms", false, attributes.Find(a => a.Name == "Intelligence"))); // Mechanisms (Int)

        foreach (string trainedSkill in trainedSkills)
        {
            Skill skill = skills.Find(s => s.SkillName == trainedSkill);
            if (skill != null)
            {
                skill.IsTrained = true;
            }
        }

        return skills;
    }
}
