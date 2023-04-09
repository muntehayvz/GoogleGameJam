using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraZoom : MonoBehaviour
{
    private Animator cAnimator;
    public Renderer renderer;
    [SerializeField] private float delayTime = 1f;

    public float delay = 2f;

    void Start()
    {
        cAnimator = GetComponent<Animator>();
        renderer.enabled = true;
    }

    public void Zoom()
    {
        if(cAnimator != null)
        {
            cAnimator.SetTrigger("shouldZoom");
            StartCoroutine(WaitForFunction(delayTime));

            Invoke("LoadLevelAfterDelay", delay);

        }
    }

    public void TabletZoom()
    {
        if (cAnimator != null)
        {
            cAnimator.SetTrigger("tabletZoom");
           
            Invoke("LoadQuizGame", delay);

        }
    }

    IEnumerator WaitForFunction(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        renderer.enabled = false;
    }

    void  LoadLevelAfterDelay()
    {
        Loader.Load(Loader.Scene.SecondScene);
    }

    void LoadQuizGame()
    {
        Loader.Load(Loader.Scene.OmrExampleScene);
    }

}

