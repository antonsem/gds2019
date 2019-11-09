using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExtraTools;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField]
    private PlayerStats stats;
    [MyBox.ReadOnly, SerializeField]
    private Rigidbody rigid;

    private bool interact = false;
    private Vector3 moveDir = Vector3.zero;
    private List<IInteratable> interactables = new List<IInteratable>();

    private void GetInput()
    {
        moveDir.x = Input.GetAxisRaw("Horizontal");
        moveDir.z = Input.GetAxisRaw("Vertical");

        interact = Input.GetKeyDown(KeyCode.Space);
    }

    private void Interact(bool doInteract)
    {
        if (doInteract)
        {
            foreach (IInteratable interactable in interactables)
                interactable.Interact();
        }
    }

    private void Move(Vector3 direction)
    {
        direction.Normalize();
        rigid.velocity = direction * stats.MoveSpeed;
    }

    private void Rotate(Vector3 newRot, float delta)
    {
        if (newRot != Constants.Variables.Vector3zero) //TODO: Fix the rotation bug when forward = -newRot -Anton
            transform.forward = Vector3.Lerp(transform.forward, newRot, delta);
    }

    private void Update()
    {
        if (stats.CanMove)
        {
            GetInput();
            Move(moveDir);
            Rotate(moveDir, Time.deltaTime * stats.RotationSpeed);
            Interact(interact);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent(out IInteratable interactable))
            interactables.Add(interactable);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.GetComponent(out IInteratable interactable) && interactables.Contains(interactable))
            interactables.Remove(interactable);
    }

#if UNITY_EDITOR
    [MyBox.ButtonMethod]
    private void GetRigidbody()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Reset()
    {
        rigid = GetComponent<Rigidbody>();
    }
#endif
}
