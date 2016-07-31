using UnityEngine;
using System.Collections;

public class attackTrigger : MonoBehaviour {

    public bool dmg;
    public string name;

    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.isTrigger != true && col.CompareTag("Apple"))
        {
            dmg = true;
            name = col.gameObject.name;
            Debug.Log("The name is " + name);
   

            SpawnWord.SlicedLetter(name);


            col.SendMessageUpwards("Slice", dmg);
        }
    }

}
