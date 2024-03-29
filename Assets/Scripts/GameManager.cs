﻿using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameObject MonsterCamera;

    public static GameManager singleton;

    void Start ()
    {
        singleton = this;

	    if (SuperNetworkManager.isServer)
        {
            InitHost();
        }
        else
        {
            InitClient();
        }
        
	}

    void InitHost()
    {
        if (UnityEngine.VR.VRDevice.isPresent)
        {
            // UnityEngine.VR.VRSettings.enabled = true;
        }
    }

    void InitClient()   
    {
        // UnityEngine.VR.VRSettings.enabled = false;
        MonsterCamera.SetActive(true);
    }

    public void GameOver(bool childHasWon)
    {
        if (SuperNetworkManager.isServer)
        {
            if (childHasWon)
                UnityEngine.SceneManagement.SceneManager.LoadScene("End_PlayerWin");
            else
                UnityEngine.SceneManagement.SceneManager.LoadScene("End_PlayerLoose");
        }
        else
        {
            if (childHasWon)
                UnityEngine.SceneManagement.SceneManager.LoadScene("End_MonsterLoose");
            else
                UnityEngine.SceneManagement.SceneManager.LoadScene("End_MonsterWin");
        }
    }

    void OnDestroy()
    {
        // UnityEngine.VR.VRSettings.enabled = false;
    }
}
