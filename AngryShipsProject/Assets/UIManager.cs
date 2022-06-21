using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Slider powerSlider;

    private void Awake()
    {
        if (powerSlider == null) {
            print("Slider missing");
            powerSlider = FindObjectOfType<Slider>();
            }
    }
    public void updateSlider(float newValue) 
    {
        powerSlider.value = newValue;
    }
}
