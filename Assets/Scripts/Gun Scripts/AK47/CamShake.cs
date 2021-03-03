using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    public Animator animator;
    //private bool isShake = false;
     void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //animator.SetBool("Shake", true);
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            //animator.SetBool("Shake", false);
        }
    }
}
