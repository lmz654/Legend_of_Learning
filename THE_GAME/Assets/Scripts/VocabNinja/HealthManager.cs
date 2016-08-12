using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour {

    public Slider health;
    public Text gameOver;
    public Text cont;
    
    public int startingHealth = 100;
    public int currentHealth;
    public int damage = 10;
    public bool isDead;

    Animator anim;
    PlayerManager playerManager;
    GameObject apples;
    GameObject words;
    SpawnApple spawnApple;
    SpawnWord spawnWord;
    
	// Use this for initialization
	void Start () {
        isDead = false;
        
        currentHealth = startingHealth;
        gameOver = gameOver.GetComponent<Text>();
        gameOver.enabled = false;
        cont.enabled = false;
        
        anim = GetComponent<Animator>();
        playerManager = GetComponent<PlayerManager>();
        apples = GameObject.FindGameObjectWithTag("AppleSpawns");
        words = GameObject.FindGameObjectWithTag("WordSpawn");
        spawnApple = apples.GetComponent<SpawnApple>();
        spawnWord = words.GetComponent<SpawnWord>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void takeDamage() {
        currentHealth -= damage;
        health.value = currentHealth;
        if (currentHealth <= 0 && !isDead)
            death();
    }

    void death() {
        isDead = true;
        anim.SetTrigger("dead");
        playerManager.stopMoving();
        playerManager.enabled = false;
        spawnApple.CancelInvoke("MakeRandomApple");
        gameOver.enabled = true;
        cont.enabled = true;
        

        foreach (GameObject g in spawnWord.missingList) {
            g.SetActive(false);
            Debug.Log("reaveal letters");
        }
            

    }

    

}
