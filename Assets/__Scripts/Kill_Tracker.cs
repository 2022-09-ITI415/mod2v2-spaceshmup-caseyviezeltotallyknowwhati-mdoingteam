using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Kill_Tracker : MonoBehaviour
{
    public int KillCount;
    public Text Destroyed;
    public int EnemiesToDestroy;
    // Start is called before the first frame update
    void Start()
    {
        KillCount = 0;
        Destroyed.text = "Enemies Destroyed: " + KillCount + "/" + EnemiesToDestroy;

    }
    public void IncreaseKillCount()
    {
        KillCount = KillCount + 1;
        if (KillCount == EnemiesToDestroy)
        {
            SceneManager.LoadScene("_Scene_0");
            KillCount = 0;
            EnemiesToDestroy = EnemiesToDestroy + 5;
        }
        Destroyed.text = "Enemies Destroyed: " + KillCount + "/" + EnemiesToDestroy;
    }
}
