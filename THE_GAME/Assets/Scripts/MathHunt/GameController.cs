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
            List<int> multiple = new List<int>();

            while (multiple.Count < hazardCount-1)
            {
                int random1 = Random.Range(0, 10);
                int random2 = Random.Range(0, 10);
                int multiAnswer = random1 * random2;

                while (multiAnswer == answer || multiple.Contains(multiAnswer))
                {
                    random1 = Random.Range(0, 10);
                    random2 = Random.Range(0, 10);
                    multiAnswer = random1 * random2;
                }
                multiple.Add(multiAnswer);
            }
            multiple.Add(answer);
            for (int i = 0; i < hazardCount; i++)
            {
                if (level == 1)
                {
                    int index = Random.Range(0, freeSpawnPoints.Count);
                    Transform pos = freeSpawnPoints[index];
                    freeSpawnPoints.RemoveAt(index);
                    rand = Random.Range(0, 1);

                    int indexAnswer = Random.Range(0, multiple.Count);
                    int possibleAnswer = multiple[indexAnswer];
                    multiple.RemoveAt(indexAnswer);


                    if (pos.position.x < 0)
                    {
                        GameObject obj = Instantiate(bird[rand], pos.position, pos.rotation) as GameObject;
                        obj.GetComponent<DeathByTime>().Initialize(Vector2.right);
                        obj.gameObject.name = possibleAnswer.ToString();

                        GameObject hello = Instantiate(ans, pos.position, pos.rotation) as GameObject;
                        hello.transform.parent = obj.transform;
                        hello.transform.localScale = obj.transform.localScale;
                        MeshRenderer layerText = hello.GetComponent<MeshRenderer>();
                        hello.GetComponent<TextMesh>().text = possibleAnswer.ToString();
                        layerText.sortingOrder = 1;
                    }
                    else
                    {
                        var offset = pos.rotation;
                        offset.y = 180;
                        GameObject obj2 = Instantiate(bird[rand], pos.position, offset) as GameObject;
                        obj2.GetComponent<DeathByTime>().Initialize(Vector2.left);
                        obj2.gameObject.name = possibleAnswer.ToString();

                        GameObject hello2 = Instantiate(ans, pos.position, pos.rotation) as GameObject;
                        hello2.transform.parent = obj2.transform;
                        hello2.transform.localScale = obj2.transform.localScale;
                        MeshRenderer layerText2 = hello2.GetComponent<MeshRenderer>();
                        hello2.GetComponent<TextMesh>().text = possibleAnswer.ToString();
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
