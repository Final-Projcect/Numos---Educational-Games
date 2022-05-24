using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playmod : MonoBehaviour
{
    public AudioSource[] sound;
    public AudioSource currect;
    public AudioSource err2;

    public bool ss = false;
    
    // Start is called before the first frame update
    void Start()
    {
        AudioSource[] audios = GetComponents<AudioSource>();
        
        currect = audios[0];
        //currect.Play();

        err2 = audios[1];
        //err2.Play();
    }

    // Update is called once per frame
    public void PlaySound(bool status)
    {
        if (status == true)
        {
            ss = true;
            currect.Play();
        }
        else
        {
             ss = false;
            err2.Play();
        }
           
    }

    private void Update()
    {
        Debug.Log("hi blablabla" + currect.isPlaying);
    }

    //IEnumerator  
}
