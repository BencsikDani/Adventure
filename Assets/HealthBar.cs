using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Transform bar;

    // Start is called before the first frame update
    private void Awake()
    {
        bar = transform.Find("Bar");
    }

    public void SetSize(float sizeNormalized)
    {
        if (sizeNormalized < 0)
            sizeNormalized = 0;
        bar.localScale = new Vector3(sizeNormalized, 1f);
    }

    public void SetHealthBar(float currentHealth, float maxHealth)
    {
        if (currentHealth < 0)
            currentHealth = 0;
        float percentage = currentHealth / maxHealth;
        bar.localScale = new Vector3(percentage, 1f);
    }
}
