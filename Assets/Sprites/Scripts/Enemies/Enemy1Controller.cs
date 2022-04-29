using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Enemy1Controller : MonoBehaviour
{
    public int speed;
    private bool moveRight;
    private bool iscrushed;
    public Animator animator;
    private PlayerMovement Player;
    // Update is called once per frame
    void Start()
    {
        Player = FindObjectOfType<PlayerMovement>();
    }
    void Update()
    {
        if (moveRight)
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
        }
        else
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Player.hit = true;
            iscrushed = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            animator.SetBool("isCrush", iscrushed);
            speed = 0;
            
            Invoke("dead", 1);
        }

        if (collision.gameObject.CompareTag("Muro") || collision.gameObject.CompareTag("enemy"))
        {
            if (moveRight)
            {
                this.transform.localScale = new Vector2(this.transform.localScale.x * -1, this.transform.localScale.y);
                moveRight = false;
            }
            else
            {
                this.transform.localScale = new Vector2(this.transform.localScale.x * -1, this.transform.localScale.y);
                moveRight = true;
            }
        }
    }
    private void dead()
    {
        Destroy(gameObject);
    }
       
}
