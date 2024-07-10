using System;
using UnityEngine;

namespace Gameplay
{
    public class PlayerMovement : MonoBehaviour
    {
        public CharacterController characterController;
        public float speed = 12f;
        public float gravity = -9.81f;
        public float jumpHeight = 1f;
        public Transform groundCheck;
        public float groundDistance = 0.4f;
        public LayerMask groundMask;

        private float _xMovement, _zMovement;
        private Vector3 _playerMotion;
        private Vector3 _playerVelocity;
        private bool _isGrounded;

        private void Update()
        {
            _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (_isGrounded && _playerVelocity.y < 0)
            {
                _playerVelocity.y = -2f;
            }
            _xMovement = Input.GetAxis("Horizontal");
            _zMovement = Input.GetAxis("Vertical");

            _playerMotion = transform.right * _xMovement + transform.forward * _zMovement;

            characterController.Move(_playerMotion * speed * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && _isGrounded)
            {
                _playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            _playerVelocity.y += gravity * Time.deltaTime;
            characterController.Move(_playerVelocity * Time.deltaTime);
        }
    }
}