using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public float aceleracion = 5f;
    public float velocidadMaxima = 10f;
    public float velocidadRotacion = 200f;
    public GameObject explosionEffect;
    public GameObject balaPrefab;
    public Transform puntoDisparo;
    
    private Rigidbody2D rb;
    
    void Start(){
      rb = GetComponent<Rigidbody2D>();
    }

    void Update(){
        // Gira la nave
        float rotacion = Input.GetAxis("Horizontal");
        transform.Rotate(0, 0, -rotacion * velocidadRotacion * Time.deltaTime);

        //llama a la funcion para disparar
        if(Input.GetKeyDown(KeyCode.Space)){
            Disparar();
        }
    }

    void FixedUpdate(){
        // Acelerar hacia adelante
        if (Input.GetKey(KeyCode.W)){
            rb.AddForce(transform.up * aceleracion);
        }

        // Limitar velocidad máxima
        if (rb.linearVelocity.magnitude > velocidadMaxima){
            rb.linearVelocity = rb.linearVelocity.normalized * velocidadMaxima;
        }
    }

    //Se destruye la nave si choca con una roca
    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("roca")){
            Destroy(gameObject);
            Instantiate(explosionEffect, transform.position, transform.rotation);
        }
    }

    //genera el disparo
    void Disparar(){
        Instantiate(balaPrefab, puntoDisparo.position, transform.rotation);
    }

}
