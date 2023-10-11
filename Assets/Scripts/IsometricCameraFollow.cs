using System;
using UnityEngine;

public class IsometricCameraFollow : MonoBehaviour
{
   private Vector3 _offset;
   [SerializeField] private Transform _target;
   [SerializeField] private float _smoothSpeed = 0.125f;
   private Vector3 _velocity = Vector3.zero;

   private void Awake()
   {
      _offset = transform.position - _target.position;
   }

   private void LateUpdate()
   {
      Vector3 targetPosition = _target.position + _offset;
      transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, _smoothSpeed);
   }
}