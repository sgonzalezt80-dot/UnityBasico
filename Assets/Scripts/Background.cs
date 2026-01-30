using Unity.VisualScripting;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private float _bgSpeed;
    private Vector2 _offSet; 

    private Material _material;

    private void Start()
    {
        _material = GetComponent<SpriteRenderer>().material;
    }

    private void Update()
    {
        _offSet = new Vector2(0, _bgSpeed *  Time.deltaTime);
        _material.mainTextureOffset += _offSet; 

        if(_material.mainTextureOffset.y >= 0)
        {
            _material.mainTextureOffset = new Vector2(0, 0); 
        }
    }
}
