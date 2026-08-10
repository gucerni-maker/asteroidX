using UnityEngine;
using UnityEngine.SceneManagement;//requerido para usar SceneManager
using UnityEngine.UIElements;//requerido para usar la interfaz UI

public class GameOver : MonoBehaviour
{
    public UIDocument uiDocument;
    private Button restartButton;
     

    void Start()
    {
        restartButton = uiDocument.rootVisualElement.Q<Button>("reiniciar");
        restartButton.clicked += ReiniciarJuego;
    }

    void ReiniciarJuego(){
        DatosJuego.Instance.puntaje = 0;
        DatosJuego.Instance.vidas = 5;
        DatosJuego.Instance.nivel = 1;
        SceneManager.LoadScene(0);
    }
}
