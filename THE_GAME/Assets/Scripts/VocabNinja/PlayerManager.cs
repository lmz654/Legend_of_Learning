using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{

    public float speedX;
    public float jumpPower = 150f;
    public Collider2D attackTrigger;

    [SerializeField]
    private GameObject knifePrefab;

    public AudioSource swordSound;

    bool facingRight, Jumping, canJump;
    float speed;

    Animator anim;
    Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        facingRight = true;
        attackTrigger.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {

        //player movement
        MovePlayer(speed);
        Flip();

        /*
         * Putting the exit function here
         */

        if (Input.GetButton("Cancel"))
        {
            SceneManager.LoadScene(2);
        }

        // left player movement
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            speed = -speedX;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            speed = 0;
        }


        // right player movement
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            speed = speedX;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            speed = 0;
        }

        // Sword attack action
        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetInteger("State", 2);
            attackTrigger.enabled = true;
            swordSound.Play();
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetInteger("State", 0);
            attackTrigger.enabled = false;
        }

        //Throw action
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetInteger("State", 3);
            ThrowKnife(0);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetInteger("State", 0);
        }


        //Jumping

        if (Input.GetKeyDown(KeyCode.Q) && canJump)
        {
            canJump = false;
            anim.SetInteger("State", 4);
            rb.AddForce(Vector2.up * jumpPower);
        }
    }

    void Flip()
    {
        //code to flip the player direction
        if (speed > 0 && !facingRight || speed < 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector3 temp = transform.localScale;
            temp.x *= -1;
            transform.localScale = temp;

        }
    }

    void MovePlayer(float playerSpeed)
    {
        // code for player movement

        rb.velocity = new Vector3(speed, rb.velocity.y, 0);
        if (playerSpeed < 0 || playerSpeed > 0)
        {
            anim.SetInteger("State", 1);
        }

        if (playerSpeed == 0)
        {
            anim.SetInteger("State", 0);
        }
    }

    public void ThrowKnife(int value)
    {
        if (facingRight)
        {
            GameObject tmp = (GameObject)Instantiate(knifePrefab, transform.position, Quaternion.identity);
            tmp.GetComponent<knife>().Initialize(Vector2.right, speedX);
        }
        else
        {
            GameObject tmp = (GameObject)Instantiate(knifePrefab, transform.position, Quaternion.identity);
            tmp.GetComponent<knife>().Initialize(Vector2.left, speedX);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Ground")
        {
            canJump = true;

        }
    }
}
