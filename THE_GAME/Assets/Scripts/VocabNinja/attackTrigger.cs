using UnityEngine;
using System.Collections;

public class attackTrigger : MonoBehaviour {

    public bool dmg;
    public string name;
    public GameObject wordSpawn;
    public SpawnWord spawnWord;
    public AudioSource[] sliceSound;
    public int magnitude;

    void Start() {
        wordSpawn = GameObject.FindGameObjectWithTag("WordSpawn");
        spawnWord = wordSpawn.GetComponent<SpawnWord>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.isTrigger != true && col.CompareTag("Apple"))
        {
            int soundIdx = Random.Range(0, sliceSound.Length);
            AudioSource selected_sound = sliceSound[soundIdx];
            selected_sound.Play();
            dmg = true;
            name = col.gameObject.name;
            Debug.Log("The name is " + name);

            spawnWord.CorrectLetter(name);

            col.SendMessageUpwards("Slice", dmg);

            //make apple fly up
            
            var force = transform.position - col.transform.position;
            force = -force;
            force.Normalize();
            col.GetComponent<Rigidbody2D>().AddForce(force * magnitude);
        }
    }

}
