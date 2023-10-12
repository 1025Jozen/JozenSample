using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeshSample {
    public class Mesh1 : MonoBehaviour
    {
        [SerializeField] Material material;

        void Start() {
            // 頂点の位置情報
            Vector3[] vertices = {
                new Vector3(-1f, -1f, 0), //0
                new Vector3(-1f,  1f, 0), //1
                new Vector3( 1f,  1f, 0), //2
                new Vector3( 1f, -1f, 0)  //3
            };

            //三角形を作る頂点の順番情報
            int[] triangles = { 0, 1, 2, 0, 2, 3 };

            Mesh mesh      = new Mesh();
            mesh.vertices  = vertices;  //頂点　情報
            mesh.triangles = triangles; //三角形情報　登録

            mesh.RecalculateNormals(); //「面の向き」法線計算 (法線ベクトルの情報はmesh.normalsに入ってる)

            MeshFilter meshFilter       = gameObject.GetComponent<MeshFilter>();
            if (!meshFilter) meshFilter = gameObject.AddComponent<MeshFilter>();//MeshFilterをつける

            MeshRenderer meshRenderer       = gameObject.GetComponent<MeshRenderer>();
            if (!meshRenderer) meshRenderer = gameObject.AddComponent<MeshRenderer>();//MeshRendererをつける

            meshFilter.mesh = mesh;                 //MeshFilterにメッシュを設定
            meshRenderer.sharedMaterial = material; //MeshRendererに表示するマテリアルを設定
        }


    }
}

