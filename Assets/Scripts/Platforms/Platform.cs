using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Platform : MonoBehaviour
{
    [SerializeField] private float bounceForce;
    [SerializeField] private float bounceRadius;

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    public void Break()
    {
        if (_camera.TryGetComponent(out Score _score))
        {
            _score.AddScore(10);
        }
        PlatformSegment[] platformSegments = GetComponentsInChildren<PlatformSegment>();
        foreach (var item in platformSegments)
        {
            item.Bounce(bounceForce, transform.position, bounceRadius);
        }
    }
    
}
