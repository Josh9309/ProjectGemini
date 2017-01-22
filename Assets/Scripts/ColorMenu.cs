using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColorMenu : MonoBehaviour
{
    [SerializeField] private Renderer playerTextureRenderer; //The player's texture renderer
    //[SerializeField] private Renderer enemyTextureRenderer; //The enemy's texture renderer
    [SerializeField] private Renderer enemyUITextureRenderer; //The enemy's UI texture renderer
    private UnityEngine.UI.Image[] colorBoxes = new UnityEngine.UI.Image[11]; //The UI color boxes
    private UnityEngine.UI.Text[] UIText = new UnityEngine.UI.Text[2]; //The UI text
    private UnityEngine.UI.Image currentColorBox; //The currently selected color
    private bool shouldPingPong;
    private bool ping;

    void Start() //Use this for initialization
    {
        //playerModel = m_Player.GetComponent<MeshFilter>(); //Get the player's model
        //playerTextureRenderer = m_Player.GetComponent<Renderer>(); //Get the player's texture renderer
        //enemyModel = m_Enemy.GetComponent<MeshFilter>(); //Get the enemy's model
        //enemyTextureRenderer = m_Enemy.GetComponent<Renderer>(); //Get the enemy's texture renderer

        playerTextureRenderer.material.color = Color.black;
        enemyUITextureRenderer.material.color = Color.black;

        UnityEngine.UI.Image[] allUIImages = FindObjectsOfType<UnityEngine.UI.Image>();
        int numColorBoxes = 0;

        for (int i = 0; i < allUIImages.Length; i++) //For each UI image
        {
            if (allUIImages[i].name.Contains("Box"))
            {
                colorBoxes[numColorBoxes] = allUIImages[i];
                numColorBoxes++;
            }
        }

        UnityEngine.UI.Text[] allUIText = FindObjectsOfType<UnityEngine.UI.Text>();
        int numText = 0;

        for (int i = 0; i < allUIText.Length; i++) //For each UI image
        {
            if (allUIText[i].name.Contains("Text"))
            {
                UIText[numText] = allUIText[i];
                numText++;
            }
        }

        shouldPingPong = false;
        ping = false;

        GameManager.playerColor = Color.black;
        GameManager.enemyColor = Color.black;
    }
	
	void Update() //Update is called once per frame
    {
		if (shouldPingPong)
        {
            StartCoroutine(pingPongFont());
        }
        else
        {
            UIText[0].fontSize = 100;
            UIText[1].fontSize = 100;
        }
	}

    public void OnBoxClick(UnityEngine.UI.Image colorBox) //When a color box is clicked
    {
        if (!shouldPingPong)
        {
            colorBox.GetComponent<UnityEngine.UI.Outline>().effectDistance = new Vector2(10, 10);
            currentColorBox = colorBox; //Set the currently selected color

            shouldPingPong = true;
        }
        else if (currentColorBox != colorBox)
        {
            currentColorBox.GetComponent<UnityEngine.UI.Outline>().effectDistance = new Vector2(2, 2);
            colorBox.GetComponent<UnityEngine.UI.Outline>().effectDistance = new Vector2(10, 10);
            currentColorBox = colorBox; //Set the currently selected color

            shouldPingPong = true;
        }
        else if (currentColorBox == colorBox)
        {
            currentColorBox.GetComponent<UnityEngine.UI.Outline>().effectDistance = new Vector2(2, 2);
            shouldPingPong = false;
        }
    }

    public void OnNameClick(Renderer model) //When a model is clicked
    {
        currentColorBox.GetComponent<UnityEngine.UI.Outline>().effectDistance = new Vector2(2, 2);
        model.material.color = currentColorBox.color; //Set the color of the model

        if (model.name.Contains("Player"))
        {
            playerTextureRenderer.material.color = model.material.color;
        }
        else if(model.name.Contains("Enemy"))
        {
            enemyUITextureRenderer.material.color = model.material.color;
        }

        shouldPingPong = false;
    }

    public void SceneChange(string sceneName)
    {
        if (sceneName == "greybox")
        {
            GameManager.playerColor = playerTextureRenderer.material.color;
            GameManager.enemyColor = enemyUITextureRenderer.material.color;
        }

        SceneManager.LoadScene(sceneName);
    }

    internal IEnumerator pingPongFont()
    {
        if (UIText[0].fontSize < 104 && !ping)
        {
            UIText[0].fontSize++;
            UIText[1].fontSize++;
        }
        else if (UIText[0].fontSize >= 104 && !ping)
        {
            ping = true;
            UIText[0].fontSize++;
            UIText[1].fontSize++;
        }
        else if (UIText[0].fontSize > 95 && ping)
        {
            UIText[0].fontSize--;
            UIText[1].fontSize--;
        }
        else
        {
            ping = false;
        }

        yield return new WaitForSeconds(0);
    }
}