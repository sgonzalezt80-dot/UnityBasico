using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float _enemyYSpeed;
    [SerializeField] private float _enemyXSpeed;
    private float _targetXPosition;
    private float _enemyWith;
    private Vector2 _screenBounds;
    private Collider2D _collider2D;

    [SerializeField] private GameObject _enemyBullet;
    private float _minTime = 0.5f;
    private float _maxTime = 1.5f;
    private float _shootTimer;

    private void Start()
    {
        //Tiempo Inicial
        _shootTimer = Random.Range(_minTime, _maxTime);

        //Limites de pantalla 
        Vector3 screenValues = new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z);
        _screenBounds = Camera.main.ScreenToWorldPoint(screenValues);

        //Tamaño del enemigo
        _collider2D = GetComponent<Collider2D>();
        _enemyWith = _collider2D.bounds.extents.x;

        //posicion inicial
        SetRandomPosition(); 
    }
    private void Update()
    {
        transform.Translate(Vector3.down * _enemyYSpeed * Time.deltaTime);

        Move(); 
        Shoot();
    }
    private void Move()
    {
        float speed = _enemyXSpeed * Time.deltaTime;
        float newXPosicion = Mathf.MoveTowards(transform.position.x, _targetXPosition, speed);
        transform.position = new Vector3(newXPosicion, transform.position.y, transform.position.z); 

        if(Mathf.Abs(transform.position.x  - _targetXPosition) < 0.1f)
        {
            SetRandomPosition(); 
        }
    }

    private void Shoot()
    {
        _shootTimer -= Time.deltaTime;

        if(_shootTimer <= 0)
        {
            Instantiate(_enemyBullet, transform.position, transform.rotation);
            _shootTimer = Random.Range(_minTime, _maxTime); 
        }
    }

    private void SetRandomPosition()
    {
        _targetXPosition = Random.Range(- _screenBounds.x + _enemyWith, _screenBounds.x - _enemyWith);
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
