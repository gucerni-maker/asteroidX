using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    public GameObject rocaChica;
    public GameObject rocaMediana;
    public GameObject rocaGrande;

    //roca chica
    private Vector3 spawnPos1 = new Vector3(-2.4f,  2.4f, 0);
    private Vector3 spawnPos2 = new Vector3( 2.4f,  2.4f, 0);
    private Vector3 spawnPos3 = new Vector3( 2.4f, -2.4f, 0);
    private Vector3 spawnPos4 = new Vector3(-2.4f, -2.4f, 0);

    //roca mediana
    private Vector3 spawnPos5 = new Vector3(-6f,  3f, 0);
    private Vector3 spawnPos6 = new Vector3( 6f, -3f, 0);     

    //roca grande
    private Vector3 spawnPos7 = new Vector3(-6f, -3f, 0); 
    private Vector3 spawnPos8 = new Vector3( 6f,  3f, 0); 

    void Start()
    {
        SpawnRocas();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRocas(){

        //Nivel 1 Roca Grande: 2, Roca Mediana: 2, Roca Chica: 4
            
            //Roca chica
            Instantiate(rocaChica, spawnPos1, rocaChica.transform.rotation);
            Instantiate(rocaChica, spawnPos2, rocaChica.transform.rotation);
            Instantiate(rocaChica, spawnPos3, rocaChica.transform.rotation);
            Instantiate(rocaChica, spawnPos4, rocaChica.transform.rotation);    

            //Roca mediana
            Instantiate(rocaMediana, spawnPos5, rocaMediana.transform.rotation);
            Instantiate(rocaMediana, spawnPos6, rocaMediana.transform.rotation);

            //Roca grande
            Instantiate(rocaGrande, spawnPos7, rocaGrande.transform.rotation);
            Instantiate(rocaGrande, spawnPos8, rocaGrande.transform.rotation);


        //Nivel 2 Roca Grande: 2, Roca Mediana: 6, Roca Chica: 0

        //Nivel 3 Roca Grande: 8, Roca Mediana: 0, Roca Chica: 0

    }
}
