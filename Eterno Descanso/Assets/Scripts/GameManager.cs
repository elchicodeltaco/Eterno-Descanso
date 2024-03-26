using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int cantidadEnemigos;
    [SerializeField] SpawnerEnemigo[] spawners;
    [SerializeField] float DistanciaEnemigoSpawnerMinima;
    private GameObject player;
    private int numeroDeRonda = 10;
    
    private void Awake()
    {
        if (GameManager.Instance == null)
        {
            GameManager.Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        player = GameObject.FindGameObjectWithTag("Jugador");
        cantidadEnemigos = GameObject.FindGameObjectsWithTag("Enemigo").Length;
    }

    public void MurioEnemigo()
    {
        cantidadEnemigos--;
        if (cantidadEnemigos <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        UsarSpawn();

    }

    private void UsarSpawn()
    {
        int random = UnityEngine.Random.Range(0, spawners.Length);

        if ((player.transform.position - spawners[random].transform.position).magnitude >= DistanciaEnemigoSpawnerMinima)
        {
            spawners[random].SpawningEnemies();

        }
        else UsarSpawn();
    }
    public int GetNumeroDeRonda()
    {
        return numeroDeRonda;
    }
}