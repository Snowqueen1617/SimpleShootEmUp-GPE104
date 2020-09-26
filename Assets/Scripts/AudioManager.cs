using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip Pew;
    public AudioClip Begin;
    // Start is called before the first frame update
    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.clip = Pew;
            audioSource.Play();
        }

        //if(Input.GetKeyDown(KeyCode.P))
        //{
        //    audioSource.clip = Begin;
        //    audioSource.Play();
        //}
    }


}
