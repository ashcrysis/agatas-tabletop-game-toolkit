using UnityEngine;

public class Technique : MonoBehaviour
{
    public string techniqueName;
    public string description;
    public TechniqueType techniqueType;  
    public damageType damageType;  
    
    public int requiredLevel;
    public int manaCost;
    public int staminaCost;
    [Tooltip("Only check this if you want this technique to be used only by a specific class")]
    public bool isClassExclusive;
    public string classRequirement;
    [Tooltip("Only check this if you want this technique to be used only by a specific race")]
    public bool isRaceExclusive;
    public string raceRequirement;
    [Header("Attribute to use on the dice test")]
    public string AttributeRoll;
    [Tooltip("If you add a Skill Roll automatically the correct attribute modifier will be added so don't worry")]
    public string SkillRoll;
    [Tooltip("Minimum roll to pass the test")]
    public int diceDT;
    public float cooldownTime;  
    public float lastUsedTime = -Mathf.Infinity; 
    [Tooltip("Will be used to roll damage or healing tests, expected format : 1d6, 1d6+2d6, 1d20+1d6, 1d12, etc")]
    public string dice;
    public TechniqueData techniqueData;
    public bool CanUse()
    {
        return Time.time >= lastUsedTime + cooldownTime;
    }
    public virtual void SyncVariables(TechniqueData tech)
    {
        techniqueName = tech.techniqueName;
        description = tech.description;
        techniqueType = tech.techniqueType;
        requiredLevel = tech.requiredLevel;
        manaCost = tech.manaCost;
        staminaCost = tech.staminaCost;
        isClassExclusive = tech.isClassExclusive;
        classRequirement = tech.classRequirement;
        isRaceExclusive = tech.isRaceExclusive;
        raceRequirement = tech.raceRequirement;
        AttributeRoll = tech.AttributeRoll;
        SkillRoll = tech.SkillRoll;
        diceDT = tech.diceDT;
        cooldownTime = tech.cooldownTime;
        lastUsedTime = -Mathf.Infinity;
        dice = tech.dice;
        damageType = tech.damageType;
    }
    public virtual void Setup()
    {
        string scriptName = this.GetType().Name;

        techniqueData = Resources.Load<TechniqueData>("TechniqueData/" + scriptName);
        if (techniqueData == null)
        {
            Debug.LogError("TechniqueData for Fireball not found!");
        }   
        SyncVariables(techniqueData);
    }
    public virtual void Use(PlayerCharacter player)
    {
        if (!CanUse())
        {
            float remainingTime = lastUsedTime + cooldownTime - Time.time;
            Debug.Log($"{techniqueName} is on cooldown! Wait {remainingTime:F1} seconds.");
            return;
        }

        DiceRoller diceRoller = player.GetComponent<DiceRoller>();
        if (diceRoller == null)
        {
            Debug.LogError("DiceRoller not found on player!");
            return;
        }

        int rollResult = 0;

        if (!string.IsNullOrEmpty(SkillRoll))
        {
            var (finalRoll, total) = diceRoller.RollSkillCheck(SkillRoll, false, false);
            rollResult = total;
            Debug.Log($"{player.CharacterName} performed a {SkillRoll} skill check for {techniqueName} with a total roll of {total}, DT was {diceDT}.");
            if (rollResult >= diceDT)
            {
                UseSkill(player);
            }else
            {
                Debug.Log($"{player.CharacterName} has failed on the roll!");
            }

        }
        else if (!string.IsNullOrEmpty(AttributeRoll))
        {
            rollResult = diceRoller.RollAttributeCheck(AttributeRoll, false, false);
            Debug.Log($"{player.CharacterName} performed an {AttributeRoll} attribute check for {techniqueName} with a total roll of {rollResult}, DT was {diceDT}.");
            if (rollResult >= diceDT)
            {
                UseSkill(player);
            }else
            {
                Debug.Log($"{player.CharacterName} has failed on the roll!");
            }
        }

        lastUsedTime = Time.time;  
    }
    public virtual void UseSkill(PlayerCharacter player){}
}
