using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorMenu : MonoBehaviour
{
    //[SerializeField] private GameObject m_Player; //The player for the inspector
    //[SerializeField] private GameObject m_Enemy; //The enemy for the inspector
    ////private MeshFilter playerModel; //The player's model
    //private Renderer playerTextureRenderer; //The player's texture renderer
    ////private MeshFilter enemyModel; //The enemy's Model
    //private Renderer enemyTextureRenderer; //The enemy's texture renderer

    //[SerializeField] private Material playerMaterial; //The player's material
    //[SerializeField] private Material enemyMaterial; //The enemy's material

    [SerializeField] private Renderer playerTextureRenderer; //The player's texture renderer
    [SerializeField] private Renderer enemyTextureRenderer; //The enemy's texture renderer

    //[SerializeField] private Texture playerTexture; //The player's texture
    //[SerializeField] private Texture enemyTexture; //The enemy's texture

    void Start() //Use this for initialization
    {
        //playerModel = m_Player.GetComponent<MeshFilter>(); //Get the player's model
        //playerTextureRenderer = m_Player.GetComponent<Renderer>(); //Get the player's texture renderer
        //enemyModel = m_Enemy.GetComponent<MeshFilter>(); //Get the enemy's model
        //enemyTextureRenderer = m_Enemy.GetComponent<Renderer>(); //Get the enemy's texture renderer

        enemyTextureRenderer.material.SetFloat("_Mode", 0.0f); //Change the rendering mode of the enemy
	}
	
	void Update() //Update is called once per frame
    {
		
	}
}