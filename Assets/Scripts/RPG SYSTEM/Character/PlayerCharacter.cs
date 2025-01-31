using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public string CharacterName;
    public CharacterClass CharacterClass;
    public CharacterRace Race;
    public List<Attribute> Attributes = new List<Attribute>();
    public List<Skill> Skills = new List<Skill>(); 
    public int ProficiencyBonus = 2;
    public int Level = 1;
    public int baseMovementSpeed = 3;

    void Start()
    {
        InitializeAttributes();
        InitializeSkills();
        UpdateProficiencyBonus();
    }

    void InitializeAttributes()
    {
        Attributes.Clear();
        string[] baseAttributes = { "Strength", "Dexterity", "Constitution", "Intelligence", "Wisdom", "Charisma" };

        foreach (string attrName in baseAttributes)
        {
            Attributes.Add(new Attribute { Name = attrName, Value = 10 });
        }

        if (Race != null)
        {
            ApplyModifiers(Race.Attributes);
        }

        if (CharacterClass != null)
        {
            ApplyModifiers(CharacterClass.Attributes);
        }
    }

    void ApplyModifiers(List<Attribute> modifiers)
    {
        foreach (var mod in modifiers)
        {
            Attribute attr = Attributes.Find(a => a.Name == mod.Name);
            if (attr != null)
            {
                attr.Value += mod.Value;
            }
        }
    }

void InitializeSkills()
{
    List<string> trainedSkills = new List<string>();

    if (CharacterClass != null && CharacterClass.TrainedSkills != null)
    {
        trainedSkills.AddRange(CharacterClass.TrainedSkills); // Adiciona as perícias treinadas pela classe
    }

    if (Race != null && Race.TrainedSkills != null)
    {
        trainedSkills.AddRange(Race.TrainedSkills); // Adiciona as perícias treinadas pela raça
    }

    Skills = SkillsDatabase.GetAllSkills(Attributes, trainedSkills);
}


    public bool IsTrainedInSkill(string skillName)
    {
        Skill skill = Skills.Find(s => s.SkillName == skillName);
        return skill != null && skill.IsTrained;
    }

    public void UpdateProficiencyBonus()
    {
        if (Level >= 1 && Level <= 4)
        {
            ProficiencyBonus = 2;
        }
        else if (Level >= 5 && Level <= 8)
        {
            ProficiencyBonus = 3;
        }
        else if (Level >= 9 && Level <= 13)
        {
            ProficiencyBonus = 4;
        }
        else if (Level >= 14 && Level <= 16)
        {
            ProficiencyBonus = 5;
        }
        else if (Level >= 17)
        {
            ProficiencyBonus = 6;
        }
    }

    public int CalculateProficiencyBonus(Skill skill)
    {
        int bonus = 0;
        int trainCount = 0;

        if (CharacterClass != null && CharacterClass.TrainedSkills.Contains(skill.SkillName))
        {
            trainCount++;
        }
        if (Race != null && Race.TrainedSkills.Contains(skill.SkillName))
        {
            trainCount++;
        }


        if (trainCount > 1)
        {
            bonus = ProficiencyBonus + 2;
        }else if (trainCount == 1)
        {
            bonus = ProficiencyBonus;
        }

        return bonus;
    }
    public int CalculateProficiencyBonusForAttribute(string attributeName)
    {
        int bonus = 0;  
        int trainCount = 0;

        if (CharacterClass != null && CharacterClass.TrainedAttributes.Contains(attributeName))
        {
            trainCount++;
        }

        if (Race != null && Race.TrainedAttributes.Contains(attributeName))
        {
            trainCount++;
        }

        if (trainCount > 1)
        {
            bonus = ProficiencyBonus + 2; 
        }
        else if (trainCount == 1)
        {
            bonus = ProficiencyBonus;
        }

        return bonus;
    }

}
