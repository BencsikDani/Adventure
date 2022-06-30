using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Diamond : MonoBehaviour
{
    public float floatingPeriod = 2f;
    float time;
    bool wentUp;
    private void Awake()
    {
        time = floatingPeriod;
        wentUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (!wentUp && time < (floatingPeriod / 2))
        {
            transform.position += new Vector3(0f, 0.1f);
            wentUp = true;
        }
        else if (wentUp && time < 0)
        {
            transform.position -= new Vector3(0f, 0.1f);
            time = floatingPeriod;
            wentUp = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
            GameObject.Find("VictoryHandler").GetComponent<Victory>().Win();
    }
}
