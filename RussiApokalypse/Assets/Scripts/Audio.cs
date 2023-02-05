using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    private AudioSource[] sounds;
    // Start is called before the first frame update
    void Start()
    {
        sounds = GetComponents<AudioSource>();
    }

    public void PlayerDeath(AudioClip death)
    {
        sounds[0].PlayOneShot(death);
    }
    public void EnemyDeath(AudioClip death)
    {
        sounds[1].PlayOneShot(death);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
