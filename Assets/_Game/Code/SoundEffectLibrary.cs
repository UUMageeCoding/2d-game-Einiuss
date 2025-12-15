using UnityEngine;

public class SoundEffectLibrary : MonoBehaviour
{
    [SerializeField] private SoundEffectGroup[] soundEffectGroups;
        private Dictionary<string, List<AudioClip>> soundDictionary;
}


[System.Serializable]

public struct SoundEffectGroup
{
    public string name;
    public List<AudioClip> audioClips;
}
