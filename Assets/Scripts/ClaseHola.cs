using UnityEngine;

public class ClaseHola : MonoBehaviour
{
    [Header("jugador")]
    [SerializeField] private int velocidad;
    private Rigidbody2D rb2d; 

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //transform.position += new Vector3(1, 0, 0) * Time.deltaTime;  

        rb2d.linearVelocity = new Vector3(1, 0, 0); 
    }

}