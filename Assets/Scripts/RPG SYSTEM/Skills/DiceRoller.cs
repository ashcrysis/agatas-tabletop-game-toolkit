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
            collidingObject.GetComponent<SkillTest>()?.PerformSkillTest();
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
            return LogError<(int, int)>($"Skill {skillName} not found!");

        return RollCheck(skill.SkillAttribute.Name, Player.CalculateProficiencyBonus(skill), hasAdvantage, hasDisadvantage);
    }

    public int RollAttributeCheck(string attributeName, bool hasAdvantage, bool hasDisadvantage)
    {
        return RollCheck(attributeName, Player.CalculateProficiencyBonusForAttribute(attributeName), hasAdvantage, hasDisadvantage).total;
    }

    private (int finalRoll, int total) RollCheck(string attributeName, int proficiencyBonus, bool hasAdvantage, bool hasDisadvantage)
    {
        Attribute attribute = Player.Attributes.Find(a => a.Name == attributeName);
        if (attribute == null)
            return LogError<(int, int)>($"Attribute {attributeName} not found!");

        int attributeModifier = (attribute.Value - 10) / 2;
        int finalRoll = GetRollWithAdvantage(hasAdvantage, hasDisadvantage);
        int total = finalRoll + attributeModifier + proficiencyBonus;

        Debug.Log($"Check for {attributeName}: Roll: {finalRoll}, Modifier: {attributeModifier}, Bonus: {proficiencyBonus}, Total: {total}");
        return (finalRoll, total);
    }

    private int GetRollWithAdvantage(bool hasAdvantage, bool hasDisadvantage)
    {
        int roll1 = Random.Range(1, 21);
        int roll2 = Random.Range(1, 21);
        return hasAdvantage ? Mathf.Max(roll1, roll2) : hasDisadvantage ? Mathf.Min(roll1, roll2) : roll1;
    }

    public (int total, List<int> rollResults) RollDice(string diceInput)
    {
        List<int> rollResults = diceInput.Split('+')
            .SelectMany(ParseDiceRoll)
            .ToList();

        return (rollResults.Sum(), rollResults);
    }

    private IEnumerable<int> ParseDiceRoll(string diceExpression)
    {
        string[] parts = diceExpression.Trim().Split('d');
        if (parts.Length == 2 && int.TryParse(parts[0], out int numRolls) && int.TryParse(parts[1], out int numSides))
        {
            return Enumerable.Range(0, numRolls).Select(_ => Random.Range(1, numSides + 1));
        }
        Debug.LogError("Invalid dice format: " + diceExpression);
        return Enumerable.Empty<int>();
    }

    private T LogError<T>(string message)
    {
        Debug.LogError(message);
        return default;
    }
}