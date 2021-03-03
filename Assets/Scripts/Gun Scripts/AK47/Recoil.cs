using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Recoil : MonoBehaviour
{
    public Animator animator;
    public ParticleSystem bulletTracer;
   //private bool isRecoil = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("Recoil", true);
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            animator.SetBool("Recoil", false);
        }
    }
}
