using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class MusicVolumeSlider : MonoBehaviour
{
    private Slider slider;
    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        slider.onValueChanged.RemoveListener(OnSliderChanged);
        slider.onValueChanged.AddListener(OnSliderChanged);
        if (MusicManager.Instance != null)
            slider.value = MusicManager.GetVolume();
    }

    private void OnSliderChanged(float value)
    {
        MusicManager.SetVolume(value);
    }
}
