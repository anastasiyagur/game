using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Citation to make the camera follow the player 
 * https://discussions.unity.com/t/rotation-not-working-the-way-i-intended-it-to-do/941377/2
 */
public class cameraFollow : MonoBehaviour
{
    private Vector3 _offset;
    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime;
    private Vector3 _currentVelocity = Vector3.zero;


    public void Awake()
    {
        _offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = target.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, smoothTime);
    }
}
