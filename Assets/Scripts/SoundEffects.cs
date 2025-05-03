using UnityEngine;
using UnityEngine.UI;

public class SoundEffects : MonoBehaviour
{
    public AudioClip clickSound;
    private static AudioSource audioSource;

    void Awake()
    {
       
        if (audioSource == null)
        {
            GameObject soundPlayer = new GameObject("UIButtonSoundPlayer");
            audioSource = soundPlayer.AddComponent<AudioSource>();
            DontDestroyOnLoad(soundPlayer);
        }
    }

    void Start()
    {
        
        GetComponent<Button>().onClick.AddListener(PlaySound);
    }

    void PlaySound()
    {
        if (clickSound != null)
            audioSource.PlayOneShot(clickSound);
        else
            Debug.LogWarning($"Button '{gameObject.name}' has no click sound assigned.");
    }
}
