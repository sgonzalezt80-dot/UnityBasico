using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _bulletDamage;
    private float _currentHealth;

    private Animator _animator; 

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _currentHealth = _health;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    public void TakeDamage()
    {
        _currentHealth -= _bulletDamage;

        StartCoroutine(DamageFlash());

        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void PlayerDamage()
    {
        _currentHealth -= _bulletDamage;

        StartCoroutine(DamageFlash());

        if (_currentHealth <= 0)
        {
            _animator.SetBool("IsDead", true);

            new WaitForSeconds(1);
            
            Destroy(gameObject);

            SceneManager.LoadScene("Menu"); 
        }
    }

    private IEnumerator DamageFlash()
    {
        // Color originalColor = _spriteRenderer.color;
        _spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(0.1f);

        _spriteRenderer.color = Color.white;
    }
    // Color originalColor = _spriteRenderer.color;
    //_spriteRenderer.color = Color.withe
}
