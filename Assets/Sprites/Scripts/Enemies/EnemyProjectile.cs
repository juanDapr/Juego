
using UnityEngine;

public class EnemyProjectile : EnemyDamage //Hara da�o al jugador  
{
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    private float lifetime;
    public void ActivateProjectile()
    {
        lifetime = 0;
        gameObject.SetActive(true);
    }
    private void Update()
    {
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > resetTime)
            gameObject.SetActive(false);
    }
    private new void OnTriggerEnter2D(Collider2D collision) 
    {
        base.OnTriggerEnter2D(collision);
        gameObject.SetActive(false);
    }
}
