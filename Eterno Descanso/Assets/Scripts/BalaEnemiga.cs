using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaEnemiga : Bala
{
    [SerializeField] float velocidadBala;
    public bool BalaRebotada;
    // Start is called before the first frame update
    void Start()
    {
        esBalaAliada = true;
        BalaRebotada = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void ChoqueDeBala(GameObject collision)
    {
        if (collision.gameObject.tag==("Guadania"))
        {
            ReboteDeBala();
        }
        else if (collision.gameObject.tag==("Bala"))
        {
            Bala balaQueRebota = collision.GetComponent<Bala>();
            if (balaQueRebota != null && balaQueRebota.esBalaAliada && !BalaRebotada)
            {
                ReboteDeBala();
            }
            else 
                DesactivacionInmediata();
        }
    }
    private void ReboteDeBala()
    {
        gameObject.tag = "Bala";
        BalaRebotada = true;

        GameObject[] enemigos = GameObject.FindGameObjectsWithTag("Enemigo");

        GameObject enemigoATargetear = null;
        float distanciaMasCorta = float.MaxValue;
        for(int i = 0; i < enemigos.Length; i++)
        {
            float distancia = Vector2.Distance(transform.position, enemigos[i].transform.position);
            if(distancia < distanciaMasCorta)
            {
                distanciaMasCorta = distancia;
                enemigoATargetear = enemigos[i];
            }
        }
        if(enemigoATargetear != null)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            Vector2 direccion = (enemigoATargetear.transform.position - transform.position).normalized;
            float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg - 90.0f;
            transform.rotation = Quaternion.Euler(0, 0, angulo);
            gameObject.GetComponent<Rigidbody2D>().velocity = direccion * velocidadBala * .5f;


            enemigoATargetear = null;
            
        }
    }
}
