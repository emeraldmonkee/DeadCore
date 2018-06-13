using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour, IInteractable
{
    [SerializeField] private float interactRadius = 1.0f;

    public virtual void Interact()
    {

    }

    public virtual void OnDrawGizmos()
    {
        if (!UnityEditor.Selection.Contains(gameObject)) return;
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(gameObject.transform.position, interactRadius);
    }
}
