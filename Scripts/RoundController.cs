using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class RoundController : MonoBehaviour
{
    public int round = 1;
    [SerializeField]
    [Range(0.1f, 360f)]
    public float roundTime;
    public int hp;
    private float hold;
    private HealthController playerHealthController;
    [SerializeField]
    public float diffculityFactor;
  
    private void Start()
    {
        
        if (GameObject.FindWithTag("Player") != null)
        {
            playerHealthController = GameObject.FindWithTag("Player").GetComponent<HealthController>();
          
        }
        else
            hp = 0;
        
        hold = roundTime;
    }
    private void Update()
    {
        roundTime -= Time.deltaTime;
        if (playerHealthController != null)
        {
            hp = playerHealthController.hp;
            Debug.Log("Hp sent");
        }
            if (roundTime <= 0)
        {
            round++;
            roundTime = hold;
        }
    }
}
