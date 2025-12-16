using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    public static MusicManager Instance => instance;
    private AudioSource audioSource;
    public AudioClip backgroundMusic;
    [SerializeField] private Slider musicSlider;

    private void Awake() 
    {
        if (instance == null)
        { 
        instance = this;
            audioSource = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }
    }


    void Start()
    {
        if (backgroundMusic != null)
        { PlayBackgroundMusic(false, backgroundMusic); }

        musicSlider.onValueChanged.AddListener(delegate {SetVolume(musicSlider.value); });
    }

    public static void SetVolume(float volume)
    { instance.audioSource.volume = volume;}

    public void PlayBackgroundMusic(bool resetSong, AudioClip audioClip = null)
    {
        if (audioClip != null)
        {
            audioSource.clip = audioClip;

        }
        if(audioSource.clip != null)

        {
            if (resetSong)
                audioSource.Stop();
        }
        audioSource.Play();
    }
    public static float GetVolume()
    {
        if (Instance != null && Instance.audioSource != null)
        { return Instance.audioSource.volume; }

        return 1f;
    }

    public void PauseBackgroundMusic() 
    { audioSource.Pause();}


}
