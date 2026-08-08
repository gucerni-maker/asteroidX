using UnityEngine;

public class Disparo : MonoBehaviour
{
    public float velocidad = 15f;
    public GameObject rocaChica;
    public GameObject rocaMediana;
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
        if (collision.gameObject.CompareTag("rocaChica") || collision.gameObject.CompareTag("pared")){
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("rocaMediana")){
            Destroy(gameObject);
            Instantiate(rocaChica, transform.position, transform.rotation);
            Instantiate(rocaChica, transform.position, transform.rotation);
        }
        if (collision.gameObject.CompareTag("rocaGrande")){
            Destroy(gameObject);
            Instantiate(rocaMediana, transform.position, transform.rotation);
            Instantiate(rocaMediana, transform.position, transform.rotation);
        }
    }
}
