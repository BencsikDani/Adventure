using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public float maxHP = 100f;
    float currentHP;
    Transform bar;
    public bool gotTheKey;
    public event EventHandler OnDeath;

    private void Awake()
    {
        currentHP = maxHP;
        bar = transform.Find("Bar");
        gotTheKey = false;
    }

    public void Damage()
    {
        currentHP = currentHP - 10;
        UpdateHealthBar();
        if (currentHP == 0f)
        {
            OnDeath?.Invoke(this, EventArgs.Empty);
        }
    }

    public void UpdateHealthBar()
    {
        GameObject.Find("HealthBar").GetComponent<HealthBar>().SetHealthBar(currentHP, maxHP);
    }
}
