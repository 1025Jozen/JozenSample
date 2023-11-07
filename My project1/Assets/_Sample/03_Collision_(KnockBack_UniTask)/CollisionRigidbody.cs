using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace KnockBack
{
    public class CollisionRigidbody : MonoBehaviour
    {
        Rigidbody rb;

        private void Start()
        {
            rb = this.GetComponent<Rigidbody>();  // rigidbodyを取得
        }

        private void OnCollisionEnter(UnityEngine.Collision collision) {
            if (collision.gameObject.CompareTag("Enemy")) {
                Debug.Log("当たった");
                rb.AddForce(-transform.right * 2f, ForceMode.VelocityChange);//質量を無視

            }
        }
    }
}
