using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginMenuScript : MonoBehaviour {
    public Button submit;
    public Button guestLogin;
    public Button pwdReset;
    public Button register;
    public Button back;
	// Use this for initialization
	void Start () {
        submit = submit.GetComponent<Button>();
        guestLogin = guestLogin.GetComponent<Button>();
        pwdReset = pwdReset.GetComponent<Button>();
        register = register.GetComponent<Button>();
        back = back.GetComponent<Button>();
	}

    public void submitPressed() {
        //do something with login info
        SceneManager.LoadScene(2);
    }

    public void guestLoginPressed() {
        //continue without saving
    }

    public void pwdResetPressed() {
        //go to password reset page
    }

    public void registerPressed() {
        //go to registration page
    }

    public void backPressed() {
        SceneManager.LoadScene(0);
    }
	
}
