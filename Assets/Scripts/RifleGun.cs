using UnityEngine;

public class RifleGun : MonoBehaviour
{
    public Animator anim;
    public Vector3 offset;
    public Vector3 rotationOffset;
    public float damage = 10f;
    public float range = 65f;

    // Update is called once per frame
    void Update()
    {
        transform.position = anim.GetBoneTransform(HumanBodyBones.RightHand).position + offset;
        transform.rotation = anim.GetBoneTransform(HumanBodyBones.RightHand).rotation * Quaternion.Euler(rotationOffset.x, rotationOffset.y, rotationOffset.z);
    }
    public void Shoot()
    {
        Debug.Log("Rifle shoot");
    }
}
