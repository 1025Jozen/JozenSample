using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rot {
    public class Rot : MonoBehaviour
    {
        float inputX;
        float yRotSpeed = 10f;
        Vector3 yRot;

        void Update() {
            inputX = Input.GetAxis("Horizontal");

            //①
            //transform.localEulerAngles += new Vector3(0, inputX, 0) * yRotSpeed * Time.deltaTime;

            //②
            yRot += new Vector3(0, inputX * Time.deltaTime * yRotSpeed, 0);
            transform.rotation = Quaternion.Euler(yRot);//yRotの方向を見続ける //入力がなければ同じ方向を見る


            //③
            //yRot += new Vector3(0, inputX, 0);
            //transform.rotation = Quaternion.Euler(yRot * Time.deltaTime * yRotSpeed);//入力がなくても回転し続ける
        }

        private void FixedUpdate()
        {
            
        }
    }
}


