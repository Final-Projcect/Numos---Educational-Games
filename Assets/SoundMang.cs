using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundMang : MonoBehaviour
{
    [Header("Audio")]
    //define audio
    //public AudioSource audio;
    public Slider volumeslider;
    public float volumeMang;

    private void Start()
    {
       

        if (!PlayerPrefs.HasKey("musicvolume"))
        {
            PlayerPrefs.SetFloat("musicvolume", 1);
        }
        else
        {
            loadVolume();
        }
    }
    ////voluume///////////////////////
    /// <SetVolume>
    /// set the volume to the time that recived and save it for later use
    /// </SetVolume>
    /// <param name="volume"> contains the value of the volume that recived from the runtime</param>
    public void SetVolume(float volume)
    {
        AudioListener.volume = volumeslider.value;
        volumeMang = volumeslider.value;
        saveVolume();
    }

    /// <loadVolume>
    /// loades the volume 
    /// </loadVolume>
    public void loadVolume()
    {
        volumeslider.value = PlayerPrefs.GetFloat("musicvolume");
    }

    public void LoadVolumeFromBefore()
    {
        volumeslider.value = volumeMang;
    }

    /// <saveVolume>
    /// save the volume data
    /// </saveVolume>
    public void saveVolume()
    {
        PlayerPrefs.SetFloat("musicvolume", volumeslider.value);
    }
}
