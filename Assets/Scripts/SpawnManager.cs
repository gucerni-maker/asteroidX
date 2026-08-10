using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    public GameObject rocaChica;
    public GameObject rocaMediana;
    public GameObject rocaGrande;
    private float rangoX = 6f;
    private float rangoY = 3f;

    void Start()
    {     
        SpawnRocaChica();
        SpawnRocaMediana();
        SpawnRocaGrande();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //Nivel 1 Roca Grande: 2, Roca Mediana: 2, Roca Chica: 4
    //Nivel 2 Roca Grande: 2, Roca Mediana: 6, Roca Chica: 0
    //Nivel 3 Roca Grande: 8, Roca Mediana: 0, Roca Chica: 0

    void SpawnRocaChica(){
        for(int a = 0; a < 4; a++){
            Vector3 spawnPosRocaChica = new Vector3(Random.Range(-rangoX, rangoX), Random.Range(0f, rangoY), 0); 
            Instantiate(rocaChica, spawnPosRocaChica, rocaChica.transform.rotation);    
        }       
    }

    void SpawnRocaMediana(){
        for(int b = 0; b < 2; b++){
            Vector3 spawnPosRocaMediana = new Vector3(Random.Range(-rangoX, rangoX),Random.Range(0f, rangoY), 0); 
            Instantiate(rocaMediana, spawnPosRocaMediana, rocaMediana.transform.rotation);
        }
    }

    void SpawnRocaGrande(){
        for(int c = 0; c < 2; c++){
            Vector3 spawnPosRocaGrande = new Vector3(Random.Range(-rangoX, rangoX),Random.Range(0f, rangoY), 0); 
            Instantiate(rocaGrande, spawnPosRocaGrande, rocaGrande.transform.rotation);
        }
    }
}
