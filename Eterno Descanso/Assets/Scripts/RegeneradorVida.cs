using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegeneradorVida : MonoBehaviour
{
    // Start is called before the first frame update
    private int vidaARegenerar;
    void Start()
    {
        vidaARegenerar = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Jugador"))
        {
            collision.gameObject.GetComponent<PlayerBase>().vida += vidaARegenerar;
            Destroy(gameObject);
        }
    }
}
