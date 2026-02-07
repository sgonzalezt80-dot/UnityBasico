using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyLeftAI : MonoBehaviour
{
    [SerializeField] private float _enemyYSpeed;

    [SerializeField] private GameObject _enemyBullet;
    private float _minTime = 0.5f;
    private float _maxTime = 1.5f;
    private float _shootTimer;

    private void Start()
    {
        //Tiempo Inicial
        _shootTimer = Random.Range(_minTime, _maxTime);

        //Tamaño del enemigo
        //_collider2D = GetComponent<Collider2D>();
        //_enemyWith = _collider2D.bounds.extents.x;

    }

    private void Update()
    {
        transform.Translate(Vector3.down * _enemyYSpeed * Time.deltaTime);
        Shoot();
    }

    private void Shoot()
    {
        _shootTimer -= Time.deltaTime;

        if (_shootTimer <= 0)
        {
            Instantiate(_enemyBullet, transform.position, transform.rotation);
            _shootTimer = Random.Range(_minTime, _maxTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Border"))
        {
            Destroy(this.gameObject);
        }

        if (collision.tag.Equals("Player"))
        {
            HealthController health = collision.GetComponent<HealthController>();
            if (health != null)
            {
                health.PlayerDamage();
            }
        }
    }
}
