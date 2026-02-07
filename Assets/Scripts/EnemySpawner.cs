using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;

    [SerializeField] private GameObject _enemyLeft; 
    [SerializeField] private GameObject _enemyRight;

    [SerializeField] private float _spawnTime;
    private BoxCollider2D _boxColider;
    private float _spawnTimer;

    private void Start()
    {
        _boxColider = GetComponent<BoxCollider2D>();
        _spawnTimer = _spawnTime; 
    }

    private void Update()
    {
        _spawnTimer -= Time.deltaTime;

        if (_spawnTimer <= 0)
        {
            SpawnEnemy();
            _spawnTimer = _spawnTime; 
        }
    }
    private void SpawnEnemy()
    {
        Vector2 randomPosition = GetPosition();
        Vector2 left = EnemyLeft(); 
        Vector2 right = EnemyRight();
        Instantiate(_enemy, randomPosition, Quaternion.identity);
        Instantiate(_enemyLeft, left, Quaternion.identity); 
        Instantiate(_enemyRight, right, Quaternion.identity);
    }

    private Vector2 GetPosition()
    {
        Bounds bounds = _boxColider.bounds;

        float randomX = Random.Range(bounds.min.x, bounds.max.x);  
        float randomY = Random.Range(bounds.min.y, bounds.max.y);
        return new Vector2(randomX, randomY);
    }

    private Vector2 EnemyLeft() 
    {
        Bounds bounds = _boxColider.bounds;
        float x = bounds.min.x;
        float y = bounds.min.y; 
        return new Vector2(x, y);
    }

    private Vector2 EnemyRight() 
    {
        Bounds bounds = _boxColider.bounds;
        float x = bounds.max.x;
        float y = bounds.min.y;
        return new Vector2(x, y);
    }
}
