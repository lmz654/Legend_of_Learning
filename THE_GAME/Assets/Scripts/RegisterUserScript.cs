using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RegisterUserScript : MonoBehaviour {
    public Button submit;
    public Button back;
    // Use this for initialization
    void Start () {
        submit = submit.GetComponent<Button>();
        back = back.GetComponent<Button>();
	}

    public void submitPressed() {
        //do something with user info
    }

    public void backPressed() {
        //go back to login
        SceneManager.LoadScene(1);
    }
	
	
}
