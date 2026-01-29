using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
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
        Instantiate(_enemy, randomPosition, Quaternion.identity);
    }

    private Vector2 GetPosition()
    {
        Bounds bounds = _boxColider.bounds;

        float randomX = bounds.min.x;
        float randomY = bounds.min.y;  
        return new Vector2(randomX, randomY);
    }
}
