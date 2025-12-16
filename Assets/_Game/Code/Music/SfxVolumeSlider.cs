using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SfxVolumeSlider : MonoBehaviour
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

        if (SoundEffectManager.Instance != null)
            slider.value = SoundEffectManager.GetVolume();
    }

    private void OnSliderChanged(float value)
    {
        SoundEffectManager.SetVolume(value);
    }
}
