using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private Transform ObjToFollow = null;
    public bool FollowPlayer = false;
    private AudioSource boom;

    void Awake()
    {
        if (FollowPlayer)
        {
            return;
        }
        GameObject PlayerObj = GameObject.FindGameObjectWithTag("Player");
        if (PlayerObj != null)
        {
            ObjToFollow = PlayerObj.transform;
        }
    }
    
    void Update()
    {
        if (ObjToFollow == null)
        {
            return;
        }
        Vector3 DirToFollow = ObjToFollow.position - transform.position;

        if (DirToFollow != Vector3.zero)
        {
            transform.localRotation = Quaternion.LookRotation(DirToFollow.normalized, Vector3.up);
        }
    }

    void OnDestroy()
    {
        boom = GameObject.Find("Canvas").GetComponent<AudioSource>();
        boom.Play();
    }
}
