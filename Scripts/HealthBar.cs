using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    [SerializeField]
    private int hp = 0;
    void FixedStart()
    {
        if (GameObject.FindWithTag("Player").GetComponent<HealthController>() != null)
        {
            hp= GameObject.FindWithTag("Player").GetComponent<HealthController>().hp;
            healthSlider.maxValue = hp;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(GameObject.FindWithTag("Player").name);
        Debug.Log(GameObject.FindWithTag("Player").GetComponent<HealthController>().hp);
        hp = GameObject.FindWithTag("Player").GetComponent<HealthController>().hp;
        healthSlider.value = hp;
        
    }
}
