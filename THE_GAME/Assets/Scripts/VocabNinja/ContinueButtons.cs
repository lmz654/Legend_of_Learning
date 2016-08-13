using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ContinueButtons : MonoBehaviour {
    
    public Button contYes;
    public Button contNo;
    
    // Use this for initialization
    void Start () {
        contYes = contYes.GetComponent<Button>();
        contNo = contNo.GetComponent<Button>();
        
    }

    public void yesPressed()
    {
        SceneManager.LoadScene("VocabNinja");
    }

    public void noPressed()
    {
        SceneManager.LoadScene("GameSelect");
    }

}
