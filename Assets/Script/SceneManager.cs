using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public void ChangeScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("PlayScene");
    }
}
