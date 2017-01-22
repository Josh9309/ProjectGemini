using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDScript : MonoBehaviour
{
    private UnityEngine.UI.Image frontCircle;
    private UnityEngine.UI.Image backCircle;
    private UnityEngine.UI.Image frontSoundBar;
    private UnityEngine.UI.Image endgameBackground;
    private UnityEngine.UI.Image endgameBox;
    private UnityEngine.UI.Text countdown;
    private UnityEngine.UI.Text[] endgameText = new UnityEngine.UI.Text[2];
    private UnityEngine.UI.Text mainMenuText;
    private Player playerScript;
    private List<Enemy> enemies;
    private List<key> keys;
    private List<Enemy> enemiesInPursuit;
    private Color defaultBackCircleColor;

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
            else if (allUIImages[i].name == "StaticCircle")
            {
                backCircle = allUIImages[i];
                backCircle.color = new Color(GameManager.playerColor.r, GameManager.playerColor.g, GameManager.playerColor.b, 100/255f);
                defaultBackCircleColor = backCircle.color;
            }
            else if (allUIImages[i].name == "FillSoundBar")
            {
                frontSoundBar = allUIImages[i];
            }
            else if (allUIImages[i].name == "EndgameBackground")
            {
                endgameBackground = allUIImages[i];
            }
            else if (allUIImages[i].name == "EndgameBox")
            {
                endgameBox = allUIImages[i];
                endgameBox.enabled = false;
            }
        }

        UnityEngine.UI.Text[] allUIText = GetComponentsInChildren<UnityEngine.UI.Text>();
        int endgameTextCount = 0;

        for (int i = 0; i < allUIText.Length; i++)
        {
            if (allUIText[i].name == "PingPercent")
            {
                countdown = allUIText[i];
            }
            else if (allUIText[i].name.Contains("EndgameText"))
            {
                endgameText[endgameTextCount] = allUIText[i];
                endgameTextCount++;
            }
            else if (allUIText[i].name == "BootToMain")
            {
                mainMenuText = allUIText[i];
                mainMenuText.enabled = false;
            }
        }

        GameObject[] allGameObjects = FindObjectsOfType<GameObject>();
        enemies = new List<Enemy>();
        keys = new List<key>();

        for (int i = 0; i < allGameObjects.Length; i++)
        {
            if (allGameObjects[i].tag == "Enemy")
            {
                enemies.Add(allGameObjects[i].GetComponent<Enemy>());
                allGameObjects[i].GetComponentInChildren<Renderer>().material.color = GameManager.enemyColor;
            }
            else if (allGameObjects[i].tag == "key")
            {
                keys.Add(allGameObjects[i].GetComponent<key>());
                allGameObjects[i].GetComponent<Renderer>().material.color = GameManager.playerColor;
            }
            else if (allGameObjects[i].tag == "Player")
            {
                playerScript = allGameObjects[i].GetComponent<Player>();
                allGameObjects[i].GetComponentInChildren<Renderer>().material.color = GameManager.playerColor;
            }
        }

        playerScript = FindObjectOfType<Player>();

        enemiesInPursuit = new List<Enemy>();
    }	
	
	void Update() //Update is called once per frame
    {
        PingUI();
        SoundUI();
        CheckGameState();
	}

    void PingUI() //Manage ping cooldown and enemy alert
    {
        if (frontCircle.fillAmount > 0 && !playerScript.RefillPing && !playerScript.HasPing)
        {
            frontCircle.fillAmount -= Time.deltaTime;
        }
        else if (playerScript.RefillPing)
        {
            frontCircle.fillAmount += Time.deltaTime / 2f;
        }

        if (enemiesInPursuit == null && enemiesInPursuit.Count > 0)
        {
            foreach (Enemy e in enemiesInPursuit)
            {
                if (!e.Pursuit)
                {
                    enemiesInPursuit.Remove(e);
                }
                else
                {
                    countdown.text = "!";
                    backCircle.color = Color.Lerp(defaultBackCircleColor, Color.red, Mathf.PingPong(Time.time, 1));
                }
            }
        }
        else
        {
            foreach (Enemy e in enemies)
            {
                if (!e.Pursuit)
                {
                    countdown.text = ((int)(frontCircle.fillAmount * 100)).ToString();
                    backCircle.color = defaultBackCircleColor;
                }
                else
                {
                    enemiesInPursuit.Add(e);
                }
            }
        }
    }

    void SoundUI() //Sound with crouching and such
    {
        frontSoundBar.fillAmount = playerScript.Noise / 425f;
    }

    void CheckGameState() //Check if the game is over
    {
        if (playerScript.Health <= 0) //If the player is dead
        {
            //Time.timeScale = 0; //Pause

            endgameBackground.color = new Color(1, 92f / 255f, 92f / 255f, 100f / 255f);

            if (endgameBackground.fillAmount < 1)
            {
                endgameBackground.fillAmount += Time.deltaTime;
            }
            else
            {
                foreach (UnityEngine.UI.Text t in endgameText)
                {
                    t.text = "You have been captured!\nGame over";
                }

                endgameBox.enabled = true;

                StartCoroutine(Timer());
            }
        }
    }

    public void SceneChange(string sceneName)
    {
        //Time.timeScale = 1; //Unpause
        SceneManager.LoadScene(sceneName);
    }

    internal IEnumerator Timer()
    {
        yield return new WaitForSeconds(1);

        mainMenuText.enabled = true;
    }
}