using UnityEngine;
using System.Collections.Generic;
using UnityEngine.WSA;
public class Gravity : MonoBehaviour
{
    public static List<Gravity> otherObj;
    private Rigidbody _rb;
    const float G = 0.00677f;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        if (otherObj == null)
        {
            otherObj = new List<Gravity>();
        }
        otherObj.Add(this);
    }
    private void FixedUpdate()
    {
        foreach (Gravity obj in otherObj)
        {
            if (obj != this)
            {
                Attract(obj);
            }
            
        }
    }
    void Attract(Gravity other)
    {
        Rigidbody otherRb = other._rb;
        Vector3 direction = _rb.position - otherRb.position;
             float distance = direction.magnitude;
        if (distance == 0) return; //ป้องกันไม่ให้มีแรงดึงดูด

        // F = G(m1 * m2)/r^2
        float forceMagnitude = G * (_rb.mass * otherRb.mass) / Mathf.Pow(distance , 2);
        Vector3 gravityForce = forceMagnitude * direction.normalized;
        otherRb.AddForce(gravityForce); // ใส่แรงดึงดูดและทิศทางให้กับวัตถุ
    }
   
}
