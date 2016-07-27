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
    public Text lstatus;
    public InputField email;
    public InputField password;
    //forget pass
    public Canvas rpass;
    public InputField remail;
    public Button request; 
    public Text rstatus;
    public Button rcancel;
    //enter newpass
    public Canvas epass;
    public Button esubmit;
    public Text estatus;
    public Button ecancel;
    public InputField enewpass;
    public InputField ecnewpass;
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
        rstatus = rstatus.GetComponent<Text>();
        rcancel = rcancel.GetComponent<Button>();
        //enter new pass
        epass = epass.GetComponent<Canvas>();
        epass.enabled = false;
        esubmit = esubmit.GetComponent<Button>();
        estatus = estatus.GetComponent<Text>();
        ecancel = ecancel.GetComponent<Button>();
        enewpass = enewpass.GetComponent<InputField>();
        ecnewpass = ecnewpass.GetComponent<InputField>();
	}
    public void rcancelpress() {
        rpass.enabled = false;

    }
    public void requestpress() {
        try
        {
            switch(StartMenuScript.auth.forgetpass(remail.text.Trim())){
                case usermanager.finalvar.MISSING_FIELD:
                    rstatus.text = "Missing Field!";
                    break;
                case usermanager.finalvar.INVALID_EMAIL:

                    rstatus.text = "The email is invalid!";
                    break;
                case usermanager.finalvar.NOT_EXIST_EMAIL:
                    rstatus.text = "The email is not registered!";
                    break;
                case usermanager.finalvar.SUCCESS:
                    rpass.enabled = false;
                    break;
            }
        }
        catch (Exception ex) {
            if (ex.Message.Length < 50)
                rstatus.text = ex.Message;
            else
                rstatus.text = ex.Message.Substring(0, 45) + "...";
        }
        
    }
    public void ecancelpress() {
        epass.enabled = false;
    }
    public void esubmitpress() {
        try {
            if (enewpass.text.Trim().CompareTo(ecnewpass.text.Trim())==0)
            {
                switch (StartMenuScript.auth.enternewpass(enewpass.text.Trim()))
                {
                    case finalvar.MISSING_FIELD:
                        estatus.text= "Missing Field!";
                        break;
                    case finalvar.SUCCESS:
                        estatus.text = "Changing password success!";
                        epass.enabled = false;
                        break;
                }
            }
            else
            {
                estatus.text = "Password and confirm password isn't match!";
            }
        }catch(Exception ex){
            if (ex.Message.Length < 50)
                estatus.text = ex.Message;
            else
                estatus.text = ex.Message.Substring(0, 45) + "...";
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
                    epass.enabled = true;
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
