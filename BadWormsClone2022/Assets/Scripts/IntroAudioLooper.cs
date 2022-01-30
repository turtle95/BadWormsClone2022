using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroAudioLooper : MonoBehaviour
{
    public AudioSource music;

    public float endLoop = 80f;
    public float loopBackTo = 24f;

    public void LoopStuff()
    {
        if (music.time > endLoop)
            music.time = loopBackTo;
    }
}
