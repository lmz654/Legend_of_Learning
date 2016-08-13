using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    public int hazardCount;
    public GameObject ans;
    private int answer;
    private int[] multipleChoice;
    private float time;
    List<GameObject> tempBirds = new List<GameObject>();

    public Transform[] spawns;
    [SerializeField]
	public GameObject[] bird;
	public int level = 1;
	int rand;


	// Use this for initialization
	void Start () {
        SpawnWaves();
	}

    public void SpawnWaves()
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
                        tempBirds.Add(obj);
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
                        tempBirds.Add(obj2);
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
            }
    }

    public void answerGet(int x)
    {
        this.answer = x;
    }

    public void correctAnswer()
    {
        foreach(GameObject bird in tempBirds)
        {
            Destroy(bird);
        }
        tempBirds = new List<GameObject>();
        time = 0;
        SpawnWaves();
    }

	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (time > 7.2f)
        {
           time -= 7.2f;
           correctAnswer();
        }

    }

}
