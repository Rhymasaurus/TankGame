using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    public GameObject playerObject;
    [SerializeField]
    public Dictionary<int, Action<float>> upgradeMap;
    private void Awake()
    {
        upgradeMap = new Dictionary<int, Action<float>>
        {
            {0,RestoreHealth},
            {1,AddArmor},
            {2,ShootingSpeed},
            {3, AddSpeed}
        };
    }
    public void RestoreHealth(float precentRestore)//0
    {
        if(playerObject !=null && playerObject.GetComponent<HealthController>() != null)
        {
            var restoredHealth = playerObject.GetComponent<HealthController>().maxHp;
            playerObject.GetComponent<HealthController>().hp = (int)(restoredHealth * precentRestore);
        }
    }    
    public void AddArmor(float amtToAdd)//1
    {
        playerObject.GetComponent<HealthController>().setMaxHp((int)amtToAdd);
    }
    public void ShootingSpeed(float cooldownFactor)//2
    {
        var shootingSpeed = GameObject.FindWithTag("Weapon").GetComponentInChildren<WeaponController>().shootingSpeed;
        GameObject.FindWithTag("Weapon").GetComponentInChildren<WeaponController>().shootingSpeed = shootingSpeed * cooldownFactor;
    }
    public void AddSpeed(float speedIncrease)//3
    {
        var maxSpeed = playerObject.GetComponent<PlayerController>().speed;
        playerObject.GetComponent<PlayerController>().speed = maxSpeed + (maxSpeed  * speedIncrease);
    }

}
