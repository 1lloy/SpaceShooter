using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Image HpBar;
    private Health H;
    void Awake()
    {
        H = gameObject.GetComponent<Health>();
        
    }
   
    void FixedUpdate()
    {
        HpBar.fillAmount = H.HP * 0.01f;
    }
}
