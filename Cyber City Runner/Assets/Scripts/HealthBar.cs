using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour

/*
 * Citation for creating a health bar
 * https://weeklyhow.com/how-to-make-a-health-bar-in-unity/
 */
{
    [SerializeField] private Image _healthbarSprite;

    public void UpdateHealthBar(float maxHealth, float currHealth)
    {
        _healthbarSprite.fillAmount = Mathf.Clamp(currHealth / maxHealth, 0, 1);
    }
}
