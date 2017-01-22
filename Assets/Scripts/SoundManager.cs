using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioSource efxSource;
    public AudioSource enemySource;
    public AudioSource musicSource;
    public AudioSource pingSource;
    public AudioSource wobbleSource;
    public static SoundManager instance = null;
    public float lowPitchRange = .95f;
    public float highPitchRange = 1.05f;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }


    public void PlaySingle(AudioClip clip)
    {
        efxSource.clip = clip;
        enemySource.clip = clip;
        pingSource.clip = clip;
        wobbleSource.clip = clip;

        efxSource.Play();
        enemySource.Play();
        pingSource.Play();
        wobbleSource.Play();
    }

    public void RandomizeSfx(params AudioClip[] clips)
    {
        //Generate a random number between 0 and the length of our array of clips passed in.
        int randomIndex = Random.Range(0, clips.Length);

        //Choose a random pitch to play back our clip at between our high and low pitch ranges.
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);

        //Set the pitch of the audio source to the randomly chosen pitch.
        efxSource.pitch = randomPitch;
       

        //Set the clip to the clip at our randomly chosen index.
        efxSource.clip = clips[randomIndex];
       
        //Play the clip.
        efxSource.Play();
        
    }

    public void RandomizeEnemySfx(params AudioClip[] clips)
    {
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);
        enemySource.pitch = randomPitch;
        int randomIndex = Random.Range(0, clips.Length);
        enemySource.clip = clips[randomIndex];
        enemySource.Play();
    }

    public void RandomizePingSfx(params AudioClip[] clips)
    {
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);
        pingSource.pitch = randomPitch;
        int randomIndex = Random.Range(0, clips.Length);
        pingSource.clip = clips[randomIndex];
        pingSource.Play();
    }
    public void RandomizeWobbleSfx(params AudioClip[] clips)
    {
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);
        wobbleSource.pitch = randomPitch;
        int randomIndex = Random.Range(0, clips.Length);
        wobbleSource.clip = clips[randomIndex];
        wobbleSource.Play();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
