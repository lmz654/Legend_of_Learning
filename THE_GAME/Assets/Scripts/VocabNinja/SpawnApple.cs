using UnityEngine;
using System.Collections;

public class SpawnApple : MonoBehaviour {

    public float spawnTime = 1.5f;
    public GameObject applePrefab;
    public Sprite[] appleSprites;
    public Transform[] SpawnPoints;

    void Start()
    {
        InvokeRepeating("MakeRandomApple", spawnTime, spawnTime);
    }

    public void MakeRandomApple()
    {

        int arrayIdx = Random.Range(0, appleSprites.Length);
        Sprite appleSprite = appleSprites[arrayIdx];
        string appleName = appleSprite.name;

        int spawnIndex = Random.Range(0, SpawnPoints.Length);

        GameObject newApple = (GameObject)Instantiate(applePrefab, SpawnPoints [spawnIndex].position, Quaternion.identity);

        newApple.name = appleName;
        newApple.GetComponent<SpriteRenderer>().sprite = appleSprite;


    }

   

}
