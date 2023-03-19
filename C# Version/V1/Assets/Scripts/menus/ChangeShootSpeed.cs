using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChangeShootSpeed : MonoBehaviour
{
    [SerializeField] private Slider mySlider;
    [SerializeField] private TextMeshProUGUI mySliderText;

    void Start()
    {
        mySlider.onValueChanged.AddListener((v) => {
            mySliderText.text = v.ToString("0");
        });
    }
    void Update()
    {
        SceneConstants.shootSpeed = (int) mySlider.value;
    }
}