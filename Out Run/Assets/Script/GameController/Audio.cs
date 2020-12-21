using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{

    public GameObject SoundOn;
    public GameObject SoundOff;
    public bool SoundUp = true;

    public GameObject MusicOn;
    public GameObject MusicOff;
    public bool MusicUp = true;


    public void Sound()
    {
        if(SoundUp == true)
        {
            SoundOn.SetActive(false);
            SoundOff.SetActive(true);
            SoundUp = false;
            //Song Setting ...
        }
        else
        {
            SoundOff.SetActive(false);
            SoundOn.SetActive(true);
            SoundUp = true;
            //Song setting...
        } 


    }


    public void Music()
    {
        if (MusicUp == true)
        {
            MusicOn.SetActive(false);
            MusicOff.SetActive(true);
            MusicUp = false;
            //Music Setting ...
        }
        else
        {
            MusicOff.SetActive(false);
            MusicOn.SetActive(true);
            MusicUp = true;
            //Music setting...
        }


    }


}
