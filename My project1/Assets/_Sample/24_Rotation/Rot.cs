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


            //③Time.deltaTime は毎回値が違うなど　挙動がバグるかも
            //yRot += new Vector3(0, inputX, 0);
            //transform.rotation = Quaternion.Euler(yRot * Time.deltaTime * yRotSpeed);//入力がなくても回転し続けてしまうので注意

            //④Unityが用意してくれてるメソッド使えばうまくいく
            //transform.Rotate(new Vector3(0, inputX, 0) * yRotSpeed * Time.deltaTime);//ローカル座標　Rotate (1.0f, 1.0f, 1.0f, Space.World )でワールド
        }

        private void FixedUpdate()
        {
            
        }
    }
}


