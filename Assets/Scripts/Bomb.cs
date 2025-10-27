using NUnit.Framework;
using System;
using UnityEngine;

public class Bomb : Target
{
    Array allTargetStackObjects;
    Rigidbody stackObjectRigidBody;
    float dist;
    public override void Process(RaycastHit hit)
    {
        allTargetStackObjects = GameObject.FindGameObjectsWithTag("TargetStackObject");
        Debug.Log(allTargetStackObjects.ToString());
        foreach (GameObject stackObject in allTargetStackObjects) {
            dist = Vector3.Distance(stackObject.transform.position, gameObject.transform.position);
            if (dist < 10f)
            {
                stackObjectRigidBody = stackObject.GetComponent<Rigidbody>();
                stackObjectRigidBody.AddForce((stackObjectRigidBody.transform.position - gameObject.transform.position).normalized * (1000/dist));
            }
        }

        effectScript.Play(hit,hitSound,hitEffect,effectDuration);
        Destroy(target);
    }
}
