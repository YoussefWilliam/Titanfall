using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject gameOver;

    public GameObject primaryWeapon;
    public GameObject secondryWeapon;
    public KeyCode z;
    public int core;
    public float hp;

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
    public bool GameOver = false;

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
        if (Input.GetKeyDown(KeyCode.Escape) && !GameOver)
        {
            if (pauseMenu.activeSelf)
            {
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
            }
            else
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
        }
        embark = false;
        if (Input.GetKeyDown(z))
        {
            primaryWeapon.SetActive(!primaryWeapon.activeSelf);
            secondryWeapon.SetActive(!secondryWeapon.activeSelf);
        }

        if (Input.GetKeyDown(fireKey) && ammo>0 && !GameOver)
        {
            Fire();
        }

        if (Input.GetKeyDown(reloadKey) && !GameOver)
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
    public void TakeDamage(float gunDamage)
    {
        hp -= gunDamage;
        if (hp <= 0 && !GameOver)
        {
            gameOver.SetActive(true);
            GameOver = true;
        }
    }
}
