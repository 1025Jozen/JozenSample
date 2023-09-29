using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InputSystem_Sample
{
    public class Player : MonoBehaviour
    {
        [SerializeField] float speed = 1.0f;
        CharacterController controller;

        private void Start()
        {
            controller = GetComponent<CharacterController>();
        }

        private void Update()
        {
            //transform.position += PlayerMove_ActionMap.Instance.inputVector * speed * Time.deltaTime;
            controller.Move(PlayerMove1_ActionMap.Instance.inputVector * speed * Time.deltaTime);
        }
    }
}