using System.Collections;
using System.Collections.Generic;
using Glass;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.ParticleSystem;



namespace OnePoint_Effect
{
    public class TapEffect : MonoBehaviour
    {
        [SerializeField] Camera tap_camera;//タップを位置判定するカメラ
  
        float trail_z  = 1f;       
        public Vector3 cursor_point { private set; get; }// 現在のポインター位置（マウス、タップでドラッグ）
        public void OnPointer(InputAction.CallbackContext context) {
            if (context.performed) {
                
                Vector2 tmp = context.ReadValue<Vector2>();                             // 位置を取得 (奥行きなし カメラをOrthographicに)
                cursor_point = tap_camera.ScreenToWorldPoint(new Vector3(tmp.x, tmp.y));// 座標変換                
                cursor_point = new Vector3(cursor_point.x, cursor_point.y, trail_z);    // 奥行Zを設定しておく

                //Debug.Log(cursor_point);
            }
        }
     
        [SerializeField] GameObject TouchEffectsPrefab;// タップしたときのエフェクト

        public void OnClick(InputAction.CallbackContext context) {

            if (context.performed) {
                //Debug.Log("クリックした");
                GameObject o = Instantiate(TouchEffectsPrefab);
                o.transform.SetParent(transform);
                o.transform.position = cursor_point;//カーソル位置にEffectを持ってくる
            }
        }
    }
}

