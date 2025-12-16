using UnityEngine;
using UnityEngine.UI;

public class SoundEffectManager : MonoBehaviour
{
    public static SoundEffectManager instance;
    public static SoundEffectManager Instance => instance;
    private static AudioSource audioSource;
    private static SoundEffectLibrary soundEffectLibrary;
    [SerializeField] private Slider sfxSlider;


    private void Awake() 
    {
        if (instance == null)
        {
            instance = this;
            audioSource = GetComponent<AudioSource>();
            soundEffectLibrary = GetComponent <SoundEffectLibrary>();
            DontDestroyOnLoad(gameObject);
            }
        else
        {
            Destroy(gameObject);
        }
    
    }

    void Start()
    {
        sfxSlider.onValueChanged.AddListener(delegate { OnValueChanged(); });
    }

    public static void Play(string soundName)

    {
        AudioClip audioClip = soundEffectLibrary.GetRandomClip(soundName);
        if (audioClip != null)
        { 
        audioSource.PlayOneShot(audioClip);
        }
    }

    public static void SetVolume(float volume)
    { 
    audioSource.volume = volume;    
    }

    public void OnValueChanged()
    {
        SetVolume(sfxSlider.value);
    }

    public static float GetVolume()
    {
        if (audioSource != null)
            return audioSource.volume;
        return 1f; 
    }

}
