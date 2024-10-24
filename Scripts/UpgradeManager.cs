using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    //Map 
    public UnityEvent onUpgrade;
    public UnityEvent onEvent;
    public Upgrades upgrades;
    private Action<float>[] randomUpgrades = new Action<float>[3];
    [SerializeField]
    public GameObject[] buttonsObjects;
    [SerializeField]
    public float armrPrecent;
    public float speedPrecent;
    public float cooldownFactor;
    public float precentRestore;
    private Dictionary<Action<float>, float> upgradePrecentMap;
    private void Update()
    {
    
    }
    private void Start()
    {
       
        if (GameObject.FindWithTag("EventSystem").GetComponent<Upgrades>()!=null)
            upgrades = GameObject.FindWithTag("EventSystem").GetComponent<Upgrades>();
            upgradePrecentMap = new Dictionary<Action<float>, float>
        {
            {upgrades.AddArmor,armrPrecent},
            {upgrades.AddSpeed,speedPrecent},
            {upgrades.ShootingSpeed,cooldownFactor},
            {upgrades.RestoreHealth,precentRestore}
        };
        
    }
    public void setUpgrades()
         {
           for(int x = 0; x < randomUpgrades.Length; x++)
             {
            randomUpgrades[x] = upgrades.upgradeMap[(int)UnityEngine.Random.Range(0, 3)];              
             }
            
         }
    public void upgrade()
    {
        onUpgrade.Invoke();
       
        setUpgrades();
        displayUpgrades(randomUpgrades);
        foreach(Action<float> action in randomUpgrades)
        {
            action(upgradePrecentMap[action]);
            Debug.Log($"This action is being used {action}");
        }
    }

    public void displayUpgrades(Action<float>[] randomUpgrades)
    {
        int index = 0;
        foreach(GameObject buttonObject in buttonsObjects)
        {

            if (buttonObject.GetComponentInChildren<Text>() != null)
                buttonObject.GetComponentInChildren<Text>().text = $"{randomUpgrades[index]}";
            Debug.Log($"{randomUpgrades[index]}");
           index++;
        }
    }
}
