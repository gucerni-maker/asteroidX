using UnityEngine;

public class Disparo : MonoBehaviour
{
    public float velocidad = 15f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.up * velocidad;
    }

    
    void Update()
    {
        
    }

    //Se destruye la bala ve si choca con una pared o roca
    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("roca") || collision.gameObject.CompareTag("pared")){
            Destroy(gameObject);
        }
    }
}
