using UnityEngine;
using TMPro; 
using UnityEngine.UI;

public class SkillTest : MonoBehaviour
{
    public string skillNameField;  
    public int difficultyField;
    public TMP_Text resultText; 

    private DiceRoller diceRoller;  

    void Start()
    {
        diceRoller = GameObject.FindGameObjectWithTag("Player").GetComponent<DiceRoller>();
    }

    public void PerformSkillTest()
    {
        string skillName = skillNameField;
        int difficultyThreshold = difficultyField;

       (int finalRoll, int total) result = diceRoller.RollSkillCheck(skillName, false, false);  

        resultText.text = $"Test result: {result.total} |";
        if (result.finalRoll == 20 || result.finalRoll == 1)
        {
            resultText.text += " Critical";
        }

        if (result.total >= difficultyThreshold)
        {
            resultText.text += " Sucess";
        }
        else
        {
            resultText.text += " Fail";
        }

 
    }

   
}
