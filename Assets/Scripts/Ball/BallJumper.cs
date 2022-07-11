using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallJumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 3;
    private Rigidbody _rigidbody;
    private PlatformSegment platformSegment;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    bool colisia = false;
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.TryGetComponent(out platformSegment))
        {
            if (colisia==false)
            {
                colisia = true;
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            }
        }

    }
    private void OnCollisionExit(Collision collision)
    {
                colisia = false;
    }
}
