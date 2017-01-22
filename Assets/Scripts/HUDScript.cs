using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class HUDScript : MonoBehaviour
{
    private UnityEngine.UI.Image[] pingImages = new UnityEngine.UI.Image[2];
    private Player playerScript;
    private List<GameObject> enemies;
    private List<GameObject> keys;

    void Start() //Use this for initialization
    {
        //GameManager.Instance

        UnityEngine.UI.Image[] allUIImages = GetComponentsInChildren<UnityEngine.UI.Image>();
        int numPingImages = 0;

        for (int i = 0; i < allUIImages.Length; i++)
        {
            if (allUIImages[i].name.Contains("Circle"))
            {
                pingImages[numPingImages] = allUIImages[i];
                pingImages[numPingImages].color = GameManager.playerColor;
                numPingImages++;
            }
        }

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

        playerScript = FindObjectOfType<Player>();
	}	
	
	void Update() //Update is called once per frame
    {
        //if (playerScript.HasPinged)
        //PingUI();	
	}

    void PingUI()
    {
        
    }
}