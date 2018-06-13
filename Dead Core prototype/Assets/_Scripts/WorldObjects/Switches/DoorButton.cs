using UnityEngine;

public class DoorButton : Switch
{
    [SerializeField] private Door targetDoor;

    public override void Interact()
    {
        base.Interact();

        targetDoor.OnSwitchInteract();
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        if (!UnityEditor.Selection.Contains(gameObject)) return;
        if (targetDoor)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(gameObject.transform.position, targetDoor.transform.position);
        }
    }
}
