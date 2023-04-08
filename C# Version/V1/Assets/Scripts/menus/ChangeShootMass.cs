using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChangeShootMass : MonoBehaviour
{
    [SerializeField] private Slider mySlider;
    [SerializeField] private TextMeshProUGUI mySliderText;

    void Start()
    {
        mySlider.onValueChanged.AddListener((v) => {
            float s = MenuSettings.MassSliderExpo(v);
            mySliderText.text = s.ToString("0");
        });
    }
    void Update()
    {
        // MenuSettings.shootMass = (int) MenuSettings.MassSliderExpo(mySlider.value);
        MenuSettings.shootMass = (int)mySlider.value;
        
    }
}
