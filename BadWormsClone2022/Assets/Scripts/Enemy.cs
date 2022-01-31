using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject dieVFX;
    public AudioSource scream;


    public void KillMe()
    {
        scream.Play();
        scream.time = 0.9f;
        GameManager.Instance.EnemyKilled();
        Instantiate(dieVFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }



}
