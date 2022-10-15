using UnityEngine;

namespace SpecialCamerasSetups
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;
        public Transform child;
        public Camera cameraComponent;

        private float _horizontalRotationValue;
        private float _verticalRotationValue;

        public float verticalRotationMin = -40;
        public float verticalRotationMax = 50;

        public float distanceOfTarget;
        public float heightOfCamera;

        public LayerMask cameraCollisionDetection;

        private void Update()
        {
            _horizontalRotationValue += Input.GetAxis("Mouse X");
            _verticalRotationValue += Input.GetAxis("Mouse Y");
            transform.position = target.position;
            transform.rotation = Quaternion.Euler(_verticalRotationValue, _horizontalRotationValue, 0);
            child.transform.localPosition = new Vector3(0, heightOfCamera, -distanceOfTarget);

            RaycastPosition();
        }

        private void RaycastPosition()
        {
            RaycastHit hit;
            _verticalRotationValue = Mathf.Clamp(_verticalRotationValue, verticalRotationMin, verticalRotationMax);

            if (Physics.Linecast(transform.position, child.transform.position, out hit, cameraCollisionDetection))
            {
                Debug.DrawLine(transform.position, hit.point, Color.red);
                cameraComponent.transform.position = hit.point;
            }
            else
            {
                Debug.DrawLine(transform.position, child.transform.position, Color.green);
                cameraComponent.transform.localPosition = new Vector3(0, 0, 0);
            }
        }
    }
}
