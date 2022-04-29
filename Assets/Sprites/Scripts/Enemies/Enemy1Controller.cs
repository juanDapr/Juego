using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Enemy1Controller : MonoBehaviour
{
    
    private bool iscrushed;
    public Animator animator;
    private PlayerMovement Player;
    private Enemy1Controller Ene;
    // Update is called once per frame
    void Start()
    {
        Player = FindObjectOfType<PlayerMovement>();
        Ene = FindObjectOfType<Enemy1Controller>();
    }
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Player.hit = true;
            iscrushed = true;
            Ene.enabled= false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            animator.SetBool("die", iscrushed);
           
            
            Invoke("dead", 1);
        }

      
    }
    private void dead()
    {
        Destroy(gameObject);
    }
       
}
