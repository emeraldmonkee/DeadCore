using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    // TODO: Make interact radius a cube rather than a sphere
    [SerializeField] private float interactRadius = 1.0f;
    [SerializeField] private Animator animator;
    [SerializeField] private bool isOpen = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public virtual void Interact()
    {

    }

    public virtual void OnSwitchInteract()
    {
        isOpen = !isOpen;
        animator.SetBool("Opened", isOpen);
    }

    public virtual void OnDrawGizmos()
    {
        if (!UnityEditor.Selection.Contains(gameObject)) return;
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(gameObject.transform.position, interactRadius);
    }
}
