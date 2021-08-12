using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace genaralskar
{

    public class PlayerInteractor : MonoBehaviour
    {

        public GameObject interactIcon;
        public TextMeshPro interactTextObject;
        public string interactText = "";

        private List<IInteractable> interactables = new List<IInteractable>();
        private IInteractable activeInteractable;

        [SerializeField] private Actor.Actor player;

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
            

            interact.OnEnterInteract(player);

            interactIcon.SetActive(true);
            //Debug.Log("New interactable added: " + interact);
        }

        private void RemoveInteractable(IInteractable interact)
        {
            if (interactables.Contains(interact))
            {
                interactables.Remove(interact);

                interact.OnLeaveInteract(player);

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
                interactText = interact.InteractText;
                Debug.Log($"interact: {interact}, interact text: {interact.InteractText}");
                interactTextObject.text = interactText;
                //Debug.Log("New active interactable: " + interact);
            }
        }

        private void RemoveActiveInteractable()
        {
            activeInteractable = null;
            interactText = "";
            interactIcon.SetActive(false);
            //Debug.Log("No more active interactables!");
        }

        //Inputs!
        private void Update()
        {
            if(interactIcon.activeSelf && Input.GetButtonDown("Interact"))
            {
                Interact();
            }
        }

        private void Interact()
        {
            if (activeInteractable == null) return;
            activeInteractable.OnInteract(player);
            interactText = "";
            interactIcon.SetActive(false);
        }
    }
}
