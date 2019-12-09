using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject primaryWeapon;
    public GameObject secondryWeapon;
    public KeyCode z;
    public int core;
    public int hp;

    public float damage = 10.0f;
    public float range = 100f;
    public int maxAmmo;
    public int ammo;
    public Camera cam;
    public ParticleSystem flash;
    public KeyCode fireKey;
    public KeyCode reloadKey;

    public int weaponIndex;
    public GameObject gun1;
    public GameObject gun2;
    public GameObject gun3;

    public Animator anim;

    public bool embark;

    void Start()
    {
        ammo = maxAmmo;
        if (weaponIndex == 1)
        {
            Destroy(gun2);
            Destroy(gun3);
        }

        if (weaponIndex == 2)
        {
            Destroy(gun1);
            Destroy(gun3);
        }

        if (weaponIndex == 3)
        {
            Destroy(gun1);
            Destroy(gun2);
        }
    }

    void Update()
    {
        embark = false;
        if (Input.GetKeyDown(z))
        {
            primaryWeapon.SetActive(!primaryWeapon.activeSelf);
            secondryWeapon.SetActive(!secondryWeapon.activeSelf);
        }

        if (Input.GetKeyDown(fireKey) && ammo>0)
        {
            Fire();
        }

        if (Input.GetKeyDown(reloadKey))
        {
            Reload();
        }

        RaycastHit titan;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out titan, 2f))
        {
            if (titan.transform.name.Equals("Titan")){

                embark = true;
            }
        }
    }

    public void CoreUp()
    {
        core++;
    }

    void Fire()
    {
        flash.Play();
        ammo--;

        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            EnemyPilot t = hit.transform.GetComponent<EnemyPilot>();
            if (t != null)
            {
                t.TakeDamage(damage);
            }
        }
    }

    void Reload()
    {
        anim.SetTrigger("Reload");
        ammo = maxAmmo;
    }
}
