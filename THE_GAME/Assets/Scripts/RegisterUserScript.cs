using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using usermanager;
using System;
using EASendMail;
using System.Threading;


public class RegisterUserScript : MonoBehaviour {
    public static string number;
    public static Canvas cvv;
    public Button submit;
    public Button back;
    public Button quit;
    public InputField email;
    public InputField password;
    public InputField confirmpass;
    public InputField phonenumber;
    public Text status;
    public Toggle sendtoemail;
    public Toggle sendtophone;
    // Use this for initialization
    void Start () {
        submit = submit.GetComponent<Button>();
        back = back.GetComponent<Button>();
        //quit = quit.GetComponent<Button>();
        status = status.GetComponent<Text>();
        //status.text = "Enter info!";
        email = email.GetComponent<InputField>();
        password = password.GetComponent<InputField>();
        confirmpass = confirmpass.GetComponent<InputField>();
        phonenumber = phonenumber.GetComponent<InputField>();
        phonenumber.enabled = false;
        sendtoemail = sendtoemail.GetComponent<Toggle>();
        sendtoemail.isOn = true;
        sendtophone = sendtophone.GetComponent<Toggle>();
        sendtophone.isOn = false;
        number = "";
	}
    public void quitPressed() {
        //Application.Quit();
    }
    public void sendtophonechange() {
        if (sendtophone.isOn == true)
        {
            phonenumber.enabled = true;
        }
        else {
            phonenumber.text = "";
            phonenumber.enabled = false;
        }
    }
    static void sendcodetophone() {
        try
        {
             StartMenuScript.auth.sendccodetophone(number,null);
        }catch(Exception ex){
            throw ex;
        }
    }
    
    public void submitPressed() {
        //do something with user info
        string emails = email.text.Trim();
        string passwords = password.text.Trim();

        if (sendtoemail.isOn == false && sendtophone.isOn == false) {
            status.text = "Select method for receiving confirmation code";

        }else if(password.text.CompareTo(confirmpass.text)==0){
            try
            {
                switch (StartMenuScript.auth.register(emails, passwords))
                {
                    case usermanager.finalvar.SUCCESS:
                       
                            string result="";
                            status.text = "Enter Info";
                            try
                            {
                                try {
                                    User us = StartMenuScript.auth.getuser();
                                    if (sendtoemail.isOn == true)
                                    {
                                        StartMenuScript.auth.sendccodetoemail(null, null);
                                    }
                                }catch(Exception ex){
                                    result+= "Cannot send confirmation code to email. ";
                                }
                                number = phonenumber.text.Trim();
                                if(sendtophone.isOn==true){
                                    if (!string.IsNullOrEmpty(number))
                                    {
                                        number = phonenumber.text.Trim();
                                        Thread t = new Thread(new ThreadStart(sendcodetophone));
                                        t.Start();
                                    }
                                }
                                SceneManager.LoadScene("ConfirmRegistration");
                            }catch(Exception ex){
                                result+= "cannot send confirmation code to phone ";
                            }
                        break;
                    case usermanager.finalvar.MISSING_FIELD:
                        status.text = "Missing field";
                        break;
                    case usermanager.finalvar.INVALID_EMAIL:
                        status.text = "Invalid email";
                        break;
                    case usermanager.finalvar.EXIST_EMAIL:
                        status.text = "This email is already registered";
                        break;
                }
            }
            catch(Exception ex) {
                if (ex.Message.Length < 100)
                    status.text = ex.Message;
                else
                    status.text = ex.Message.Substring(0, 96) + "...";
            }
        }else{
            status.text = "Confirm password do not match to password!";
        }
    }

    public void backPressed() {
        //go back to main menu
        SceneManager.LoadScene(0);
    }
	
	
}
