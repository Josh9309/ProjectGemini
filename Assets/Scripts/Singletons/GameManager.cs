using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Handles main play cycle logic. Anything within game manager should happen during gameplay
/// and terminate when advancing to other menus.
/// </summary>
public class GameManager : Singleton<GameManager>
{
    #region Fields
    //Assigned in inspector
    public List<GameObject> players = new List<GameObject>();
    static public Color playerColor = Color.red;
    static public Color enemyColor;
    #endregion

    #region Properties
    #endregion

    protected GameManager() { }

    void Awake()
    {
        //make players
        players.Clear();

        //start game
        StartGame();
    }

    public void StartGame()
    {
        //MenuManager.Instance.GoToScreen("GameScreen");

    }



    void Update()
    {

    }
}
