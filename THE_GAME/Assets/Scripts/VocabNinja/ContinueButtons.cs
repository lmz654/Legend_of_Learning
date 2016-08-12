using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ContinueButtons : MonoBehaviour {
    public GameObject yes;
    public GameObject no;
    public Button contYes;
    public Button contNo;
    // Use this for initialization
    void Start () {
        contYes = contYes.GetComponent<Button>();
        contNo = contNo.GetComponent<Button>();
        yes.SetActive(false);
        no.SetActive(false);
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
