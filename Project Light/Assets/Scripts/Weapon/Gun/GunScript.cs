﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GunScript : MonoBehaviour
{
    public string WeaponType;

    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 30f;


    new public Transform transform;
    public Camera cam;
    Animator anim;
    public float animSpeed = 1;

    private float nextTimeToFire = 0f;
    public float fireRate;
    public Text ammoText;
    public Text helperText;

    public Inventory ammo;
    public int clipSize = 6;
    public int currentAmmo = -1;
    public float reloadTime = 1f;
    private bool isReloading = false;
    public LayerMask mask;
    public bool invertMask;

    public ParticleSystem muzzleFlash;
    //public GameObject impactEffect;
    void Start()
    {
        currentAmmo = clipSize;

        anim = GetComponent<Animator>();
        anim.speed = animSpeed;
    }
    void Update()
    {
        if (isReloading)
            return;

        if (!isReloading && currentAmmo > 0)
        {
            helperText.text = "";
            if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                Shoot();
                muzzleFlash.Play();

            }
        }
        if(!isReloading && currentAmmo <= 0)
            helperText.text = "Out of Ammo";

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
            return;
        }

        if (WeaponType == "Revolver")
        {
            ammoText.text = currentAmmo + " / " + clipSize + " " + ammo.gAmmoTotal.ToString();
        }

        if (WeaponType == "Rifle")
        {
            ammoText.text = currentAmmo + " / " + clipSize + " " + ammo.rAmmoTotal.ToString();
        }
    }

    IEnumerator Reload()
    {
        int remAmmo = currentAmmo;

        isReloading = true;
        print("reloading");
        helperText.text = "Reloading..";

        yield return new WaitForSeconds(reloadTime);

        if(WeaponType == "Revolver")
        {
            if (ammo.gAmmoTotal + currentAmmo >= clipSize)
                currentAmmo = clipSize;
            else if ((ammo.gAmmoTotal + currentAmmo) < clipSize)
                currentAmmo = ammo.gAmmoTotal + remAmmo;

            ammo.gAmmoTotal -= clipSize - remAmmo;
        }

        if(WeaponType == "Rifle")
        {
            if (ammo.rAmmoTotal + currentAmmo >= clipSize)
                currentAmmo = clipSize;
            else if ((ammo.rAmmoTotal + currentAmmo) < clipSize)
                currentAmmo = ammo.rAmmoTotal + remAmmo;

            ammo.rAmmoTotal -= clipSize - remAmmo;
        }
        

        isReloading = false;
    }

    void Shoot()
    {
        FindObjectOfType<AudioManager>().Play("GunShot", 0.25f, 1f);

        RaycastHit hit;

        anim.SetTrigger("RifleShoot");
        LayerMask newMask = ~(invertMask ? ~mask.value : mask.value);
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range, newMask))
        {
            Debug.Log(hit.transform.name);
            TargetScript target = null;

            if (hit.transform.GetComponent<TargetScript>() != null)
                target = hit.transform.GetComponent<TargetScript>(); 

            if (target != null)
            {
                target.TakeDamage(damage);
            }
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            //GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            //Destroy(impactGO, 1f);
        }

        currentAmmo--;
    }
}
