using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Nav : MonoBehaviour
{
    public void boss()
   {
 SceneManager.LoadScene(6);

 } 
   public void gameover()
   {
 SceneManager.LoadScene(0);

 } 
    public GameObject LoaderUI;
    public Slider progressSlider;
 
    public void LoadScene(int index)
    {
        StartCoroutine(LoadScene_Coroutine(index));
    }
 
    public IEnumerator LoadScene_Coroutine(int index)
    {
        progressSlider.value = 0;
        LoaderUI.SetActive(true);
 
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(1);
        asyncOperation.allowSceneActivation = false;
        float progress = 0;
 
        while (!asyncOperation.isDone)
        {
            progress = Mathf.MoveTowards(progress, asyncOperation.progress, Time.deltaTime);
            progressSlider.value = progress;
            if (progress >= 0.9f)
            {
                progressSlider.value = 1;
                asyncOperation.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}



