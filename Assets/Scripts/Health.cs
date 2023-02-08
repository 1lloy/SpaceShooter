using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject DeathParticles = null;
    public bool ShouldDestroyOnDeath = true;
    public TextMeshProUGUI scoretxt;
    
    [SerializeField] private float _HP = 100;

    public float HP
    {
        get
        {
            return _HP;
        }
        set
        {
            _HP = value;
            if (HP <= 0)
            {
                SendMessage("Die", SendMessageOptions.DontRequireReceiver);
                if (DeathParticles != null)
                {
                    Instantiate(DeathParticles, transform.position, transform.rotation);

                }
                if (ShouldDestroyOnDeath)
                {
                    if (gameObject.CompareTag("Player"))
                    {
                        GameController.GameOver();
                        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
                        for (int i = 0; i < Enemies.Length; i++)
                        {
                            Destroy(Enemies[i]);
                        }
                    }
                    Destroy(gameObject);
                }
            }
        }
    }
}
