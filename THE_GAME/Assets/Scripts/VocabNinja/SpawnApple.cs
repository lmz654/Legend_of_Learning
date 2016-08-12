using UnityEngine;
using System.Collections;

public class SpawnApple : MonoBehaviour {

    public float spawnTime = 1.5f;
    public GameObject applePrefab;
    public Sprite[] appleSprites;
    public Transform[] SpawnPoints;
    public GameObject words;
    public SpawnWord spawnWord;

    void Start()
    {
        words = GameObject.FindGameObjectWithTag("WordSpawn");
        spawnWord = words.GetComponent<SpawnWord>();
        InvokeRepeating("MakeRandomApple", spawnTime, spawnTime);
    }

    public void MakeRandomApple()
    {

        int arrayIdx = Random.Range(0, appleSprites.Length);
        int weightedRand = Random.Range(1, 100);
        Sprite appleSprite;
        if (weightedRand <= 40)
            appleSprite = appleSprites[arrayIdx];
        else
        {
            
            arrayIdx = Random.Range(0, spawnWord.letterIndexes.Count);
            Debug.Log("correct letters!!!!!!!!!!!!!" + spawnWord.letterIndexes.Count + " " + arrayIdx);
            appleSprite = appleSprites[(int)spawnWord.letterIndexes[arrayIdx]];
        }
            

        string appleName = appleSprite.name;

        int spawnIndex = Random.Range(0, SpawnPoints.Length);

        GameObject newApple = (GameObject)Instantiate(applePrefab, SpawnPoints [spawnIndex].position, Quaternion.identity);

        newApple.name = appleName;
        newApple.GetComponent<SpriteRenderer>().sprite = appleSprite;


    }

   

}
