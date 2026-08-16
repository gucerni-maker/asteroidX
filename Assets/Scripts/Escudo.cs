using UnityEngine;

public class Escudo : MonoBehaviour
{
    private float minSpeed = 0.5f;
    private float maxSpeed = 1.5f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("rocaChica") ||
            other.CompareTag("rocaMediana") ||
            other.CompareTag("rocaGrande"))
        {
            //Para hacer que las rocas reboten en el escudo
            float randomSpeed = Random.Range(minSpeed, maxSpeed);
            Rigidbody2D rocaRigidbody = other.gameObject.GetComponent<Rigidbody2D>();
            Vector3 alejaRoca = (other.gameObject.transform.position - transform.position);
            rocaRigidbody.linearVelocity = alejaRoca * randomSpeed;
        }
    }
}