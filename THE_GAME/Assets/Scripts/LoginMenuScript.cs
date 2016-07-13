using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using usermanager;
using System;

public class LoginMenuScript : MonoBehaviour {
    public Button signin;
    public Button guestLogin;
    public Button pwdReset;
    public Button register;
    public Button back;
    //public Button quit;
    public InputField email;
    public InputField password;
    public Text status;
	// Use this for initialization
	void Start () {
        signin = signin.GetComponent<Button>();
        guestLogin = guestLogin.GetComponent<Button>();
        pwdReset = pwdReset.GetComponent<Button>();
        register = register.GetComponent<Button>();
        back = back.GetComponent<Button>();
        email = email.GetComponent<InputField>();
        password = password.GetComponent<InputField>();
        //quit = quit.GetComponent<Button>();
        status = status.GetComponent<Text>();
	}
    public void signinPressed() {
        try
        {
            switch (StartMenuScript.auth.login(email.text, password.text))
            {
                case 0:
                    status.text = "Email/password is wrong";
                    break;
                case 1:
                    status.text = "Login successful";
                    SceneManager.LoadScene(2);
                    break;
                case 2:
                    status.text = "Missing Field!";
                    break;
                case 3:
                    SceneManager.LoadScene("ConfirmRegistration");
                    break;
                case 4:
                    status.text = "login with temporary password";
                    break;
                case 5:
                    status.text = "User deactivated";
                    break;

            }
        }catch(Exception ex){
            if (ex.Message.Length < 100)
                status.text = ex.Message;
            else
                status.text = ex.Message.Substring(0, 96) + "...";
        }
    }
    /*
     *public void quitPressed() {
     *   Application.Quit();
     *}
    */
    
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
