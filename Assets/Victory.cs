using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Victory : MonoBehaviour
{
    GameObject v;
    public GameObject bb;
    public static bool victory;
    // Start is called before the first frame update
    void Awake()
    {
        v = GameObject.Find("Victory");
        v.SetActive(false);
        victory = false;
    }

    public void Win()
    {
        Time.timeScale = 0;
        v.SetActive(true);
        bb.SetActive(true);
        victory = true;
    }
}
