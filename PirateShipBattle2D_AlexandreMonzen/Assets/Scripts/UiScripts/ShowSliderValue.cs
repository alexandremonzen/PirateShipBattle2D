using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public sealed class ShowSliderValue : MonoBehaviour
{
    private Slider sliderUI;
    [SerializeField] private Text textSliderValue;

    private void Awake()
    {
        sliderUI = GetComponent<Slider>();
        ShowTextSliderValue();
    }

    public void ShowTextSliderValue()
    {
        textSliderValue.text = sliderUI.value.ToString();
    }
}