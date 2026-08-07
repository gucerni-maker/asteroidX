using UnityEngine;

public class EnemigoMove : MonoBehaviour
{
    private float minSpeed = 1f;
    private float maxSpeed = 3f;
    //private float velocidad = 5f;

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
}
