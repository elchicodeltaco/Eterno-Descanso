using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Bala : MonoBehaviour
{
    // Start is called before the first frame update

    private float tiempoADesactivar = 7f;
    public bool esBalaAliada;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /**/

        if (collision.tag != "Guadania" && collision.tag != "Bala")
        {
            DesactivacionInmediata();
        }
        ChoqueDeBala(collision.gameObject);

    }
    public void desactivarAccion()
    {
        StartCoroutine(DesactivarBala());
    }


    private IEnumerator DesactivarBala()
    {
        yield return new WaitForSeconds(tiempoADesactivar);
        gameObject.SetActive(false);
    }
    virtual public void ChoqueDeBala(GameObject gameobject)
    {

    }
    protected void DesactivacionInmediata()
    {
        StopCoroutine(DesactivarBala());
        gameObject.SetActive(false);
    }
}
