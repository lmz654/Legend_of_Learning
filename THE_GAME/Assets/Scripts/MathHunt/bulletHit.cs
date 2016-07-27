using UnityEngine;
using System.Collections;

public class bulletHit : MonoBehaviour {

	// Use this for initialization
	void Awake () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		
		GameObject scoring = GameObject.Find("Score");

		Debug.Log (other.tag);
		Debug.Log (scoring.name);
		if (other.tag == "bird1") {
			scoring.SendMessageUpwards ("addScore", 10);
			//points.addScore (10);
		}
		if (other.tag == "bird2") {
			scoring.SendMessageUpwards ("addScore", 20);
			//points.addScore (20);
		}
		if (other.tag == "bird3") {
			scoring.SendMessageUpwards ("addScore", 30);
			//points.addScore (30);
		}
		if (other.tag == "bird4") {
			scoring.SendMessageUpwards ("addScore", 40);
			//points.addScore (40);
		}
		Destroy (other.gameObject);
		Destroy (gameObject);

	}

}
