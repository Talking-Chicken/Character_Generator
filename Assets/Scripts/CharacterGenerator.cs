using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

/*this class stores a stat that player has,
  each stat needs a name and a int value to construct*/
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

/*this class stores and modifies values (stats and inventory) of character
   has function of random generate character, sort inventory by name or default*/
public class CharacterGenerator : MonoBehaviour
{
    //stats
    private Stat strength = new Stat("Strength",0), 
                 toughness = new Stat("Toughness",0), 
                 dexterity = new Stat("Dexterity",0), 
                 iq = new Stat("IQ",0), 
                 power = new Stat("Power",0), 
                 charm = new Stat("Charm",0);
    private int maxValue = 99;
    private string characterName;
    [SerializeField] private TextMeshProUGUI characterNameText;

    private StatsEntry[] statsEntries;
    private Stat[] statList = new Stat[6];

    //inventory
    private string[] defaultInventory = new string[]{"Sword", "Torch", "Potion", "Staff", "Book", "Stone", "Amulet"};
    private string[] inventory;
    private InventoryEntry[] inventoryEntryList;
    
    //getter & setter
    public int MaxValue {get {return maxValue;} set {maxValue = value;}}
    

    void Start()
    {
        //set up stats
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

        //set up inventory
        inventory = defaultInventory;
        inventoryEntryList = FindObjectsOfType<InventoryEntry>();
        //sort the entry list by name
        inventoryEntryList = inventoryEntryList.OrderBy(entry => entry.name).ToArray<InventoryEntry>();

        for (int i = 0; i < inventoryEntryList.Length; i++) {
            inventoryEntryList[i].Item = inventory[i];
        }
        
    }

    void Update() {
        characterName = characterNameText.text;
    }

    /*sort the inventory list by name and assign them to inventory entries in the list*/ 
    public void sortInventoryByName() {
        inventory = inventory.OrderBy(item => item).ToArray<string>();
        for (int i = 0; i < inventoryEntryList.Length; i++) {
            inventoryEntryList[i].Item = inventory[i];
        }
    }

    /*assign items in default inventory list to inventory entries in the list*/
    public void sortInventoryByDefault() {
        for (int i = 0; i < defaultInventory.Length; i++) {
            inventoryEntryList[i].Item = defaultInventory[i];
        }
    }

    /*randomize stats value of each stats*/
    public void randomizeStats() {
        foreach (StatsEntry statsEntry in statsEntries) {
            statsEntry.stat.statValue = Random.Range(0,statsEntry.stat.maxValue);
        }
    }
}
