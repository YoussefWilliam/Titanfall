using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public float hp = 50.0f;
    public GameObject player;

    public void TakeDamage(float dmg)
    {
        hp -= dmg;
        if(hp <= 0f)
        {
            Destroy(gameObject);
            player.GetComponent<Player>().CoreUp();
        }
    }
}
