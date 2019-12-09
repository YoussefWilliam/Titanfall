using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : MonoBehaviour
{
    public Animator anim;
    public Transform target;
    public Vector3 offset;
    public Vector3 rotationOffset;
    public float damage = 70f;
    public float range = 4f;
    public ParticleSystem flash;



    // Update is called once per frame
    void Update()
    {
        transform.position = anim.GetBoneTransform(HumanBodyBones.RightHand).position + offset;
        transform.rotation = anim.GetBoneTransform(HumanBodyBones.RightHand).rotation * Quaternion.Euler(rotationOffset.x, rotationOffset.y, rotationOffset.z);
    }
    public void Shoot()
    {
        FaceTarget();
        flash.Play();
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            // TO DECREASE THE PLAYER HEALTH IF IT WAS HIT
            if (hit.transform.name == "Player")
            {
                // Decrease his health by the damage points 
                Player t = hit.transform.GetComponent<Player>();
                if (t != null)
                {
                    t.TakeDamage(damage);
                }
            }


        }
    }
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        //transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime*10f);
        transform.rotation = lookRotation;
    }
}
