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

    private Vector3 moveDir = Vector3.zero;
    private List<IInteratable> interactables = new List<IInteratable>();

    private void GetInput()
    {
        moveDir.x = Input.GetAxisRaw("Horizontal");
        moveDir.z = Input.GetAxisRaw("Vertical");
    }

    private void Move(Vector3 direction)
    {
        direction.Normalize();
        rigid.velocity = direction * stats.MoveSpeed;
    }

    private void Rotate(Vector3 newRot, float delta)
    {
        transform.forward = Vector3.Lerp(transform.forward, newRot, delta);
    }

    private void Update()
    {
        GetInput();
        Move(moveDir);
        if (moveDir != Vector3.zero)
            Rotate(moveDir, Time.deltaTime * stats.RotationSpeed);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.transform.GetComponent(out IInteratable interactable))
    //    {

    //    }
    //}

    private void OnTriggerExit(Collider other)
    {
        
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
