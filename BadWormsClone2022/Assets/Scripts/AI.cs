using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    private void Start()
    {
        
    }


    private IEnumerator WaitTimes()
    {
        yield return new WaitForSeconds(1);
    }

}
