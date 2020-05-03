using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCon : MonoBehaviour
{
    public AudioClip destroyed;
    public AudioClip laserShot;
    public AudioClip creditGet;


    // Start is called before the first frame update
    public void Laser()
    {
        GetComponent<AudioSource>().PlayOneShot(laserShot);
    }

    // Update is called once per frame
    public void Destroyed()
    {
        GetComponent<AudioSource>().PlayOneShot(destroyed);
    }

    public void Credited()
    {
        GetComponent<AudioSource>().PlayOneShot(creditGet);
    }
}
