using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public int maxAffection = 10;

    public void SetMaxHealth(int health)
    {
        slider.minValue = health;
        slider.maxValue = maxAffection;
        slider.value = health;

        fill.color = gradient.Evaluate(0f);
    }

   public void SetHealth(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
