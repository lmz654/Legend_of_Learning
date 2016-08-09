using UnityEngine;
using System.Collections;

public class QuestionText : MonoBehaviour {

    private int[] numbers;
    public GUIText questText;
    private int answer;


    void Awake()
    {
        int rand1 = Random.Range(0, 10);
        int rand2 = Random.Range(0, 10);
        answer = numbers[rand1] * numbers[rand2];

        GameObject birdy = GameObject.Find("BulletSpawn");
        GameObject controller = GameObject.Find("GameController");
        controller.SendMessageUpwards("answerGet", answer);
        birdy.SendMessageUpwards("getAnswer", answer);
    }

	// Use this for initialization
	void Start () {
        numbers[0] = 1;
        numbers[1] = 2;
        numbers[2] = 3;
        numbers[3] = 4;
        numbers[4] = 5;
        numbers[5] = 6;
        numbers[6] = 7;
        numbers[7] = 8;
        numbers[8] = 9;
        numbers[9] = 10;
    }
	
	// Update is called once per frame
	void Update() { 


	}


}
