using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProxyDamage : MonoBehaviour
{
    public float DamageRate = 20f;
    private Image HpBar;

    void Start()
    {
        HpBar = GameObject.Find("UpLeftBar").GetComponent<Image>();
    }

    void OnTriggerStay(Collider col)
    {
        Health H = col.gameObject.GetComponent<Health>();
        Health EnemyH = gameObject.GetComponent<Health>();
        
        if (H == null)
        {
            return;
        }
        H.HP -= DamageRate;
        HpBar.fillAmount = H.HP * 0.01f;
        EnemyH.HP = 0;
    }
}
