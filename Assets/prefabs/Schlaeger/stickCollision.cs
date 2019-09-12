using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stickCollision : MonoBehaviour
{

    public AudioSource stickSound;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        stickSound = GetComponent<AudioSource>();
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision hit");
        
        if (collision.gameObject.tag == "stick")
        {
            stickSound.Play();
        }

    }
}
