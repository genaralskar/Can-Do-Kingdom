using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace genaralskar
{
    public class PlayerInteractor : MonoBehaviour
    {
        private List<IInteractable> interactables = new List<IInteractable>();
        private IInteractable activeInteractable;

        private void OnTriggerEnter(Collider other)
        {
            IInteractable i = other.GetComponent<IInteractable>();
            if(i != null)
                AddInteractable(i);
        }

        private void OnTriggerExit(Collider other)
        {
            IInteractable i = other.GetComponent<IInteractable>();
            if (i != null)
                RemoveInteractable(i);
        }

        private void AddInteractable(IInteractable interact)
        {
            if (interactables.Contains(interact)) return;
            interactables.Add(interact);
            SetActiveInteractable(interact);
            //Debug.Log("New interactable added: " + interact);
        }

        private void RemoveInteractable(IInteractable interact)
        {
            if (interactables.Contains(interact))
            {
                interactables.Remove(interact);
                if (activeInteractable == interact)
                {
                    int x = interactables.Count;
                    if(x != 0)
                    {
                        SetActiveInteractable(interactables[x - 1]);
                    }
                    else
                    {
                        RemoveActiveInteractable();
                    }
                }
            }
        }

        private void SetActiveInteractable(IInteractable interact)
        {
            if (activeInteractable != interact)
            {
                activeInteractable = interact;
                //Debug.Log("New active interactable: " + interact);
            }
        }

        private void RemoveActiveInteractable()
        {
            activeInteractable = null;
            //Debug.Log("No more active interactables!");
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                Interact();
            }
        }

        private void Interact()
        {
            if (activeInteractable == null) return;
            activeInteractable.OnInteract();
        }

    }
}
