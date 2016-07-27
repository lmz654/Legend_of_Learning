using UnityEngine;
using System.Collections;

public class attackTrigger : MonoBehaviour {

    public bool dmg;
    public string namess;

    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.isTrigger != true && col.CompareTag("Apple"))
        {
            dmg = true;
         //   namess = col.gameObject.name;

           // GameObject go = GameObject.Find(namess);
           // Debug.Log("the official name is " + go);
          //  SpawnWord spawnWord = go.GetComponent<SpawnWord>();
           // Debug.Log("dfsdfsfsdffsfsdfdsfsdf " + spawnWord);
          ///  spawnWord.CorrectLetter(namess);


            col.SendMessageUpwards("Slice", dmg);
        }
    }

}
