using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScopeSniper : MonoBehaviour
{
    public Animator Animator;
    public GameObject scopeOverlay;
    public GameObject weaponCamera;
    public Camera fppCamera;

    public float scopedFOV = 15f;
    private float normalFOV;
    private bool isScoped = false;

    void Update ()
    {
        if (!Input.GetButtonDown("Fire2"))
        {
            return;
        }
        isScoped = !isScoped;
        Animator.SetBool("Scope2", isScoped);

        //scopeOverlay.SetActive(isScoped);
        if (!isScoped)
            OnUnscoped();
        else
            StartCoroutine(OnScoped());
    }

    void OnUnscoped ()
    {
        scopeOverlay.SetActive(false);
        weaponCamera.SetActive(true);

        fppCamera.fieldOfView = normalFOV;
    }

    IEnumerator OnScoped ()
    {
        yield return new WaitForSeconds(.15f);

        scopeOverlay.SetActive(true);
        weaponCamera.SetActive(false);

        normalFOV = fppCamera.fieldOfView;
        fppCamera.fieldOfView = scopedFOV;
    }
}
