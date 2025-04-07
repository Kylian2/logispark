using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class SliderValueDisplay : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI valueText; 

    void Start()
    {
        UpdateValue(slider.value);
        slider.onValueChanged.AddListener(UpdateValue);
    }

    void UpdateValue(float value)
    {
        int percent = Mathf.RoundToInt(value * 100);
        valueText.text = percent + "%";
    }
}