using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RegisterUserScript : MonoBehaviour {
    public Button submit;
    public Button back;
    public Button quit;
    public Text username;
    public Text password;
    public Text confirmpass;
    public Text phonenumber;
    public Toggle sendtoemail;
    public Toggle sendtophone;
    // Use this for initialization
    void Start () {
        submit = submit.GetComponent<Button>();
        back = back.GetComponent<Button>();
        quit = quit.GetComponent<Button>();
        username = username.GetComponent<Text>();
        password = password.GetComponent<Text>();
        confirmpass = confirmpass.GetComponent<Text>();
        phonenumber = phonenumber.GetComponent<Text>();
        phonenumber.enabled = false;
        sendtoemail = sendtoemail.GetComponent<Toggle>();
        sendtoemail.isOn = true;
        sendtophone = sendtophone.GetComponent<Toggle>();
        sendtophone.isOn = false;

	}
    public void quitPressed() {
        Application.Quit();
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
    public void submitPressed() {
        //do something with user info
    }

    public void backPressed() {
        //go back to login
        SceneManager.LoadScene(1);
    }
	
	
}
