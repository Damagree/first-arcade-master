using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zetcil
{
    public class FPSMouseLook : MonoBehaviour
    {
        [Space(10)]
        public bool isEnabled;

        [Header("Camera Settings")]
        public Camera CameraController;

        [Header("MouseLook Settings")]
        public bool lookAutomatic = true;
        public float lookSensitivity = 5;
        public float lookSmoothnes = 0.1f;

        [Header("Readonly Status")]
        public float yRotation;
        public float xRotation;
        public float currentXRotation;
        public float currentYRotation;
        public float yRotationV;
        public float xRotationV;

        void Start()
        {
            xRotation = CameraController.transform.rotation.eulerAngles.x;
            yRotation = CameraController.transform.rotation.eulerAngles.y;
            currentXRotation = CameraController.transform.rotation.eulerAngles.x;
            currentYRotation = CameraController.transform.rotation.eulerAngles.y;
        }

        void Update()
        {
            if (isEnabled)
            {
                if (lookAutomatic)
                {
                    MouseLook();
                }
                else if (Input.GetKey(KeyCode.Mouse1))
                {
                    MouseLook();
                }
            }
        }

        void MouseLookDegree(float xx, float yy)
        {
            yRotation = yy;
            xRotation = xx;
            xRotation = Mathf.Clamp(xRotation, -80, 100);
            currentXRotation = Mathf.SmoothDamp(currentXRotation, xRotation, ref xRotationV, lookSmoothnes);
            currentYRotation = Mathf.SmoothDamp(currentYRotation, yRotation, ref yRotationV, lookSmoothnes);

            CameraController.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            transform.localRotation = Quaternion.Euler(0, yRotation, 0);
        }

        void MouseLook()
        {
            yRotation += Input.GetAxis("Mouse X") * lookSensitivity;
            xRotation -= Input.GetAxis("Mouse Y") * lookSensitivity;
            xRotation = Mathf.Clamp(xRotation, -80, 100);
            currentXRotation = Mathf.SmoothDamp(currentXRotation, xRotation, ref xRotationV, lookSmoothnes);
            currentYRotation = Mathf.SmoothDamp(currentYRotation, yRotation, ref yRotationV, lookSmoothnes);
            
            CameraController.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            transform.localRotation = Quaternion.Euler(0, yRotation, 0);
        }
    }
}
