using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSwapper : GenericSingletonClass<AudioSwapper>
{
    public AudioSource calm;
    public AudioSource fight;
    private bool calmOnOn = true;

    public float swapSpeed = 2f;

    public void SwapAudio(bool calmOn)
    {
        calmOnOn = calmOn;
    }

    private void Update()
    {
        if (calmOnOn)
        {
            if (calm.volume < 1)
                calm.volume += Time.deltaTime * swapSpeed;
            else
                calm.volume = 1;

            if (fight.volume > 0)
                fight.volume -= Time.deltaTime * swapSpeed;
        }
        else
        {
            if (fight.volume < 1)
                fight.volume += Time.deltaTime * swapSpeed;
            else
                fight.volume = 1;

            if (calm.volume > 0)
                calm.volume -= Time.deltaTime * swapSpeed;
        }
    }

}
