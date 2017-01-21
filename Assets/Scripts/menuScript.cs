using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour
{
    
    public Canvas exitMenu;
    public Canvas optionsMenu;
    //play
    public Button start;
    public Button exit;
    public Button options;
    public Button credits;
    public Button apply;
    public Button no;
    public Button yes;
    public Toggle fullscreen;
    public Dropdown resolution;
    public Slider audio;
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
        apply = apply.GetComponent<Button>();
        no = no.GetComponent<Button>();
        yes = yes.GetComponent<Button>();
        fullscreen = fullscreen.GetComponent<Toggle>();
        resolution = resolution.GetComponent<Dropdown>();
        audio = audio.GetComponent<Slider>();

        exitMenu.enabled = false;
        optionsMenu.enabled = false;
        no.enabled = false;
        yes.enabled = false;
        apply.enabled = false;
        no.enabled = false;
        yes.enabled = false;
        fullscreen.enabled = false;
        resolution.enabled = false;
        audio.enabled = false;
    }

    //exit button
    public void ExitPressed()
    {
        //enable exit menu
        //disable start menu 
        GetComponent<Canvas>().enabled = false;
        exitMenu.enabled = true;
        optionsMenu.enabled = false;
        start.enabled = false;
        exit.enabled = false;
        options.enabled = false;
        credits.enabled = false;
        apply.enabled = false;
        no.enabled = false;
        yes.enabled = false;
        fullscreen.enabled = false;
        resolution.enabled = false;
        audio.enabled = false;
    }

    //No
    public void NoPressed()
    {
        //dissable quit menu
        //enable start menu
        GetComponent<Canvas>().enabled = true;
        exitMenu.enabled = false;
        optionsMenu.enabled = false;
        start.enabled = true;
        exit.enabled = true;
        options.enabled = true;
        credits.enabled = true;
        no.enabled = false;
        yes.enabled = false;
        fullscreen.enabled = false;
        resolution.enabled = false;
        audio.enabled = false;
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
        GetComponent<Canvas>().enabled = false;

        exitMenu.enabled = false;
        optionsMenu.enabled = true;
        start.enabled = false;
        exit.enabled = false;
        options.enabled = false;
        credits.enabled = false;
        no.enabled = false;
        yes.enabled = false;
        resolution.enabled = true;
        fullscreen.enabled = true;
        audio.enabled = true;
        apply.enabled = true;
    }

    public void ApplyPressed()
    {
        GetComponent<Canvas>().enabled = true;
        exitMenu.enabled = false;
        optionsMenu.enabled = false;
        start.enabled = true;
        exit.enabled = true;
        options.enabled = true;
        credits.enabled = true;
       
        no.enabled = false;
        yes.enabled = false;
        fullscreen.enabled = false;
        resolution.enabled = false;
        audio.enabled = false;
    }

}

   
    // Update is called once per frame
  

