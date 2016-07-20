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
    public InputField remail;
    public Button request;
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
        remail = remail.GetComponent<InputField>();
        rpass = rpass.GetComponent<Canvas>();
        rpass.enabled = false;
        request = request.GetComponent<Button>();
        lstatus = lstatus.GetComponent<Text>();
        nstatus = nstatus.GetComponent<Text>();
        cancel = cancel.GetComponent<Button>();
	}
    public void cancelpress() {
        rpass.enabled = false;
    }
    public void requestpress() {
        try
        {
            switch(StartMenuScript.auth.forgetpass(remail.text.Trim())){
                case usermanager.finalvar.MISSING_FIELD:
                    nstatus.text = "Missing Field!";
                    break;
                case usermanager.finalvar.INVALID_EMAIL:
                    nstatus.text = "The email is invalid!";
                    break;
                case usermanager.finalvar.NOT_EXIST_EMAIL:
                    nstatus.text = "The email is not registered!";
                    break;
                case usermanager.finalvar.SUCCESS:
                    rpass.enabled = false;
                    break;
            }
        }
        catch (Exception ex) {
            if (ex.Message.Length < 50)
                nstatus.text = ex.Message;
            else
                nstatus.text = ex.Message.Substring(0, 45) + "...";
        }
        
    }
    public void showrequestnewpass() {
        rpass.enabled = true;
    }
    public void signinPressed() {
        try
        {
            switch (StartMenuScript.auth.login(email.text, password.text))
            {
                case usermanager.finalvar.WRONG:
                    lstatus.text = "Email/password is wrong";
                    break;
                case usermanager.finalvar.SUCCESS:
                    lstatus.text = "Login successful";
                    SceneManager.LoadScene(2);
                    break;
                case usermanager.finalvar.MISSING_FIELD:
                    lstatus.text = "Missing Field!";
                    break;
                case usermanager.finalvar.NEED_CODE:

                    lstatus.text = "Please confirm registration";

                    SceneManager.LoadScene("ConfirmRegistration");
                    break;
                case usermanager.finalvar.TEMP_CODE_LOGIN:
                    lstatus.text = "login with temporary password";
                    break;
                case usermanager.finalvar.USER_DEACTIVATE:
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
