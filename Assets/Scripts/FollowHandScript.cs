﻿using UnityEngine;

public class FollowHandScript : MonoBehaviour
{
    public Animator anim;
    public Vector3 offset;
    public Vector3 rotationOffset;

    // Update is called once per frame
    void Update()
    {
        transform.position = anim.GetBoneTransform(HumanBodyBones.RightHand).position + offset;
        transform.rotation = anim.GetBoneTransform(HumanBodyBones.RightHand).rotation * Quaternion.Euler(rotationOffset.x,rotationOffset.y,rotationOffset.z);
    }
}

