using UnityEngine;

namespace Zetcil
{
    public class FPSController : MonoBehaviour
    {
        [Space(10)]
        public bool isEnabled;

        [Header("Movement Settings")]
        public float walkSpeed = 6.0F;
        public float jumpSpeed = 8.0F;
        public float runSpeed = 8.0F;
        public float gravity = 20.0F;

        private Vector3 moveDirection = Vector3.zero;
        private CharacterController controller;

        void Start()
        {
            controller = GetComponent<CharacterController>();
            transform.localScale = new Vector3(1, 1, 1);
        }

        void Update()
        {
            if (controller.isGrounded)
            {
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= walkSpeed;
                if (Input.GetButton("Jump"))
                    moveDirection.y = jumpSpeed;
            }
            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);
        }
    }
}