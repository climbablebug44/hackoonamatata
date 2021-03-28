using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundEffects : MonoBehaviour
{

    public static AudioClip GameOver;
    static AudioSource audioSrc;
    public bool death = false;

    // Start is called before the first frame update
    void Start()
    {
        GameOver = Resources.Load<AudioClip>("GameOver");

        audioSrc = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -20.0f)
        {
            death = true;
        }    
    }

    public void gameSound()
    {
        if (death == true)
        {
            audioSrc.PlayOneShot (GameOver);
        } 
    }
}

