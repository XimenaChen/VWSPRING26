using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip door;    
    [SerializeField] AudioClip book;

    [SerializeField] AudioClip calling;
    [SerializeField] AudioClip callingnew;
    [SerializeField] AudioClip ring;
    [SerializeField] AudioClip secondCalling;
     [SerializeField] AudioClip alarm;
       [SerializeField] AudioClip applaud;

  [SerializeField] AudioClip manyapplaud;

  [SerializeField] AudioClip turnonlight;
  [SerializeField] AudioClip stonemove;


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
        }else if (clip == "ring") {
            audioSource.clip = ring;
            audioSource.Play();
            
        }else if (clip == "secondCalling") {
            audioSource.clip = secondCalling;
            audioSource.Play();
            
        }else if (clip == "alarm") {
            audioSource.clip = alarm;
            audioSource.loop = true;
            audioSource.PlayDelayed(5.0f);
            
        }
    
        else if (clip == "applaud") {
            audioSource.clip = applaud;
            audioSource.Play();
        }
        else if (clip == "manyapplaud") {
            audioSource.clip = manyapplaud;
            audioSource.Play();
        }
        else if (clip == "turnonlight") {
            audioSource.clip = turnonlight;
            audioSource.Play();
        }
        else if (clip == "stonemove") {
            audioSource.clip = stonemove;
            audioSource.Play();
        }
    }
}