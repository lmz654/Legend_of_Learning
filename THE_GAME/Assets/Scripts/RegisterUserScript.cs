﻿using UnityEngine;
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
    public Text phonenumber;
    public Text status;
    public Toggle sendtoemail;
    public Toggle sendtophone;
    public Canvas cv;
    public Text proc;
    // Use this for initialization
    void Start () {
        submit = submit.GetComponent<Button>();
        back = back.GetComponent<Button>();
        //quit = quit.GetComponent<Button>();
        status = status.GetComponent<Text>();
        status.text = "Enter info!";
        email = email.GetComponent<InputField>();
        password = password.GetComponent<InputField>();
        confirmpass = confirmpass.GetComponent<InputField>();
        phonenumber = phonenumber.GetComponent<Text>();
        phonenumber.enabled = false;
        sendtoemail = sendtoemail.GetComponent<Toggle>();
        sendtoemail.isOn = true;
        sendtophone = sendtophone.GetComponent<Toggle>();
        sendtophone.isOn = false;
        number = "";
        cv = cv.GetComponent<Canvas>();  
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
            Debug.Log(number);
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
            status.text = "Send confirming code missing!";
        } else if (sendtoemail.isOn == false && sendtophone.isOn == false) {
            status.text = "Select method for receiving confirmation code";

        }else if(password.text.CompareTo(confirmpass.text)==0){
            try
            {
                switch (StartMenuScript.auth.register(emails, passwords))
                {
                    case 1:
                       
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
                                    result+= "Cannot send confirm code to email. ";
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
                                result+= "cannot send confirm code to phone ";
                            }
                        break;
                    case 2:
                        status.text = "Missing field";
                        break;
                    case 3:
                        status.text = "Invalid email";
                        break;
                    case 4:
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
