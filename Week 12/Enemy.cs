using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemyHealth = 100f;
    public float swordDamage = 10f;
    public float knockbackForce = 5f;
    Bullet bullet;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Death();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Sword"))
        {
            enemyHealth -= swordDamage;
        }
        if (other.CompareTag("Bullet"))
        {
            enemyHealth -= bullet.bulletDamage;
        }
    }

    void Death()
    {
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
