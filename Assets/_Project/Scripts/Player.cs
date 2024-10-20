using System;
using System.Collections;
using System.Collections.Generic;
using _Project.Scripts;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    [SerializeField] Transform raycastOrigin;
    [field: SerializeField]public Transform slotPosition{get; private set;}
    [field: SerializeField] public float dropForce{get; private set;}
    [field: SerializeField] public float interactDistance{get; private set;}
    private Ray ray = new Ray();
    public ItemObject itemObject;
    HintManager hintManager;

    [Inject]
    private void Inject(HintManager hintManager)
    {
        this.hintManager = hintManager;
    }    

    private void Update()
    {
        
        (ray.origin,ray.direction) = (raycastOrigin.position, raycastOrigin.forward);
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.red);
        Physics.Raycast(ray, out RaycastHit hit);

        if (hit.collider != null && hit.collider.TryGetComponent<Interfaces.IInteract>(out var interact) &&
            Vector3.Distance(transform.position, interact.gameObject.transform.position) <= interactDistance)
        {
            hintManager.OpenHint(interact.interactMessage);
        }
        else
            hintManager.CloseHint();
        
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (itemObject == null)
            {
                if (hit.collider != null && hit.collider.TryGetComponent<Interfaces.IInteract>(out interact) &&
                    Vector3.Distance(transform.position,interact.gameObject.transform.position) <= interactDistance)
                {
                    interact.Interact(gameObject);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (itemObject != null)
            {
                itemObject.transform.SetParent(null);
                itemObject.rb.isKinematic = false;
                itemObject.rb.AddForce(raycastOrigin.transform.forward * dropForce, ForceMode.Impulse);
                itemObject.GetComponent<Collider>().isTrigger = false;
                itemObject = null;
            }
        }
    }
}
