using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class GarageDOOR : MonoBehaviour
{
    private Animator animator;
    private Animation anim;
    public bool isOpen;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Used", true);
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Opened", isOpen);
    }

    private void OnTriggerEnter(Collider collider)
    {
        isOpen = true;
    }
}
