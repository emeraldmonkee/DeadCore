using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    // TODO: Make interact radius a cube rather than a sphere
    [SerializeField] private float interactRadius = 1.0f;
    private bool toggleLocked = true;

    public virtual void Interact()
    {

    }

    public virtual void OnSwitchInteract()
    {
        toggleLocked = !toggleLocked;
        gameObject.SetActive(toggleLocked);
    }

    public virtual void OnDrawGizmos()
    {
        if (!UnityEditor.Selection.Contains(gameObject)) return;
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(gameObject.transform.position, interactRadius);
    }
}
