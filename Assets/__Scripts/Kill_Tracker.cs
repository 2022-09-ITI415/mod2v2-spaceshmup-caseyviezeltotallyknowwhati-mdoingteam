using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Kill_Tracker : MonoBehaviour
{
    public int startLevelKillCount = 1;
    public int KillCount;
    public Text Destroyed;
    public Text levelText;
    string destroyText;
    public int EnemiesToDestroy;
    // Start is called before the first frame update
    void Start()
    {
        KillCount = 0;
        EnemiesToDestroy = startLevelKillCount;
        destroyText = "Enemies Destroyed: " + KillCount + "/" + EnemiesToDestroy;
        Destroyed.text = destroyText;

    }
    public void IncreaseKillCount()
    {
        KillCount = KillCount + 1;
        destroyText = "Enemies Destroyed: " + KillCount + "/" + EnemiesToDestroy;
        Destroyed.text = destroyText;
        if (KillCount == EnemiesToDestroy)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy);
            }
            KillCount = 0;
            EnemiesToDestroy = EnemiesToDestroy + 5;
            destroyText = "Enemies Destroyed: " + KillCount + "/" + EnemiesToDestroy;
            StartCoroutine(NewLevelLoad());
        }
    }

    IEnumerator NewLevelLoad()
    {
        //Display Level complete text
        levelText.gameObject.SetActive(true);
        levelText.text = "Mission Complete";
        yield return new WaitForSeconds(1);
        //Display new level text
        levelText.text = "New Mission Objective\n" + destroyText;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        yield return new WaitForSeconds(2);
        levelText.gameObject.SetActive(false);
        Destroyed.text = destroyText;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        //Display new enemies to destroy text
    }
}
