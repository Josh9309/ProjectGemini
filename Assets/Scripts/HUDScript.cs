using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDScript : MonoBehaviour
{
    private UnityEngine.UI.Image[] pingImages = new UnityEngine.UI.Image[2];
    private Player playerScript;

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

        playerScript = FindObjectOfType<Player>();
	}	
	
	void Update() //Update is called once per frame
    {
        PingUI();	
	}

    void PingUI()
    {
        //if ()
    }
}