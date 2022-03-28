using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat {
    public string statName;
    public int statValue;

    public int maxValue;

    public Stat(string name, int value) {
        statName = name;
        statValue = value;
        maxValue = 99;
    }

    public void addValue() {
        statValue = Mathf.Min(maxValue, statValue+1);
    }

    public void subtractValue() {
        statValue = Mathf.Max(0, statValue-1);
    }
}

/* store and modify values (stats and inventory) of character
   has function of random generate character, sort inventory by name or default*/
public class CharacterGenerator : MonoBehaviour
{
    private Stat strength = new Stat("Strength",0), 
                 toughness = new Stat("Toughness",0), 
                 dexterity = new Stat("Dexterity",0), 
                 iq = new Stat("IQ",0), 
                 power = new Stat("Power",0), 
                 charm = new Stat("Charm",0);
    private int maxValue = 99;
    private string characterName;

    private StatsEntry[] statsEntries;
    private Stat[] statList = new Stat[6];

    //getter & setter
    public int MaxValue {get {return maxValue;} set {maxValue = value;}}
    

    void Start()
    {
        //set up
        statList[0] = strength;
        statList[1] = toughness;
        statList[2] = dexterity;
        statList[3] = iq;
        statList[4] = power;
        statList[5] = charm;
        statsEntries = FindObjectsOfType<StatsEntry>();

        for (int i = 0; i < statsEntries.Length; i++) {
            statsEntries[i].stat = statList[i];
        }
    }

    
    void Update()
    {
        
    }
}
