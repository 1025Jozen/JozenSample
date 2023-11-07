using System;
using UnityEngine;

namespace Plane_Sample {
    public class AirplaneController : MonoBehaviour
    {
        public float speed = 100.0f;
        public float rotationSpeed = 2.0f;
        //public float yawSpeed = 10.0f;

        public float maxPitch = 30.0f;
        public float maxRoll  = 30.0f;
        //public float maxYaw   = 30.0f;

        private float pitch = 0.0f;
        private float roll  = 0.0f;
        //private float yaw  = 0.0f;

        void Update() {
            float pitchRotInput = Input.GetAxis("Vertical");
            float rollRotInput  = Input.GetAxis("Horizontal");

            pitch = Mathf.Clamp(pitch + pitchRotInput * rotationSpeed, -maxPitch, maxPitch);//x軸回転
            roll  = Mathf.Clamp(roll  + rollRotInput  * rotationSpeed, -maxRoll , maxRoll); //z軸回転


            // 飛行機の前進
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            // 飛行機の回転
            Quaternion targetRotation = Quaternion.Euler(pitch, 0, -roll);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        }
    }

}
