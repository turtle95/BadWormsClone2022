using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour
{
    public int SceneNumber =0;
    public GameObject[] singlton;
    public void OnPress()
    {
        KillAllSingletons();
        SceneManager.LoadScene(SceneNumber);
    }


    private void KillAllSingletons()
    {
        foreach(GameObject g in singlton)
        {
            Destroy(g);
        }
    }
}
