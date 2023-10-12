using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Shadow
{
    public class UnityEventOnTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider col) {
            if (col.CompareTag("Player") ) {
                col.enabled = false;
            }
        }

        private void OnTriggerExit(Collider col) {
            if (col.CompareTag("Player") ) {
                col.enabled = true;
            }
        }       
    }

}


