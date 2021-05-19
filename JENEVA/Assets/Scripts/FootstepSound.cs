using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    public AudioClip[] footsteps;
    AudioSource playerAudio;
    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Footstep()
    {
        int randInd = Random.Range(0, footsteps.Length);
        playerAudio.PlayOneShot(footsteps[randInd]);
    }

}
