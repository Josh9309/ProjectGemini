using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SettingsManager : MonoBehaviour
{
    public Toggle fullscreenToggle;
    public Dropdown resolutionDropdown;
    public Slider musicVolumeSlider;
    public Resolution[] resolutions;
    public GameSettings gameSettings;

    //testing sound
    public AudioSource musicSource;
    void OnEnable()
    {
        //initialize
        gameSettings = new GameSettings();
      

        //onvaluechange assigned to fullscreen toggle 
        fullscreenToggle.onValueChanged.AddListener(delegate 
        {
            OnFullScreenToggle();
        });
        resolutionDropdown.onValueChanged.AddListener(delegate 
        {
            OnResolutionChange();
        });
        musicVolumeSlider.onValueChanged.AddListener(delegate 
        {
            OnVolumeChange();
        });

        //to get diff resolutions
        resolutions = Screen.resolutions;
        foreach(Resolution resolution in resolutions)
        {
            resolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }
    }

    public void OnFullScreenToggle()
    {
        //assign the value of isOn to fullscreen
        gameSettings.fullscreen = Screen.fullScreen = Screen.fullScreen = fullscreenToggle.isOn;
    }

    public void OnResolutionChange()
    {
        //set the width and height and full screen gets inherited 
        Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, Screen.fullScreen) ;
    }   

    public void OnVolumeChange()
    {
        musicSource.volume =gameSettings.musicVolume = musicVolumeSlider.value;
    }

    public void SaveSettings()
    {

    }

    public void LoadSettings()
    {

    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
