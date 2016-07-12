using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using usermanager;

public class StartMenuScript : MonoBehaviour {
    public static Authenticator auth= new Authenticator();
    public Canvas quitMenu;
    public Button play;
    public Button settings;
    public Button quit;
    public Button quitYes;
    public Button quitNo;
	// Use this for initialization
	void Start () {
        quitMenu = quitMenu.GetComponent<Canvas>();
        play = play.GetComponent<Button>();
        settings = settings.GetComponent<Button>();
        quit = quit.GetComponent<Button>();
        quitMenu.enabled = false;
	}

    //start menu methods

    public void playPressed() {
        SceneManager.LoadScene(1);
    }

    public void settingsPressed() {
        //go to settings
    }

    public void quitPressed() {
        play.enabled = false;
        settings.enabled = false;
        quit.enabled = false;
        quitMenu.enabled = true;
    }

    //quit menu methods

    public void yesPressed() {
        Application.Quit();
    }

    public void noPressed() {
        play.enabled = true;
        settings.enabled = true;
        quit.enabled = true;
        quitMenu.enabled = false;
    }


	
	
}
