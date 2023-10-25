using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Enum_Sample {
    public class Enum : MonoBehaviour {
        

        [Flags]
        public enum Animal
        {
            [InspectorName("犬")]//enumには使える 通常の変数を日本語にするにはEditorを継承して〜
            Dog = 1 << 0, //0番目に1 0001

            [InspectorName("猫")]
            Cat = 1 << 1, //1番目に1 0010

            [InspectorName("熊")]
            Bear = 1 << 2 //2番目に1 0100
        }
        
        public Animal animalKind;


        [Flags]
        public enum CharacterStates {
            None = 0,      //    0
            Idle = 1,      //    1
            Walking = 2,   //   10
            Running = 4,   //  100
            Jumping = 8,   // 1000
            Crouching = 16,//10000
        }
        public CharacterStates currentState = CharacterStates.None;

        private void Start() {
            Animal myPets = Animal.Dog | Animal.Cat;
            //Animal wildAnimals = Animal.Bear;
            //Animal allAnimals = Animal.Dog | Animal.Cat | Animal.Bear;

            // 特定の動物が含まれているかをチェック
            //論理積（AND演算）//myPets & Animal.Cat　両方真を返す　 0010
            if ((myPets & Animal.Cat) == Animal.Cat) {
                Debug.Log("I have a cat!");
            }

            currentState |= CharacterStates.Idle;//ビット演算子の足し算みたいなもの　論理和 1+1=1　二つの入力のいずか一方あるいは両方が1のとき出力が1
        }


            
     
    }
}

