using System;
using System.Collections.Generic;
using UnityEngine;

namespace Value_and_Reference2
{
    public class Sample2 : MonoBehaviour
    {
        void Start() {
            // 参照型の例
            List<string> list1 = new List<string> { "A", "B", "C" };
            List<string> list2 = list1;
            list2[0] = "X";
            Debug.Log(list1[0]);

            // 値型の例
            int num1 = 42;
            int num2 = num1;
            num2 = 100;
            Debug.Log(num1);


            GameObject obj1 = new GameObject("Object 1");
            GameObject obj2 = obj1;
            obj2.name = "Object 2";
            Debug.Log(obj1.name);






            int val1 = 5;
            int val2 = 5;

            ModifyValue(val1);
            ModifyReference(ref val2);

            Debug.Log("Value Type (val1): " + val1);
            Debug.Log("Reference Type (val2): " + val2);
        }


        static void ModifyValue(int value) {
            value = 10;
        }

        static void ModifyReference(ref int value) {
            value = 10;
        }
    }
}