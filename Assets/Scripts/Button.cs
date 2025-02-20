using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Button : MonoBehaviour
{
    public void LoadMetaSampleScene()
    {
        SceneManager.LoadScene("MetaSampleScene");
    }
    public void Retry()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
