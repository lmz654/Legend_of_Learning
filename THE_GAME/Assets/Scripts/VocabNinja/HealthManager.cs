using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

    public Slider health;
    public Text gameOver;
    public int startingHealth = 100;
    public int currentHealth;
    public int damage = 10;
    public bool isDead;

    Animator anim;
    PlayerManager playerManager;
    GameObject apples;
    SpawnApple spawnApple;
    
	// Use this for initialization
	void Start () {
        isDead = false;
        currentHealth = startingHealth;
        gameOver = gameOver.GetComponent<Text>();
        gameOver.enabled = false;
        anim = GetComponent<Animator>();
        playerManager = GetComponent<PlayerManager>();
        apples = GameObject.FindGameObjectWithTag("AppleSpawns");
        spawnApple = apples.GetComponent<SpawnApple>();
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

    }

}
