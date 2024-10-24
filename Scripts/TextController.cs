using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    [SerializeField]
    public Text textObject;
    public string text;
    public RoundController controller;
    private void Start()
    {
        controller = GameObject.FindWithTag("EventSystem").GetComponent<RoundController>();
       
        /* TO DO: if i have more than 5 text objects then i should create a dictionary of all tags than iterate through them
         * right now this works but is very inefficent*/
    }
    void Update()
    {
        if (gameObject.tag.Equals("Round_Text"))
        {
            text = $"{controller.round}";
        }
        else if (gameObject.tag.Equals("RoundTime_Text"))
        {
            text = $"{controller.roundTime}";
        }
        else if (gameObject.tag.Equals("Hp_Text"))
        {
            text = $"{controller.hp}";
            Debug.Log("Received player HP");
        }
        else
        {
            text = null;
        }
        textObject.text = text;
    }
}
