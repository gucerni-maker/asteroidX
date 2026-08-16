using UnityEngine;
using System.Collections;

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

    //Se destruye la bala si choca con una pared o roca
    /*Pasos para saber cuantas rocas quedan:
    Paso 1: En este script, nos comunicamos con el game manager usando gm.ComprobarRocasDespues
    Paso 2: El metodo ComprobarRocasDespues, ejecuta el IEnumerator EsperarYComprobarRocas
    Paso 3: El IEnumerator espera un momento y ejecuta el metodo ComprobarRocas
    Paso 4: El metodo ComprobarRocas cuenta las rocas restantes
    */
    void OnCollisionEnter2D(Collision2D collision){
        GameManager gm = FindFirstObjectByType<GameManager>();

        if (collision.gameObject.CompareTag("rocaChica")){
            Destroy(gameObject);
            gm.ComprobarRocasDespues();
        }
        if (collision.gameObject.CompareTag("rocaMediana")){
            Destroy(gameObject);
            Instantiate(rocaChica, transform.position, transform.rotation);
            Instantiate(rocaChica, transform.position, transform.rotation);
            gm.ComprobarRocasDespues();
        }
        if (collision.gameObject.CompareTag("rocaGrande")){
            Destroy(gameObject);
            Instantiate(rocaMediana, transform.position, transform.rotation);
            Instantiate(rocaMediana, transform.position, transform.rotation);
            gm.ComprobarRocasDespues();
        }

        if (collision.gameObject.CompareTag("pared")){
            Destroy(gameObject);
        }   
    }   
}
