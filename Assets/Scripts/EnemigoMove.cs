using UnityEngine;

public class EnemigoMove : MonoBehaviour
{
    private float minSpeed = 1f;
    private float maxSpeed = 3f;
    public GameObject explosionEffect;

    Rigidbody2D rb;

    void Start()
    {
        // float randomSpeed = Random.Range(minSpeed, maxSpeed);
        rb = GetComponent<Rigidbody2D>();

        moverRoca();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void moverRoca(){
        float randomSpeed = Random.Range(minSpeed, maxSpeed);
        float[] angulos ={30f,45f,60f,120f,135f,150f};
        float angulo = angulos[Random.Range(0, angulos.Length)];
        float rad = angulo * Mathf.Deg2Rad;
        Vector2 direccion = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
        rb.linearVelocity = direccion * randomSpeed;
    }

    //Se destruye la roca si choca con una bala
    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("bala")){
            Destroy(gameObject);
            Instantiate(explosionEffect, transform.position, transform.rotation);
        }
    }
}
