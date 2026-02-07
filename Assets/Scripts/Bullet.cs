using Unity.Hierarchy;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    private Collider2D _collider;

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
    }
    private void Update()
    {
        transform.position += Vector3.up * _bulletSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Enemy") && !_collider.tag.Equals("EnemyBullet"))
        {
            HealthController health = collision.GetComponent<HealthController>();
            if (health != null)
            {
                health.TakeDamage();
            }

            Destroy(this.gameObject);
        }
        if (collision.CompareTag("Bullet"))
        {
            Destroy(this.gameObject);
        }

        if (collision.tag.Equals("Border"))
        {
            Destroy(this.gameObject);
        }

        if (collision.CompareTag("EnemyBullet"))
        {
            Destroy(this.gameObject);
        }


        if (collision.CompareTag("Player") && !_collider.tag.Equals("Bullet"))
        {
            HealthController health = collision.GetComponent<HealthController>();
            if (health != null)
            {
                health.PlayerDamage();
            }
        }
    }
}
