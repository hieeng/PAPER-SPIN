using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearPaper : MonoBehaviour
{
    Rigidbody rigid;
    [SerializeField] Vector3 forceVec;
    [SerializeField] Vector3 torqueVec;
    [SerializeField] int force;
    [SerializeField] int torqueForce;

    private void Awake() 
    {
        rigid = GetComponent<Rigidbody>();
    }

    public void Clear()
    {
        rigid.AddForce(forceVec * force);
        rigid.AddTorque(torqueVec * torqueForce);
    }
}
