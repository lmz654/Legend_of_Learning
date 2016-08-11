using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
    public GameObject ans;
    private int answer;
    private int[] multipleChoice;

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

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            List<Transform> freeSpawnPoints = new List<Transform>(spawns);
            for (int i = 0; i < hazardCount; i++)
            {
                if (level == 1)
                {
                    int index = Random.Range(0, freeSpawnPoints.Count);
                    Debug.Log(answer);
                    Transform pos = freeSpawnPoints[index];
                    freeSpawnPoints.RemoveAt(index);
                    rand = Random.Range(0, 2);
                    if (pos.position.x < 0)
                    {
                        GameObject obj = Instantiate(bird[rand], pos.position, pos.rotation) as GameObject;
                        obj.GetComponent<DeathByTime>().Initialize(Vector2.right);
                        GameObject hello = Instantiate(ans, pos.position, pos.rotation) as GameObject;
                        hello.transform.parent = obj.transform;
                        hello.transform.localScale = obj.transform.localScale;
                        MeshRenderer layerText = hello.GetComponent<MeshRenderer>();
                        hello.GetComponent<TextMesh>().text = "Hello";
                        layerText.sortingOrder = 1;
                    }
                    else
                    {
                        var offset = pos.rotation;
                        offset.y = 180;
                        GameObject obj2 = Instantiate(bird[rand], pos.position, offset) as GameObject;
                        obj2.GetComponent<DeathByTime>().Initialize(Vector2.left);
                        GameObject hello2 = Instantiate(ans, pos.position, pos.rotation) as GameObject;
                        hello2.transform.parent = obj2.transform;
                        hello2.transform.localScale = obj2.transform.localScale;
                        MeshRenderer layerText2 = hello2.GetComponent<MeshRenderer>();
                        layerText2.sortingOrder = 1;
                    }
                }
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
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
