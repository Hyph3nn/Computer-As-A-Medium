using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float destroyTime = 3f;
    public float bulletDamage = 5f;
    public Knockack knockback;
    public float knockbackForce;
    public EnemyMovement enemyMovement;
    public Enemy enemy;

    public Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.linearVelocity = transform.up * speed;
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemy.enemyHealth -= bulletDamage;

            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            
            if (rb != null)
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
                Vector2 difference = (rb.transform.position - other.transform.position).normalized;
                rb.AddForce(difference * knockbackForce, ForceMode2D.Impulse);knockback.ApplyKnockback((enemyMovement.transform.position - transform.position).normalized);
            }
            
        }
    }

}
