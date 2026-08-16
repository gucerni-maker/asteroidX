using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
    public float aceleracion = 5f;
    public float velocidadMaxima = 10f;
    public float velocidadRotacion = 200f;
    public GameObject explosionEffect;
    public GameObject balaPrefab;
    public GameObject balaPrefab3;
    public Transform puntoDisparo;
    public Transform puntoDisparo2;
    public Transform puntoDisparo3;
    public bool tieneGemaGun = false;
    public GameObject aroFuerza;
    private GameObject escudoActual;

    private Collider2D colision;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    public AudioClip sonidoBala;
    private AudioSource playerAudio;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
        colision = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void Start(){
        playerAudio = GetComponent<AudioSource>();
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
        if (collision.gameObject.CompareTag("rocaChica") ||
            collision.gameObject.CompareTag("rocaMediana") ||
            collision.gameObject.CompareTag("rocaGrande") ||
            collision.gameObject.CompareTag("pared")){

                GameManager gm = FindFirstObjectByType<GameManager>();
                gm.RestaVida();
                Instantiate(explosionEffect, transform.position, transform.rotation);
                Destroy(gameObject);
        }
    }

    //genera el disparo
    void Disparar(){
        playerAudio.PlayOneShot(sonidoBala, 1.0f);
        
        if(tieneGemaGun){
            Instantiate(balaPrefab, puntoDisparo.position, transform.rotation);
            Instantiate(balaPrefab, puntoDisparo2.position, transform.rotation);
            Instantiate(balaPrefab, puntoDisparo3.position, transform.rotation);
        }
        else{
            Instantiate(balaPrefab, puntoDisparo.position, transform.rotation);
        }
    }

    public void Invencibilidad(){
        StartCoroutine(InvencibilidadCoroutine());
    }

    IEnumerator InvencibilidadCoroutine(){
        colision.enabled = false;

        for (int i = 0; i < 6; i++){
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(0.25f);

            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.25f);
        }

        colision.enabled = true;
    }

    //Controla los powerup
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("gemaEscudo")){
            escudoActual = Instantiate(aroFuerza, transform);
            escudoActual.transform.localPosition = Vector3.zero;
            escudoActual.transform.localRotation = Quaternion.identity;
            Destroy(other.gameObject);
            StartCoroutine(DestruyeEscudo());
            
        }
        if(other.CompareTag("gemaGun")){
            tieneGemaGun = true;
            StartCoroutine(BalaNormal());
            Destroy(other.gameObject);
        }
    } 

    //Destruye el escudo (powerup)
    IEnumerator DestruyeEscudo(){
        yield return new WaitForSeconds(15f);
        Destroy(escudoActual);
    } 

    //vuelve a la bala normal (powerup)
        IEnumerator BalaNormal(){
        yield return new WaitForSeconds(10f);
        tieneGemaGun = false;
    } 
}
