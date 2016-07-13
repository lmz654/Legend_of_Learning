using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Threading;
using usermanager;

public class ConfirmRegistration : MonoBehaviour {
    public static string number;
    public static int op;
    public Canvas resendCanvas;
    public Button submit;
    public Button resendCode;
    public Button requestCode;
    public Button mainMenu;
    public Button cancel;
    public Toggle toEmail;
    public Toggle toPhone;
    public InputField phone;
    public InputField confCode;
    public Text rstatus;
    public Text cstatus;

	// Use this for initialization
	void Start () {
        resendCanvas = resendCanvas.GetComponent<Canvas>();
        submit = submit.GetComponent<Button>();
        resendCode = resendCode.GetComponent<Button>();
        requestCode = requestCode.GetComponent<Button>();
        cancel = cancel.GetComponent<Button>();
        toEmail = toEmail.GetComponent<Toggle>();
        toPhone = toPhone.GetComponent<Toggle>();
        phone = phone.GetComponent<InputField>();
        phone.enabled = false;
        rstatus = rstatus.GetComponent<Text>();
        cstatus = cstatus.GetComponent<Text>();
        confCode = confCode.GetComponent<InputField>();

        resendCanvas.enabled = false;
	
	}

    public void cancelpress(){
        resendCanvas.enabled=false;
    }
    public void tophonecheck() {
        if (toPhone.isOn == true)
        {
            phone.enabled= true;
        }
        else
        {
            phone.text = "";
            phone.enabled = false;
        }
    }

    public void submitPressed() {
        //submit conf code
        Debug.Log(confCode.text.Trim());
        Debug.Log(StartMenuScript.auth.getuser().user_confirm_code);
        try
        {
            switch (StartMenuScript.auth.codeconfirm(confCode.text.Trim()))
            {
                case 0:
                    cstatus.text = "Wrong code!";
                    break;
                case 1:
                    SceneManager.LoadScene(2);
                    break;
                case 2:
                    cstatus.text = "Please enter confirm code";
                    break;
            }
        }catch(Exception ex){
            if (ex.Message.Length < 100)
                cstatus.text = ex.Message;
            else
                cstatus.text = ex.Message.Substring(0, 96) + "...";
        }
        //SceneManager.LoadScene(2);
    }

    public void resendCodePressed()
    {
        //open resend conf code window
        resendCanvas.enabled = true;
        //submit.enabled = false;
        //resendCode.enabled = false;
        //mainMenu.enabled = false;
    }
    public static void sendrequest() {
        StartMenuScript.auth.requestcode(number, op);
    }
    public void requestCodePressed() {
        bool success = false;
        int sendop = 0;
        if (toEmail.isOn == true){
            sendop = 1;
            success = true;
        }
        if(toPhone.isOn == true){
            if (sendop == 0)
            {
                sendop = 2;
            }
            else {
                sendop = 3;
            }
            success = true;
        }

        if (success == false)
        {
            rstatus.text = "Missing receiving option!";
        }
        else {
            try
            {
                Thread t = new Thread(new ThreadStart(sendrequest));
                number = phone.text.Trim();
                op = sendop;
                t.Start();
            }
            catch (Exception ex) {
                if (ex.Message.Length < 100)
                    rstatus.text = ex.Message;
                else
                    rstatus.text = ex.Message.Substring(0, 96) + "...";
            }
            resendCanvas.enabled = false;
            //StartMenuScript.auth.requestcode(phone.text.Trim(), 2);
        }
       
        //resend confirmation code
        
        //submit.enabled = true;
        //resendCode.enabled = true;
        //mainMenu.enabled = true;

    }

    public void mainMenuPressed() {
        SceneManager.LoadScene(0);
    }

    
	
	
}
