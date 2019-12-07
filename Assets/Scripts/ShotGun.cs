using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : MonoBehaviour
{
    public Animator anim;
    public Vector3 offset;
    public Vector3 rotationOffset;
    public float damage = 70f;
    public float range = 4f;

    // Update is called once per frame
    void Update()
    {
        transform.position = anim.GetBoneTransform(HumanBodyBones.RightHand).position + offset;
        transform.rotation = anim.GetBoneTransform(HumanBodyBones.RightHand).rotation * Quaternion.Euler(rotationOffset.x, rotationOffset.y, rotationOffset.z);
    }
    public void Shoot()
    {
        //RaycastHit hit;
        //if(Physics.Raycast(transform.position, transform.forward, out hit, range))
        //{
        //    Debug.Log(hit.transform.name);
        //}

    }
}
