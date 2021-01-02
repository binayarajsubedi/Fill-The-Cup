using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip dropSound;
    static AudioSource audiosrc;

    // Start is called before the first frame update
    void Start()
    {
        dropSound = Resources.Load<AudioClip>("dropSound");
        audiosrc = GetComponent<AudioSource>();
    }

    public static void PlaySound()
    {
        audiosrc.PlayOneShot(dropSound);
    }
}
