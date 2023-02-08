using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public float Damage = 100f;
    public float LifeTime = 2f;
    public int ScoreValue = 50;

    void OnEnable()
    {
        CancelInvoke();
        Invoke("Die", LifeTime);
    }

    void OnTriggerEnter(Collider col)
    {
        Health H = col.gameObject.GetComponent<Health>();
        if (H == null)
        {
            return;
        }
        H.HP -= Damage;
        GameController.Score += ScoreValue;
        Die();
    }

    void Die()
    {
        gameObject.SetActive(false);
    }
}
