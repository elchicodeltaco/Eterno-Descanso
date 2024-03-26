using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DashBar : MonoBehaviour
{
    [SerializeField] private Image BarImage;
    private float fillSpeed = 1.0f; // Velocidad de llenado de la barra

    // Método para actualizar la barra de forma gradual
    public void UpdateDashBar(float CD)
    {
        StartCoroutine(FillBarOverTime(CD));
    }

    // Corrutina para llenar gradualmente la barra
    private IEnumerator FillBarOverTime(float CD)
    {
        float currentFill = CD;

        while (currentFill >= 0)
        {
            currentFill -= fillSpeed * Time.deltaTime;
            BarImage.fillAmount = Mathf.Clamp01(currentFill);
            yield return null;
        }
    }
}
