using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryEntry : MonoBehaviour
{
    private string item;
    [SerializeField] private TextMeshProUGUI itemNameText;

    public string Item {get {return item;} set {item = value;}}

    void Update()
    {
        itemNameText.text = item;
    }
}
