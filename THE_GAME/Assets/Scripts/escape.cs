using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class escape : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButton("Cancel"))
        {
            Cursor.visible = true;
            SceneManager.LoadScene(2);
            
        }
    }
}
