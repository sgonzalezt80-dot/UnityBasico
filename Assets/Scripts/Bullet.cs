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
        if (collision.tag.Equals("Enemy") && !_collider.tag.Equals("Enemy"))
        {

            EnemyHealth health = collision.GetComponent<EnemyHealth>();
            if(health != null)
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
    }
}
