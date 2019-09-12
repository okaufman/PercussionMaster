using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

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
      //  Debug.Log("hit");
        drumSound.Play();



    }

    private void OnCollisionEnter(Collision collision)
    {
        if (this.gameObject.CompareTag("otherCollider") || this.gameObject.CompareTag("BoxCollider") && isHittedOnTop(this.gameObject, collision.gameObject))
            drumSound.Play();

    }

    private bool isHittedOnTop(GameObject Object, GameObject ObjectHit)
    {
        bool hittedOnTop = false;
        RaycastHit MyRayHit;
        Vector3 direction = (Object.transform.position - ObjectHit.transform.position).normalized;
        Ray MyRay = new Ray(ObjectHit.transform.position, direction);

        if (Physics.Raycast(MyRay, out MyRayHit))
        {
            if (MyRayHit.collider != null)
            {
                Vector3 MyNormal = MyRayHit.normal;
                MyNormal = MyRayHit.transform.TransformDirection(MyNormal);

                if (MyNormal == MyRayHit.transform.up)
                    hittedOnTop = true;
            }
        }
        return hittedOnTop;
    }
}
