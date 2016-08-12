using UnityEngine;
using System.Collections;

public class attackTrigger : MonoBehaviour {

    public bool dmg;
    public string name;
    public GameObject wordSpawn;
    public SpawnWord spawnWord;

    void Start() {
        wordSpawn = GameObject.FindGameObjectWithTag("WordSpawn");
        spawnWord = wordSpawn.GetComponent<SpawnWord>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.isTrigger != true && col.CompareTag("Apple"))
        {
            dmg = true;
            name = col.gameObject.name;
            Debug.Log("The name is " + name);

            spawnWord.CorrectLetter(name);

            col.SendMessageUpwards("Slice", dmg);
        }
    }

}
