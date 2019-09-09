using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drumscript : MonoBehaviour
{
    public AudioSource drumSound;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        drumSound = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("bam");
        drumSound.Play();

    }
}
