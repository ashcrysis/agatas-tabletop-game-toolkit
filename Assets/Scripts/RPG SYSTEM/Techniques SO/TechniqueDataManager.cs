using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechniqueDataManager : MonoBehaviour
{
    public List<Technique> knownTechniqueDatas = new List<Technique>();
    public List<Technique> allTechniqueDatas; 
    
    private PlayerCharacter playerStats;
    private TechniqueDataManager techniqueManager;

    void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharacter>();
        techniqueManager = GetComponent<TechniqueDataManager>();
        
        foreach  (var technique in knownTechniqueDatas)
        {
            technique.lastUsedTime = -Mathf.Infinity; ;
        }
        
        StartCoroutine(delayedStartTechniques(1f));
    }
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.F))
        {
            UseFirstKnownTechnique();
        }
    }
    IEnumerator delayedStartTechniques(float time)
    {
        yield return new WaitForSeconds(time);
        UnlockStartingTechniques();
    }
    void UnlockStartingTechniques()
    {
        foreach (Technique TechniqueData in allTechniqueDatas)
        {
            if (CanLearnTechniqueData(TechniqueData))
            {
                LearnTechniqueData(TechniqueData);
            }
        }
    }

    bool CanLearnTechniqueData(Technique TechniqueData)
    {
        if (playerStats.Level < TechniqueData.requiredLevel)
            return false;

        if (TechniqueData.isClassExclusive && TechniqueData.classRequirement != playerStats.CharacterClass.name)
            return false;

        if (TechniqueData.isRaceExclusive && TechniqueData.raceRequirement != playerStats.Race.name)
            return false;

        return true;
    }

    public void LearnTechniqueData(Technique TechniqueData) // will use this method to unlock techniques that the player choose on level up
    {
        if (!knownTechniqueDatas.Contains(TechniqueData))
        {
            knownTechniqueDatas.Add(TechniqueData);
            Debug.Log($"Learned: {TechniqueData.techniqueName}");
        }
    }

    public void UseTechniqueData(string TechniqueDataName)
    {
        Technique TechniqueData = knownTechniqueDatas.Find(t => t.techniqueName == TechniqueDataName);
        if (TechniqueData != null)
        {
            TechniqueData.Use(playerStats);
        }
        else
        {
            Debug.Log("You don't know this TechniqueData!");
        }
    }

    public void CheckForNewUnlocks()
    {
        foreach (Technique TechniqueData in allTechniqueDatas)
        {
            if (!knownTechniqueDatas.Contains(TechniqueData) && CanLearnTechniqueData(TechniqueData))
            {
                LearnTechniqueData(TechniqueData);
            }
        }
    }

    void UseFirstKnownTechnique()
    {
        if (techniqueManager.knownTechniqueDatas.Count > 0)
        {
            techniqueManager.knownTechniqueDatas[0].Use(playerStats);
        }
        else
        {
            Debug.Log("No techniques learned yet!");
        }
    }
}
