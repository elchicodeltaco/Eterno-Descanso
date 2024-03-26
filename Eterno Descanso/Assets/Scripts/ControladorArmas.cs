using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorArmas : MonoBehaviour
{
    public GameObject[] armas;
    private int indiceArma = 0;

    // Start is called before the first frame update

    private void Update()
    {
        CambioArmas();
    }
    private void Start()
    {
        armas[1].SetActive(false);
    }
    public void CambioArmas()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(indiceArma != 0)
            {
                seleccionarArmaAnterior();
            }
            else if (indiceArma == 0)
            {
                armas[armas.Length - 1].SetActive(true);
                armas[indiceArma].SetActive(false);
                indiceArma= armas.Length-1;
            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (indiceArma + 1 < armas.Length)
            {
                seleccionarArmaSiguiente();
            }
            else
            {
                armas[0].SetActive(true);
                armas[indiceArma].SetActive(false);
                indiceArma = 0;
            }
        }
    }

    private void seleccionarArmaSiguiente()
    {
        armas[indiceArma].SetActive(false);
        armas[indiceArma + 1].SetActive(true);
        indiceArma++;
    }
    private void seleccionarArmaAnterior()
    {
        armas[indiceArma - 1].SetActive(true);
        armas[indiceArma].SetActive(false);
        indiceArma--;
    }
    private void endAtackAnim()
    {

    }
}
