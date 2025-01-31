using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DiceRoller : MonoBehaviour
{
    public PlayerCharacter Player;
    private GameObject collidingObject = null;
    void Update()
    {
        if (collidingObject != null && Input.GetKeyDown(KeyCode.E))
        {
            collidingObject.GetComponent<SkillTest>().PerformSkillTest();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
          
        if (other.GetComponent<SkillTest>())
        {
            collidingObject = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<SkillTest>())
        {
            collidingObject = null;
        }
    }

    public (int finalRoll, int total) RollSkillCheck(string skillName, bool hasAdvantage, bool hasDisadvantage)
    {
        Skill skill = Player.Skills.Find(s => s.SkillName == skillName);
        if (skill == null)
        {
            Debug.LogError($"Perícia {skillName} não encontrada!");
            return (0, 0);
        }

        Attribute baseAttribute = Player.Attributes.Find(a => a.Name == skill.SkillAttribute.Name);
        if (baseAttribute == null)
        {
            Debug.LogError($"Atributo base {skill.SkillAttribute.Name} não encontrado!");
            return (0, 0);
        }

        int attributeModifier = baseAttribute.GetModifier();
        int proficiencyBonusValue = Player.CalculateProficiencyBonus(skill);
        
        int diceRoll1 = Random.Range(1, 21);
        int diceRoll2 = Random.Range(1, 21);
        
        int finalRoll = hasAdvantage ? Mathf.Max(diceRoll1, diceRoll2) : hasDisadvantage ? Mathf.Min(diceRoll1, diceRoll2) : diceRoll1;
        int total = finalRoll + attributeModifier + proficiencyBonusValue;

        Debug.Log($"Teste de {skillName}: Rolagem: {finalRoll}, Modificador ({skill.SkillAttribute.Name}): {attributeModifier}, Bônus de Perícia: {proficiencyBonusValue}, Total: {total}");

        return (finalRoll, total);
    }

    public int RollAttributeCheck(string attributeName, bool hasAdvantage, bool hasDisadvantage)
    {
        Attribute baseAttribute = Player.Attributes.Find(a => a.Name == attributeName);
        if (baseAttribute == null)
        {
            Debug.LogError($"Atributo {attributeName} não encontrado!");
            return 0;
        }

        int attributeModifier = (baseAttribute.Value - 10) / 2;

        int proficiencyBonusValue = Player.CalculateProficiencyBonusForAttribute(attributeName);

        int diceRoll1 = Random.Range(1, 21);
        int diceRoll2 = Random.Range(1, 21); 

        int finalRoll;

        if (hasAdvantage)
        {
            finalRoll = Mathf.Max(diceRoll1, diceRoll2);
        }
        else if (hasDisadvantage)
        {
            finalRoll = Mathf.Min(diceRoll1, diceRoll2);
        }
        else
        {
            finalRoll = diceRoll1; 
        }

        int total = finalRoll + attributeModifier + proficiencyBonusValue;

        Debug.Log($"Teste de {attributeName}: Rolagem: {finalRoll}, Modificador ({attributeName}): {attributeModifier}, Bônus de Proficiência: {proficiencyBonusValue}, Total: {total}");
        
        return total;
    }

    public (int total, List<int> rollResults) RollDice(string diceInput)
    {
        int total = 0;
        string[] parts = diceInput.Split('+'); 
        List<int> rollResults = new List<int>(); 

        foreach (var part in parts)
        {
            string trimmedPart = part.Trim();

            string[] diceAndSides = trimmedPart.Split('d');
            if (diceAndSides.Length == 2)
            {
                int numRolls = int.Parse(diceAndSides[0]); 
                int numSides = int.Parse(diceAndSides[1]); 

                rollResults.AddRange(RollMultipleDice(numRolls, numSides));
            }
            else
            {
                Debug.LogError("Invalid dice format: " + trimmedPart);
            }
        }

        total = rollResults.Sum();
        
        return (total, rollResults);
    }

    private List<int> RollMultipleDice(int numRolls, int numSides)
    {
        List<int> rolls = new List<int>();

        for (int i = 0; i < numRolls; i++)
        {
            rolls.Add(UnityEngine.Random.Range(1, numSides + 1));
        }

        return rolls;
    }


}
