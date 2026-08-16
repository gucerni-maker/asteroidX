using UnityEngine;

public class GemaMove : MonoBehaviour
{
    private float velocidad = 5f;
    private float limiteIzq = -8.2f;    
    private float limiteDer = 8.2f;
    
    void Update(){
        moverGema();
    }

    void moverGema(){
        if(transform.position.x < limiteIzq){
            velocidad = 5f;
        }
        if(transform.position.x > limiteDer){
            velocidad = -5f;
        }
        transform.Translate(Vector2.right * velocidad * Time.deltaTime);
    }
}
