using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    public Text ammo;
    public Text hp;
    public Text core;
    public GameObject embark;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        ammo.text = player.GetComponent<Player>().ammo.ToString()+"/"+ player.GetComponent<Player>().maxAmmo.ToString();
        hp.text = player.GetComponent<Player>().hp.ToString();
        core.text = player.GetComponent<Player>().core.ToString();
        embark.SetActive(player.GetComponent<Player>().embark);
    }
}
