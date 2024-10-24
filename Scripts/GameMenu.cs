using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    public void StopGameTime()
    {
        Time.timeScale = 0;
        Debug.Log($"Game stoped at{Time.fixedTime}");
    }
    public void StartGameTime()
    {
        Time.timeScale = 1;
        Debug.Log($"Game Started at{Time.fixedTime}");
    }
}
