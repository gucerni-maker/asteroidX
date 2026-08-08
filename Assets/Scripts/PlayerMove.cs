using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public float aceleracion = 5f;
    public float velocidadMaxima = 10f;
    public float velocidadRotacion = 200f;
    public GameObject explosionEffect;

    private Rigidbody2D rb;
    
    void Start()
    {
      rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Girar
        float rotacion = Input.GetAxis("Horizontal");
        transform.Rotate(0, 0, -rotacion * velocidadRotacion * Time.deltaTime);
    }

    void FixedUpdate()
    {
        // Acelerar hacia adelante
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.up * aceleracion);
        }

        // Limitar velocidad máxima
        if (rb.linearVelocity.magnitude > velocidadMaxima)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * velocidadMaxima;
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        Destroy(gameObject);
        Instantiate(explosionEffect, transform.position, transform.rotation);
    }

}
