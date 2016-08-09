using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
    private int answer;

	public Transform[] spawns;
	[SerializeField]
	public GameObject[] bird;
	public float speed = 1.0f;
	public int level = 1;
	int rand;
	int count;
	public float speedx;


	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnWaves());
        
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				if (level == 1) {
					rand = Random.Range (0, 2);
					count = Random.Range (0, 2);
					if(spawns[count].position.x < 0){
						GameObject obj = Instantiate (bird [rand], spawns [count].position, spawns [count].rotation) as GameObject;
						obj.GetComponent<DeathByTime>().Initialize(Vector2.right);
                        obj.guiText.text = answer;
					}else{	
						var offset = spawns [count].rotation;
						offset.y = 180;
						GameObject obj2 = Instantiate (bird [rand], spawns [count].position, offset) as GameObject;
						obj2.GetComponent<DeathByTime>().Initialize(Vector2.left);
                        obj2.guiText.text = answer;

					}
				}
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}
		

    public void answerGet(int x)
    {
        this.answer = x;
    }

	// Update is called once per frame
	void Update () {

	}

}
