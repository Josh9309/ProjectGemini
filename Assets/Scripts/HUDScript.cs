using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDScript : MonoBehaviour
{
    private UnityEngine.UI.Image frontCircle;
    private UnityEngine.UI.Image backCircle;
    private UnityEngine.UI.Text countdown;
    private Player playerScript;
    private List<GameObject> enemies;
    private List<GameObject> keys;

    void Start() //Use this for initialization
    {
        //GameManager.Instance

        UnityEngine.UI.Image[] allUIImages = GetComponentsInChildren<UnityEngine.UI.Image>();

        for (int i = 0; i < allUIImages.Length; i++)
        {
            if (allUIImages[i].name == "FillCircle")
            {
                frontCircle = allUIImages[i];
                frontCircle.color = new Color(GameManager.playerColor.r, GameManager.playerColor.g, GameManager.playerColor.b, 1);
            }
            if (allUIImages[i].name == "StaticCircle")
            {
                backCircle = allUIImages[i];
                backCircle.color = new Color(GameManager.playerColor.r, GameManager.playerColor.g, GameManager.playerColor.b, 100/255f);
            }
        }

        countdown = FindObjectOfType<UnityEngine.UI.Text>();

        GameObject[] allGameObjects = FindObjectsOfType<GameObject>();
        enemies = new List<GameObject>();
        keys = new List<GameObject>();
        int numEnemies = 0;
        int numKeys = 0;

        for (int i = 0; i < allGameObjects.Length; i++)
        {
            if (allGameObjects[i].tag == "Enemy")
            {
                enemies.Add(allGameObjects[i]);
                enemies[numEnemies].GetComponent<Renderer>().material.color = GameManager.enemyColor;
                numEnemies++;
            }
            else if (allGameObjects[i].tag == "key")
            {
                keys.Add(allGameObjects[i]);
                keys[numKeys].GetComponent<Renderer>().material.color = GameManager.playerColor;
                numKeys++;
            }
            else if (allGameObjects[i].tag == "Player")
            {
                playerScript = allGameObjects[i].GetComponent<Player>();
                allGameObjects[i].GetComponentInChildren<Renderer>().material.color = GameManager.playerColor;
            }
        }

        playerScript = FindObjectOfType<Player>();;
    }	
	
	void Update() //Update is called once per frame
    {
        PingUI();	
	}

    void PingUI()
    {
        if (frontCircle.fillAmount > 0 && playerScript.PingObj.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime < playerScript.PingObj.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length)
        {
            frontCircle.fillAmount -= Time.deltaTime;
        }
        else if (!(playerScript.PingObj.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime < playerScript.PingObj.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length))
        {
            frontCircle.fillAmount += Time.deltaTime / 1.5f;
        }

        countdown.text = ((int)(frontCircle.fillAmount * 100)).ToString();
    }
}