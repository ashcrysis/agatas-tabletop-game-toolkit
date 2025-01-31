using System;

[Serializable]
public class Attribute
{
    public string Name; 
    public int Value;  
    public int GetModifier()
    {
        return (Value - 10) / 2;
    }
}
