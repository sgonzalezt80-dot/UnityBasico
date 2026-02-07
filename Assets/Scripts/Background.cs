using Unity.VisualScripting;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private float _VBgSpeed;
    [SerializeField] private float _HBgSpeed;

    private Vector2 _offSet;
   
    private Material _material;

    private void Start()
    {
        _material = GetComponent<SpriteRenderer>().material;
    }

    private void Update()
    {
        _offSet = new Vector2(_HBgSpeed, _VBgSpeed *  Time.deltaTime);
        _material.mainTextureOffset += _offSet; 
        
        if(_material.mainTextureOffset.y >= 1)
        {
            _material.mainTextureOffset = new Vector2(0, 0); 
        }





    }
}
