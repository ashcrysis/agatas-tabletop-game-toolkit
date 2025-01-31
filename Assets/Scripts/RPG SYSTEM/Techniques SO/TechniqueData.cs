using UnityEngine;

public enum TechniqueType
{
    Attack,
    Heal,
    Buff,
    Debuff,
    Special
}

public enum damageType
{
    Fire,
    Magic,
    Sharp,
    Impact,
    Piercing
}

[CreateAssetMenu(fileName = "NewTechnique", menuName = "RPG/Technique")]
public class TechniqueData : ScriptableObject
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
    public bool CanUse()
    {
        return Time.time >= lastUsedTime + cooldownTime;
    }

public virtual void Use(PlayerCharacter player) {}

}
