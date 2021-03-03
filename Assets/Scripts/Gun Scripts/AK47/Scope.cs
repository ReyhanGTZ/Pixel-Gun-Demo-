using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour
{
    public Camera mainCamera;
    public float scopedFOV = 15f;
    private float normalFOV = 60f;
    public Animator animator;
    //private bool isScoped = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire2"))
        {
            mainCamera.fieldOfView = scopedFOV;
            animator.SetBool("Scoped", true);
        }
        else if (Input.GetButtonUp("Fire2"))
        {
            mainCamera.fieldOfView = normalFOV;
            animator.SetBool("Scoped", false);
        }

    }
}
