using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip door;    
    [SerializeField] AudioClip book;

    [SerializeField] AudioClip calling;
    [SerializeField] AudioClip callingnew;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void playClip(string clip)
    {
        if (clip == "door")
        {
            audioSource.clip = door;
            audioSource.Play();
        } else if (clip == "book") {
            audioSource.clip = book;
            audioSource.Play();
        } else if (clip == "calling") {
            audioSource.clip = calling;
            audioSource.Play();
        }
        else if (clip == "callingnew") {
            audioSource.clip = callingnew;
            audioSource.Play();
        }
    }
}