using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip goodJobSound; 
    [SerializeField] private AudioClip wrongSound;
    private AudioSource am;

    // Start is called before the first frame update
    void Start()
    {
        am = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VictorySound()
    {
        am.PlayOneShot(goodJobSound);
    }

    public void WrongSound()
    {
        am.PlayOneShot(wrongSound);
    }
}
