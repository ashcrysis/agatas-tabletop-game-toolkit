[System.Serializable]
public class Skill
{
    public string SkillName;
    public bool IsTrained;  
    public Attribute SkillAttribute;  

    public Skill(string skillName, bool isTrained, Attribute skillAttribute)
    {
        SkillName = skillName;
        IsTrained = isTrained;
        SkillAttribute = skillAttribute;
    }
}
