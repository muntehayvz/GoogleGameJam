using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionPointRadius;
    [SerializeField] private LayerMask interactableMask;
    [SerializeField] private InteractionPromptUI interactionPromptUI;

    private readonly Collider[] colliders = new Collider[3];
    [SerializeField] private int numFound;

    private IInteractable _interactable;
    private void Update()
    {
        numFound = Physics.OverlapSphereNonAlloc(interactionPoint.position, interactionPointRadius, colliders, interactableMask); 

        if(numFound >0)
        {
            _interactable = colliders[0].GetComponent<IInteractable>();

            if(_interactable != null ) 
            {
                if (!interactionPromptUI.isDisplayed) interactionPromptUI.SetUp(_interactable.InteractionPrompt);

                if (Input.GetKeyDown(KeyCode.E)) _interactable.Interact(this);
            }
        }
        else
        {
            if (_interactable != null) _interactable = null;
            if (interactionPromptUI.isDisplayed) interactionPromptUI.Close();

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionPoint.position, interactionPointRadius);
    }

}
