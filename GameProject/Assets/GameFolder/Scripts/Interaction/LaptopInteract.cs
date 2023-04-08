using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaptopInteract : MonoBehaviour,IInteractable
{
    [SerializeField] private string prompt;
    public string InteractionPrompt => prompt;

    public bool Interact(Interactor interactor)
    {
        //  var Energy = interector.GetComponent<Energy>();
        // if (Energy.value == 0)
          //Show energy is empty and  return false; }
        //if(energy.value > 5 ) return true and setanimator trigger to coding.
        Debug.Log("Coding!");
        return true;
    }
}
