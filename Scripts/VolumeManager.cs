using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeManager : MonoBehaviour
{
    public Slider volumeController;
    public AudioMixer mixer;

    public void ChangeVolume()
    {
        mixer.SetFloat("MainVol", volumeController.value);
        Debug.Log($"Volume Changed By {volumeController.value}");
    }
    
}
