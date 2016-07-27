using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour {

	public Transform[] spawns;
	public GameObject[] bird;
	public float speed = 1.0f;
	public int level = 1;
	int rand;
	int count;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("spawnBird", 2f, 2f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void spawnBird(){

		if (level == 1) {
			rand = Random.Range (0, 2);
			count = Random.Range (0, 2);
			if(spawns[count].position.x < 0){
				GameObject obj = (GameObject)Instantiate (bird [rand], spawns[count].position, spawns[count].rotation);
			}else{
				var offset = spawns [count].rotation;
				offset.y = 180;
				GameObject obj2 = (GameObject)Instantiate (bird [rand], spawns [count].position, offset);
			}

		} if (level == 2) {
			rand = Random.Range (0, 2);

		}

	}


}
