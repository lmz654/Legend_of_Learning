using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConfirmRegistration : MonoBehaviour {

    public Canvas resendCanvas;
    public Button submit;
    public Button resendCode;
    public Button requestCode;
    public Button mainMenu;
    public Toggle toEmail;
    public Toggle toPhone;
    public InputField email;
    public InputField phone;
    public InputField confCode;

	// Use this for initialization
	void Start () {
        resendCanvas = resendCanvas.GetComponent<Canvas>();
        submit = submit.GetComponent<Button>();
        resendCode = resendCode.GetComponent<Button>();
        requestCode = requestCode.GetComponent<Button>();
        toEmail = toEmail.GetComponent<Toggle>();
        toPhone = toPhone.GetComponent<Toggle>();
        email = email.GetComponent<InputField>();
        phone = phone.GetComponent<InputField>();
        confCode = confCode.GetComponent<InputField>();

        resendCanvas.enabled = false;
	
	}

    public void submitPressed() {
        //submit conf code
        SceneManager.LoadScene(2);
    }

    public void resendCodePressed()
    {
        //open resend conf code window
        resendCanvas.enabled = true;
        submit.enabled = false;
        resendCode.enabled = false;
        mainMenu.enabled = false;
    }

    public void requestCodePressed() {
        //resend confirmation code
        resendCanvas.enabled = false;
        submit.enabled = true;
        resendCode.enabled = true;
        mainMenu.enabled = true;
    }

    public void mainMenuPressed() {
        SceneManager.LoadScene(0);
    }

    
	
	
}
