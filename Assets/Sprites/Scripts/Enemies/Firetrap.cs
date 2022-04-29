using System.Collections;
using UnityEngine;

public class Firetrap : MonoBehaviour
{
    [SerializeField] private float damage;
    [Header("Firetrap timers")]
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;
    private Animator anim;
    private SpriteRenderer spriteRend;

    [Header("Header")]
    [SerializeField] private AudioClip firetrapSound;

    private bool triggered; //Cuando la trampa es accionada
    private bool active;//Cuando la trampa esta activa y causa daño

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "player")
        {
            if (!triggered)
            {
                //trampa accionada
                StartCoroutine(ActivateFiretrap());
            }
        }   if (active)
            collision.GetComponent<Health>().TakeDamage(damage);
    }

    private IEnumerator ActivateFiretrap()
    {
        //Se notifica al jugador y se acciona la trampa
        triggered = true;
        spriteRend.color = Color.red;

        //Se espera el delay, activa la trampa, se apica la animacion, regresa al color normal

        yield return new WaitForSeconds(activationDelay);
        SoundManager.instance.PlaySound(firetrapSound);
        spriteRend.color = Color.white;
        active = true;
        anim.SetBool("activated", true); 

        //Se esperan x segundos para desactivacion de trampa y se resetea animacion
        yield return new WaitForSeconds(activeTime);
        active = false;
        triggered = false;
        anim.SetBool("activated", false);
    }
}
