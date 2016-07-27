using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public int score;
	public GUIText scoreText;

	// Use this for initialization
	void Start () {
		score = 0;
		updateScore ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void addScore(int x){
		score += x;
		updateScore ();
	}

	void updateScore(){
		scoreText.text = "Score: " + score;
	}
		

}
