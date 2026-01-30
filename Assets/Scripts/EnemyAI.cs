using UnityEngine;
using UnityEngine.Android;

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




    }
    private void Update()
    {
        transform.Translate(Vector3.down * _enemyYSpeed * Time.deltaTime);

        Shoot();
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



    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.tag.Equals("Border"))
        {
            Destroy(this.gameObject);
        }
    }
}
