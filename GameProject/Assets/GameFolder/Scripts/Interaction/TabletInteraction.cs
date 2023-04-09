using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletInteraction : MonoBehaviour,IInteractable
{
    [SerializeField] private string prompt;
    public string InteractionPrompt => prompt;

    public bool Interact(Interactor interactor)
    {
        Debug.Log("Going into Quiz Game");
        return true;
    }

   
}
