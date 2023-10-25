using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed = 20;
    public Rigidbody2D rb;
    public SpriteRenderer sp;
    private bool isOnGround;

    public static float max_bomb_number;
    public static float bomb_number;
    public bool bomb_available = true;

    public ThrowableBehaviour projectilePrefab;
    public Transform launchOffset;

    // Start is called before the first frame update
    void Start()
    {
        max_bomb_number = 5;
        bomb_number = max_bomb_number;
        rb.freezeRotation = true;
        //To consider: not having collisions with bombs
        Physics2D.IgnoreLayerCollision(6, 7); //Layer 6 is the Player and 7 the Bomb
        transform.position = new Vector3(-17.61f, -2.51f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.X))
        {
            if (bomb_number > 0 && bomb_number<max_bomb_number+1) {
                bomb_number--;
                Instantiate(projectilePrefab, launchOffset.position, transform.rotation);
                StartCoroutine(waiter());
            } else 
            {
                bomb_available = false;
            }
        }
    }

    void Movement()
    {
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            //Debug.Log("go left");
            rb.AddForce(Vector2.left * speed );
            //Character will look left
            sp.flipX = false;
        }
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            //Debug.Log("go right");
            rb.AddForce(Vector2.right * speed);
            //Character will look right
            sp.flipX = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            rb.AddForce(Vector2.up * (speed - 5), ForceMode2D.Impulse);
        }
        if (Input.GetAxisRaw("Vertical") == -1)
        {
            rb.AddForce(Vector2.down * speed);
        }
    }

    /* Detect collisions between the player and every object with the layer ground so the player only will be able to jump when
    touching the ground */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        { 
            isOnGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isOnGround = false;
        }
    }

    IEnumerator waiter()
    {
        //cooldown d'une bombe
        yield return new WaitForSecondsRealtime(BombCooldown.cooldownTime);
        bomb_number++;
    }

}
