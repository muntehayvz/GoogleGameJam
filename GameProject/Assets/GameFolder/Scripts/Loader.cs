using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader 
{
    private class LoadingMonoBehaviour : MonoBehaviour {  }

    public enum Scene
    {
        MainMenuScene,
        LoadingScene,
        SampleScene,
        SecondScene
    }
    //private static Scene targetScene;
    private static Action onLoaderCallback;
    private static AsyncOperation loadingAsyncOperation;

    public static void Load(Scene scene)
    {
        
        onLoaderCallback = () =>
        {
            GameObject loadingGameObject = new GameObject("Loading Game Object");
            loadingGameObject.AddComponent<LoadingMonoBehaviour>().StartCoroutine(LoadSceneAsync(scene));
            
        };

        SceneManager.LoadScene(Scene.LoadingScene.ToString());
    }

    private static IEnumerator LoadSceneAsync(Scene scene)
    {
        yield return null;
        loadingAsyncOperation = SceneManager.LoadSceneAsync(scene.ToString());

        while (!loadingAsyncOperation.isDone)
        {
            yield return null;  
        }
    }

    public static float GetLoadingProgress()
    {
        if(loadingAsyncOperation != null) {
            return loadingAsyncOperation.progress;
        }
        else
        {
            return 1.0f;
        }
    }
    public static void LoaderCallback()
    {
        if(onLoaderCallback != null) 
        {
            onLoaderCallback();
            onLoaderCallback= null;
        }
    }
}
