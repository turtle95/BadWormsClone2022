///
///
///

using System.Collections;
using UnityEngine;




public class KillAfterTime : MonoBehaviour
{
    public float killdelaytime = 3f;
    public GameObject spawnyThing;

    private void Start()
    {
        StartCoroutine(KillDelay());
    }

    private IEnumerator KillDelay()
    {
        yield return new WaitForSeconds(killdelaytime);
        if (spawnyThing != null)
            Instantiate(spawnyThing, transform.position, Quaternion.identity);

        Destroy(this.gameObject);
    }
}
