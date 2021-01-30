using UnityEngine;

public class CameraRaycasting : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float range;

    private IInteractable currentTarget;
    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        RaycastForInteractable();

        if (Input.GetButtonDown("Use"))
        {
            if (currentTarget != null)
            {
                currentTarget.OnInteract();
            }
        }
    }

    private void RaycastForInteractable()
    {
        RaycastHit hit;

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, range))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            if (interactable != null)
            {
                if (hit.distance <= interactable.MaxRange)
                {
                    if (interactable == currentTarget)
                        return;
                    if(currentTarget != null)
                    {
                        currentTarget.OnEndHover();
                        currentTarget = interactable;
                        currentTarget.OnStartHover();
                        return;
                    }
                    currentTarget = interactable;
                    currentTarget.OnStartHover();
                }
                else
                {
                    if (currentTarget != null)
                    {
                        currentTarget.OnEndHover();
                        currentTarget = null;
                    }
                }
            }
            else
            {
                if (currentTarget == null) 
                    return;
                currentTarget.OnEndHover();
                currentTarget = null;
            }
        }
        else
        {
            if (currentTarget == null) 
                return;
            currentTarget.OnEndHover();
            currentTarget = null;
        }
    }
}
