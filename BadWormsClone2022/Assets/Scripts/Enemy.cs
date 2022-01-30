using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject dieVFX;
    public void KillMe()
    {
        Instantiate(dieVFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
