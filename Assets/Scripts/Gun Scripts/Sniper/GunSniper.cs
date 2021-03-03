using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using EZCameraShake;
public class GunSniper : MonoBehaviour
{
    AudioSource gameSound;
    AudioClip clipFire;
    AudioClip clipReload;
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 1f;
    public float impactForce = 200;

    public int maxAmmo = 5;
    private int currentAmmo;
    public float reloadTime = 2f;
    private bool isReloading = false;
    public Text ammoDisplay;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    //public ParticleSystem bulletTracer;
    public GameObject impactEffect;

    private float nextTimeToFire = 0f;

    public Animator animator;

    void Start ()
    {
        if (currentAmmo == -1)
            currentAmmo = maxAmmo;

        gameSound = GetComponent<AudioSource>();  
        clipFire = Resources.Load<AudioClip>("Sound/Operator fire sound");
        clipReload = Resources.Load<AudioClip>("Sound/Operator reload sound");
        Debug.Log("clipFire : "+clipFire);
        Debug.Log("reloadFire : "+clipReload);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && currentAmmo < maxAmmo)
        {
            StartCoroutine(Reload());
            return;
        }

        if (isReloading)
            return;

        if (currentAmmo <= 0f)
        {            
            StartCoroutine(Reload());
            return;
        }

        //ammoDisplay.text = currentAmmo.ToString();
        if (Input.GetButtonDown("Fire1") && Time.time >+ nextTimeToFire)
        {
            CameraShaker.Instance.ShakeOnce(10f, 10f, .1f, 1f);
            Debug.Log("Shaking");
            gameSound.clip = clipFire;
            gameSound.Play();
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
        
    }

    IEnumerator Reload ()
    {
        isReloading = true;
        //Debug.Log("Reloading...");

        animator.SetBool("Reload2", true);
        gameSound.clip = clipReload;
        gameSound.Play();
        yield return new WaitForSeconds(reloadTime - .25f);  
        animator.SetBool("Reload2", false);
        yield return new WaitForSeconds(.25f);           

        currentAmmo = maxAmmo;
        isReloading = false;
    }

    void Shoot ()
    {
        //bulletTracer.Play();
        muzzleFlash.Play();

        currentAmmo--;

        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) 
        {
            //Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        }
    }
}