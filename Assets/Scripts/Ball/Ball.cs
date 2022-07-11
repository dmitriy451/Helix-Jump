using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlatformSegment platformSegment))
        {
            Debug.Log(platformSegment.name);
            other.GetComponentInParent<Platform>().Break();
        }
    }
}
