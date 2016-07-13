﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSelectScript : MonoBehaviour {
    public Button histGame;
    public Button mathGame;
    public Button vocabNinja;
    public Button logout;

    // Use this for initialization
    void Start () {
        vocabNinja = histGame.GetComponent<Button>();
        mathGame = mathGame.GetComponent<Button>();
        vocabNinja = vocabNinja.GetComponent<Button>();
        logout = logout.GetComponent<Button>();
	}

    public void histPressed() {
        //history game selected
    }

    public void mathPressed() {
        //math game selected
    }

    public void ninjaPressed() {
        SceneManager.LoadScene(4);
    }

    public void logoutPressed() {
        //logout button pressed
        StartMenuScript.auth = new usermanager.Authenticator();
        SceneManager.LoadScene(1);
    }
	
	
}
