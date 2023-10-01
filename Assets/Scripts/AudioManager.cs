using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private AudioSource audioSorce;

    [SerializeField] AudioClip click;


    void Awake() 
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSorce = GetComponent<AudioSource>();
    }

    public void PlaySound(string name)
    {
        if(name == "Click")
        {
            audioSorce.clip = click;
            audioSorce.Play();
        }
    }
}
