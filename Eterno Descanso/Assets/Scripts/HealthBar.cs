using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Image BarImage;

    public void UpdateHealthBar(float maxHealth, float health)
    {
        BarImage.fillAmount = health / maxHealth;
    }
}
