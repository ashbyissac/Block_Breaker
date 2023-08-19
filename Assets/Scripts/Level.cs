using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks = 0;

    public void CountBlocks()
    {
        breakableBlocks++;
    }

    public void DestroyBreakableBlocks()
    {
        breakableBlocks--;
        if (breakableBlocks == 0)
        {
            Invoke("LoadScene", 0.5f);
        }
    }

    private void LoadScene()
    {
        GameObject.FindObjectOfType<SceneLoader>().LoadNextScene(); 
    }
}
