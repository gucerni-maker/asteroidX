using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System.Collections;// requerido para usar IEnumerator

public class GameManager : MonoBehaviour
{
    public UIDocument uiDocument;
    public GameObject nave;
    private GameObject naveActual;

    private Button BotonStart;
    private Label scoreText, nivelText, vidasText;

    void Start()
    {
        //Pantalla de titulo
        if(SceneManager.GetActiveScene().buildIndex == 0){
            //Instanciamos los botones
            BotonStart = uiDocument.rootVisualElement.Q<Button>("Start");

            //asociamos los botones a su respectiva funcion
            BotonStart.clicked += iniciarJuego;

        }    
        
        //Al iniciar el juego en el nivel 1
        if(SceneManager.GetActiveScene().buildIndex > 0){
            //Instanciamos los labels
            scoreText = uiDocument.rootVisualElement.Q<Label>("puntos");
            nivelText = uiDocument.rootVisualElement.Q<Label>("nivel");
            vidasText = uiDocument.rootVisualElement.Q<Label>("vidas");

            //Obtenemos el puntaje del almacenamiento
            scoreText.text = "Puntaje " + DatosJuego.Instance.puntaje.ToString();

            //Obtenemos las vidas restantes del almacenamiento
            vidasText.text = "Vidas " + DatosJuego.Instance.vidas.ToString();

            //Obtenemos el nivel del almacenamiento
            nivelText.text = "Nivel " + DatosJuego.Instance.nivel.ToString();

            creaNave();
        }

    }

    
    void Update()
    {
        
    }

    public void iniciarJuego(){
        BotonStart.style.display = DisplayStyle.None;
        int escenaActual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(escenaActual + 1);
    }

    public GameObject creaNave(){
        Vector2 posicionNave = new Vector2(0f, -4f);
        GameObject nuevaNave = Instantiate(nave, posicionNave, Quaternion.identity);
        return nuevaNave;
    }

    public void AnotaPunto(){
        DatosJuego.Instance.puntaje+=10;
        scoreText.text = "Puntaje " + DatosJuego.Instance.puntaje.ToString();
        
        if(DatosJuego.Instance.puntaje % 150 == 0){
            darVida();
        }
    }

    public void RestaVida(){
        if (DatosJuego.Instance.vidas > 0){
            DatosJuego.Instance.vidas--;
            vidasText.text = "Vidas " + DatosJuego.Instance.vidas.ToString();
            StartCoroutine(EsperaElRespawn());
        }
        else{
            StartCoroutine(SinVidas());
        }
    }

    public void darVida(){
        DatosJuego.Instance.vidas++;
        vidasText.text = "Vidas " + DatosJuego.Instance.vidas.ToString();
    }

    //Espera un segundo antes de hacer el respawn de la nave
    IEnumerator EsperaElRespawn(){
        yield return new WaitForSeconds(1);
        GameObject nuevaNave = creaNave();
        PlayerMove player = nuevaNave.GetComponent<PlayerMove>();
        player.Invencibilidad();
    }

    IEnumerator SinVidas(){
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(2);//carga la pantalla de game over
    }

}
