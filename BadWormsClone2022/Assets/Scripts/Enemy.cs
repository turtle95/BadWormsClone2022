using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject dieVFX;
    public void KillMe()
    {
        GetComponent<AudioSource>().Play();
        GameManager.Instance.EnemyKilled();
        Instantiate(dieVFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }



}
