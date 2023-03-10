using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChangeGunType : MonoBehaviour
{
    [SerializeField] private Slider mySlider;

    
    void Update()
    {
        SceneConstants.type = (int) mySlider.value;
    }
}
