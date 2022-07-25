using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundMute : MonoBehaviour
{

    [Header("Audio")]
    public AudioSource audio;
    public Sprite[] AudioSprite;
    public Image audioimage;


    public void soundmang()
    {
        if (audio.volume == 1)
        {
            audio.volume = 0;
            audioimage.sprite = AudioSprite[0];
        }
        else
        {
            audio.volume = 1;
            audioimage.sprite = AudioSprite[1];
        }
    }
}
