using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public UIDocument uiDocument;
    private Button BotonStart;

    void Start()
    {
        BotonStart = uiDocument.rootVisualElement.Q<Button>("Start");

        BotonStart.clicked += iniciarJuego;

    }

    
    void Update()
    {
        
    }

    public void iniciarJuego(){
        BotonStart.style.display = DisplayStyle.None;
        int escenaActual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(escenaActual + 1);
        Debug.Log("boton presionado");
        Debug.Log("Escena actual: " + SceneManager.GetActiveScene().buildIndex);
    }
}
