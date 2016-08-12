using UnityEngine;
using System.Collections;

public class QuestionText : MonoBehaviour {

    private int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    public GUIText questText;
    private int answer;


    void Awake()
    {
        
    }

	// Use this for initialization
	void Start () {
        updateQuestion();
    }
	
	// Update is called once per frame
	void Update() { 
	}


    public void updateQuestion()
    {
        int rand1 = Random.Range(0, 10);
        int rand2 = Random.Range(0, 10);
        answer = numbers[rand1] * numbers[rand2];
        questText.text = numbers[rand1] + " * " + numbers[rand2] + " =";
        GameObject birdy = GameObject.Find("BulletSpawn");
        GameObject controller = GameObject.Find("GameController");
        controller.SendMessageUpwards("answerGet", answer);
        birdy.SendMessageUpwards("getAnswer", answer);
    }

}
