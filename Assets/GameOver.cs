using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    GameObject go;
    public GameObject bb;
    public static bool gameOver;
    // Start is called before the first frame update
    void Awake()
    {
        go = GameObject.Find("GameOver");
        go.SetActive(false);
        gameOver = false;
        GameObject.Find("Player").GetComponent<Player>().OnDeath += Lose;
    }

    private void Lose(object sender, EventArgs e)
    {
        Time.timeScale = 0;
        go.SetActive(true);
        bb.SetActive(true);
        gameOver = true;
    }
}
