using System;
using UnityEngine;

public class FireballTechnique : Technique
{   
   public void Start()
    {
       Setup();
    }

    public override void UseSkill(PlayerCharacter player)
    {
         if (techniqueType == TechniqueType.Heal || techniqueType == TechniqueType.Attack)
        {
            var roll = player.gameObject.GetComponent<DiceRoller>().RollDice(dice);
            if(techniqueType == TechniqueType.Attack)
            {
                Debug.Log($"{player.CharacterName} used {techniqueName} and dealt {roll.total} total damage! ({dice})");

            }
            if(techniqueType == TechniqueType.Heal)
            {
                Debug.Log($"{player.CharacterName} used {techniqueName} and dealt {roll.total} total heal! ({dice})");
            }
        }
    }
}
