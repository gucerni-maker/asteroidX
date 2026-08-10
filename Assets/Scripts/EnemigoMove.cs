using UnityEngine;

public class EnemigoMove : MonoBehaviour
{
    private float minSpeed = 0.5f;
    private float maxSpeed = 1.5f;
    public GameObject explosionEffect;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        moverRoca();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void moverRoca(){
        float randomSpeed = Random.Range(minSpeed, maxSpeed);
        float[] angulos ={15f,30f,45f,60f, 75f, 90f, 105f,120f,135f,150f, 165f, 180f, 195f, 210f, 225f,240f,255f,270f,285f,300f,315f,330f,345f};
        float angulo = angulos[Random.Range(0, angulos.Length)];
        float rad = angulo * Mathf.Deg2Rad;
        Vector2 direccion = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
        rb.linearVelocity = direccion * randomSpeed;
    }

    //Se destruye la roca si colisiona con una bala
    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("bala")){
            
            //Nos comunicamos con el gameManager
            GameManager gm = FindFirstObjectByType<GameManager>();

            //Le decimos al gameManager que anote un punto
            gm.AnotaPunto();

            Destroy(gameObject);
            Instantiate(explosionEffect, transform.position, transform.rotation);
        }
    }
}
