using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace LookAt_Sample {
    public class LookAt : MonoBehaviour
    {
        [SerializeField] GameObject target;
        public float rotationSpeed = 1f;                //回転速度

        void Update() {
            Look();
        }

        private void Look() {
            Vector3 dir = (target.transform.position - this.transform.position).normalized;
            Vector3 LookVec = new Vector3(dir.x, 0f, dir.z);
            Quaternion lookAtRotation = Quaternion.LookRotation(LookVec, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookAtRotation, rotationSpeed * Time.deltaTime);
        }
    }
}

