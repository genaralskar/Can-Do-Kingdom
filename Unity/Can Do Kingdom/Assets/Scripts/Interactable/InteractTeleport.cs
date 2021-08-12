using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace genaralskar
{
    public class InteractTeleport : MonoBehaviour, IInteractable
    {
        [SerializeField] private Transform teleportLocation;

        [SerializeField]
        private UnityEvent teleportEvent;

        public string InteractText => "Use";

        public void OnEnterInteract(Actor.Actor player)
        {
            
        }

        public void OnInteract(Actor.Actor player)
        {
            player.transform.position = teleportLocation.position;
            player.transform.GetChild(0).rotation = teleportLocation.rotation;
            teleportEvent?.Invoke();
        }

        public void OnLeaveInteract(Actor.Actor player)
        {
            
        }

        private void Teleport()
        {

        }
    }
}