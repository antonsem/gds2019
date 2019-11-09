using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField]
    private PlayerStats stats;
    [MyBox.ReadOnly]
    private Rigidbody rigid;

    private void Move(Vector3 direction)
    {
        rigid.velocity = direction * stats.MoveSpeed;
    }

#if UNITY_EDITOR

    private void GetRigidbody()
    {

    }

    private void Reset()
    {
        rigid = GetComponent<Rigidbody>();
    }
#endif
}
