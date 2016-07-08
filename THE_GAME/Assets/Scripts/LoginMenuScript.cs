using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginMenuScript : MonoBehaviour {
    public Button signin;
    public Button guestLogin;
    public Button pwdReset;
    public Button register;
    public Button back;
    public Button quit;
    public Text username;
    public Text password;
    public Text status;
	// Use this for initialization
	void Start () {
        signin = signin.GetComponent<Button>();
        guestLogin = guestLogin.GetComponent<Button>();
        pwdReset = pwdReset.GetComponent<Button>();
        register = register.GetComponent<Button>();
        back = back.GetComponent<Button>();
        quit = quit.GetComponent<Button>();
        status = status.GetComponent<Text>();
	}
    public void signinPressed() { 
    
    }

    public void quitPressed() {
        Application.Quit();
    }
    public void exitPressed() {
        Application.Quit();
    }
    
    public void guestLoginPressed() {
        //continue without saving
        SceneManager.LoadScene(2);
    }

    public void pwdResetPressed() {
        //go to password reset page
    }

    public void registerPressed() {
        //go to registration page
        SceneManager.LoadScene(3);
    }

    public void backPressed() {
        SceneManager.LoadScene(0);
    }
	
}
