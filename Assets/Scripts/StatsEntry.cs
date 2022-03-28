using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class StatsEntry : MonoBehaviour
{
    [SerializeField] private Stat statValue;
    public Stat stat {get {return statValue;} set {statValue = value;}}
    [SerializeField] private TextMeshProUGUI statValueText, statNameText;

    void Update() {
      statNameText.text = stat.statName;
      statValueText.text = stat.statValue.ToString();
    }

    public void addValue() {
      stat.addValue();
    }

    public void subtractValue() {
      stat.subtractValue();
    }
}
