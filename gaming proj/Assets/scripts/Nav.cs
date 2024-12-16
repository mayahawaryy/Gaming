using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Nav : MonoBehaviour
{
    public GameObject LoaderUI;         // UI for the loading screen
    public Slider progressSlider;      // Slider to display progress

    private static Vector3 lastCheckpointPosition; // Stores last checkpoint position
    private static int lastCheckpointScene;        // Stores last checkpoint scene index
    private static bool checkpointSet = false;     // Tracks if a checkpoint is set

    // This method sets the checkpoint when called
    public static void SetCheckpoint(Vector3 position, int sceneIndex)
    {
        lastCheckpointPosition = position;
        lastCheckpointScene = sceneIndex;
        checkpointSet = true;
    }

    // Retry function
    public void Retry()
    {
        if (checkpointSet)
        {
            StartCoroutine(LoadScene_Coroutine(lastCheckpointScene, true));
        }
        else
        {
            Debug.LogWarning("No checkpoint set! Reloading the current scene.");
            StartCoroutine(LoadScene_Coroutine(SceneManager.GetActiveScene().buildIndex, false));
        }
    }

    public void LoadScene(int index)
    {
        StartCoroutine(LoadScene_Coroutine(index, false));
    }

    private IEnumerator LoadScene_Coroutine(int index, bool returnToCheckpoint)
    {
        progressSlider.value = 0;
        LoaderUI.SetActive(true);

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(index);
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

        // Return to checkpoint if applicable
        if (returnToCheckpoint && checkpointSet && lastCheckpointScene == index)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                player.transform.position = lastCheckpointPosition; // Move player to checkpoint position
            }
        }
    }
}
