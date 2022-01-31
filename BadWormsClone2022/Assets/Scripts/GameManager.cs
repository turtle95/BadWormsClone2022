using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : GenericSingletonClass<GameManager>
{
    public int enemyCount = 1;

    public GameObject winShit;
    public GameObject[] offOnWin;

    public void EnemyKilled()
    {
        enemyCount--;
        StartCoroutine(WaitTimer());
    }


    IEnumerator WaitTimer()
    {
        yield return new WaitForSeconds(2f);
        CheckForWin();
    }

    private void CheckForWin()
    {
        if(enemyCount <= 0)
        {
            winShit.SetActive(true);
            foreach(GameObject g in offOnWin)
            {
                g.SetActive(false);
            }
        }
    }
}
