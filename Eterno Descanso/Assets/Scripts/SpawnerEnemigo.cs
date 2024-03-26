using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemigo : MonoBehaviour
{

    [SerializeField] EnemyBehaviour[] ListaEnemigos;
    private int rondaActual;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawningEnemies()
    {
        int random = UnityEngine.Random.Range(0, ListaEnemigos.Length);

        Instantiate(ListaEnemigos[random], transform);
    }
}
