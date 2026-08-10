using UnityEngine;

public class DatosJuego : MonoBehaviour
{
    public static DatosJuego Instance;
    public int puntaje = 0;
    public int vidas = 5;
    public int nivel = 1;

    //Para mantener los datos al pasar de nivel
    void Awake(){
        if (Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }
}
