using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour
{
    public Canvas exitMenu;
    public Canvas optionsMenu;
    public Button start;
    public Button exit;
    public Button options;
    public Button credits;

	// Use this for initialization
	void Start ()
    {
        //instantiate values
        exitMenu = exitMenu.GetComponent<Canvas>();
        optionsMenu = optionsMenu.GetComponent<Canvas>();
        start = start.GetComponent<Button>();
        exit = exit.GetComponent<Button>();
        options = options.GetComponent<Button>();
        credits = credits.GetComponent<Button>();
        exitMenu.enabled = false;
        optionsMenu.enabled = false;

    }

    //exit button
    public void ExitPressed()
    {
        //enable exit menu
        //disable start menu 
        exitMenu.enabled = true;
        optionsMenu.enabled = false;
        start.enabled = false;
        exit.enabled = false;
        options.enabled = false;
        credits.enabled = false;
    }

    //No
    public void NoPressed()
    {
        //dissable quit menu
        //enable start menu
        exitMenu.enabled = false;
        optionsMenu.enabled = false;
        start.enabled = true;
        exit.enabled = true;
        options.enabled = true;
        credits.enabled = true;
    }

    //Start game
    public void StartLevel()
    {
        //loads scence one
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OptionsPressed()
    {
        exitMenu.enabled = false;
        optionsMenu.enabled = true;
        start.enabled = false;
        exit.enabled = false;
        options.enabled = false;
        credits.enabled = false;
    }
    // Update is called once per frame
    void Update ()
    {
		
	}
}
