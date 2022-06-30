using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackBar : MonoBehaviour
{
    GameObject bb;
    private void Awake()
    {
        bb = GameObject.Find("BackBar");
        GameObject.Find("VictoryHandler").GetComponent<Victory>().bb = bb;
        GameObject.Find("GameOverHandler").GetComponent<GameOver>().bb = bb;
        bb.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !GameOver.gameOver && !Victory.victory)
        {
            bool activity = bb.activeInHierarchy;
            if (activity)
            {
                bb.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                bb.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void BackToTheMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
