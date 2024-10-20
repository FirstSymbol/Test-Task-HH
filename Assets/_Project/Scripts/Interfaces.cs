using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Interfaces
{
    public interface IInteract
    {
        public string interactMessage { get; }
        public GameObject gameObject { get; }
        public void Interact(GameObject sender);
    }
}

