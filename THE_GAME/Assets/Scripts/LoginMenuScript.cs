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
    public Canvas rpass;
    public InputField email;
    public InputField password;
    public Button submit;
    public Text lstatus;
    public Text nstatus;
    public Button cancel;
	// Use this for initialization
	void Start () {
        signin = signin.GetComponent<Button>();
        guestLogin = guestLogin.GetComponent<Button>();
        pwdReset = pwdReset.GetComponent<Button>();
        register = register.GetComponent<Button>();
        back = back.GetComponent<Button>();
        email = email.GetComponent<InputField>();
        password = password.GetComponent<InputField>();
        rpass = rpass.GetComponent<Canvas>();
        rpass.enabled = false;
        submit = submit.GetComponent<Button>();
        lstatus = lstatus.GetComponent<Text>();
        nstatus = nstatus.GetComponent<Text>();
        cancel = cancel.GetComponent<Button>();
	}
    public void cancelpress() {
        rpass.enabled = false;
    }
    public void submitpress() {
        rpass.enabled = false;
    }
    public void showrequestnewpass() {
        rpass.enabled = true;
    }
    public void signinPressed() {
        try
        {
            switch (StartMenuScript.auth.login(email.text, password.text))
            {
                case 0:
                    lstatus.text = "Email/password is wrong";
                    break;
                case 1:
                    lstatus.text = "Login successful";
                    SceneManager.LoadScene(2);
                    break;
                case 2:
                    lstatus.text = "Missing Field!";
                    break;
                case 3:

                    lstatus.text = "Please confirm registration";

                    SceneManager.LoadScene("ConfirmRegistration");
                    break;
                case 4:
                    lstatus.text = "login with temporary password";
                    break;
                case 5:
                    lstatus.text = "User deactivated";
                    break;

            }
        }catch(Exception ex){
            if (ex.Message.Length < 100)
                lstatus.text = ex.Message;
            else
                lstatus.text = ex.Message.Substring(0, 96) + "...";
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
        rpass.enabled = true;
    }

    public void registerPressed() {
        //go to registration page
        SceneManager.LoadScene(3);
    }

    public void backPressed() {
        SceneManager.LoadScene(0);
    }
	
}
