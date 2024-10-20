using System;
using UnityEngine;
using Zenject;

namespace _Project.Scripts
{
    [RequireComponent(typeof(Collider),typeof(Rigidbody))]
    public class ItemObject:MonoBehaviour, Interfaces.IInteract
    {
        public Rigidbody rb;
        public Collider collider;
        
        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            collider = GetComponent<Collider>();
        }

        public string interactMessage { get; } = "[E] Взять";

        public void Interact(GameObject sender)
        {
            if (sender.TryGetComponent<Player>(out var player))
            {
                transform.SetParent(player.slotPosition.parent);
                transform.position = player.slotPosition.position;
                player.itemObject = this;
                rb.isKinematic = true;
                collider.isTrigger = true;
                
            }
            else
            {
                return;
            }
        }
    }
}