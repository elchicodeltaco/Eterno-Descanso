using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBehaviour : MonoBehaviour
{

    [SerializeField] HealthBar healthBar;
    public float vidaMaxima;
    public float vidaActual;
    public float enemySpeed= 3f;
    public float checkDistance = 2f;
    public float checkPlayerDistance;
    public Vector2 direction;
    protected GameObject Jugador;
    public Transform Muzzle;
    private int numeroRonda;
    [SerializeField] float aumentoPorRonda;

    [Range(0, 360)]
    public float visionAngle;
    public float visionDistance;

    public bool detected = false;


    // Start is called before the first frame update
    protected void Start()
    {
        numeroRonda = GameManager.Instance.GetNumeroDeRonda();

        vidaMaxima = Mathf.RoundToInt(vidaMaxima * (1f + aumentoPorRonda * numeroRonda));

        vidaActual = vidaMaxima;

        healthBar.UpdateHealthBar(vidaMaxima, vidaActual);
        Jugador = GameObject.FindGameObjectWithTag("Jugador");
    }
    // Update is called once per frame
    protected void Update()
    {
        detected = false;
        Vector2 playerVector = Jugador.transform.position - Muzzle.position;
        if (Vector2.Angle(playerVector.normalized, Muzzle.up) < visionAngle * 0.5f)
        {
            if (playerVector.magnitude < visionDistance)
            {
                // Realizar un raycast hacia el jugador
                RaycastHit2D hit = Physics2D.Raycast(Muzzle.position, playerVector.normalized, visionDistance);
                if (hit.collider != null && hit.collider.CompareTag("Jugador"))
                {                    
                    // Aquí puedes agregar cualquier lógica adicional cuando el jugador sea detectado
                    detected = true;
                }
                Debug.Log(hit.collider.gameObject);

                Debug.DrawRay(Muzzle.position, playerVector.normalized * visionDistance, Color.blue);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bala" || collision.gameObject.tag=="Guadania")
        {
            Debug.Log("Esto pasa");
            RecibirDanio();
        }
    }
    public void RecibirDanio()
    {
        vidaActual --;
        if (vidaActual <= 0) 
        {
            Destroy(gameObject);
            GameManager.Instance.MurioEnemigo();
        }//
        healthBar.UpdateHealthBar(vidaMaxima, vidaActual);
    }
    private void OnDrawGizmos()
    {
        if (visionAngle <= 0) return;

        float halfVisionAngle = visionAngle * 0.5f;
        Vector2 P1, P2;

        P1 = PointForAngle(halfVisionAngle, visionDistance);
        P2 = PointForAngle(-halfVisionAngle, visionDistance);

        Gizmos.color = detected ? Color.green : Color.red;

        // Dibujar líneas de detección hacia arriba
        Gizmos.DrawLine(Muzzle.position, (Vector2)transform.position + P1);
        Gizmos.DrawLine(Muzzle.position, (Vector2)transform.position + P2);

        // Dibujar rayo hacia arriba (opcional)
        Gizmos.DrawRay(Muzzle.position, Vector3.up * 4f);
    }

    Vector2 PointForAngle(float angle, float distance)
    {
        // Calcula el punto en una dirección específica y a una distancia determinada
        return new Vector2(Mathf.Tan(angle * Mathf.Deg2Rad), 1f).normalized * distance;
    }
}
