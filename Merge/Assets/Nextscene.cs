using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nextscene : MonoBehaviour
{
     public void SphereScene()
     {
        SceneManager.LoadScene("SphereScene");
     }


    public void CubeScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
