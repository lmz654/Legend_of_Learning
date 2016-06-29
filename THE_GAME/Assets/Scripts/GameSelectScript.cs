using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSelectScript : MonoBehaviour {
    public Button histGame;
    public Button mathGame;
    public Button chemGame;
    public Button logout;

    // Use this for initialization
    void Start () {
        histGame = histGame.GetComponent<Button>();
        mathGame = mathGame.GetComponent<Button>();
        chemGame = chemGame.GetComponent<Button>();
        logout = logout.GetComponent<Button>();
	}

    public void histPressed() {
        //history game selected
    }

    public void mathPressed() {
        //math game selected
    }

    public void chemPressed() {
        //chemistry game selected
    }

    public void logoutPressed() {
        //logout button pressed
        SceneManager.LoadScene(1);
    }
	
	
}
