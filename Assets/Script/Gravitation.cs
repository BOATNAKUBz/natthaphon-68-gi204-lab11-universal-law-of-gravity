using System.Collections.Generic;
using UnityEngine;

public class Gravitation : MonoBehaviour
{
    Rigidbody rb;
    const float G = 0.006674f; // Gravitational Constant 6.674

    // create a List of objects in the galaxy to attract
    public static List<Gravitation> otherObjectsList;

    // set speed for orbiting
    [SerializeField] bool planet = false; // if not a planet -> orbit
    [SerializeField] int orbitSpeed = 1000;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        // create a list for the first time
        if (otherObjectsList == null)
        {
            otherObjectsList = new List<Gravitation>();
        }

        // add object (with gravity script) to attract to the list
        otherObjectsList.Add(this);

        // orbiting
        if (planet)
        {
            rb.AddForce(Vector3.left * orbitSpeed);
        }
    }
}