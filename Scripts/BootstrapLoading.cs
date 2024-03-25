using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BootstrapLoading : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Image LoadingBar;


    private void Start()
    {
        SceneManager.LoadScene(1);
        //StartCoroutine(LoadLevenAsync(1));
    }
    private IEnumerator LoadLevenAsync(int sceneId)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);
        LoadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            LoadingBar.fillAmount = 1 / operation.progress;
            yield return null;
        }
    }
}
