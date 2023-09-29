//#define cryptography

using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

namespace JSON
{
    public class Json_ReadWrite : MonoBehaviour
    {
        string datapath;
        public PlayerData playerData { get; private set; }

        private void Awake() {
            datapath   = Application.dataPath + "/BasicScripts/Data/JSON" + "/TestJson.json";//初めに保存先を計算する
        }


        bool jsonWrite = true;
        bool jsonRead = false;


        private void Update() {

            //書き込んでから読み込み　　　書き込み済みなら読み込み
            if (jsonWrite && Input.GetKey(KeyCode.W)) {//書き込み
                jsonWrite = false;
                jsonRead = true;
                JsonWrite();                 
            }
            if (jsonRead && Input.GetKey(KeyCode.R)) {//読み込み
                jsonWrite = true;
                jsonRead = false;
                playerData = JsonRead();                
            }
        }

//Jsonファイルを書き出す
        public void JsonWrite() {
            PlayerData player1 = new PlayerData();
            player1.name    = "タカシ";
            player1.hp      = 300;
            player1.attack  = 15;
            player1.defense = 3;


            //辞書型は無視される
            player1.playerStatus = new Dictionary<PlayerMode, PlayerStatus>();
            PlayerStatus playerStatus1 = new PlayerStatus();
            playerStatus1.speed = 2.5f;
            player1.playerStatus.Add(PlayerMode.hard, playerStatus1);


            player1.item = new Item();
            player1.item.itemName = "アイテム名";

            player1.itemList = new List<Item>();
            Item item = new Item();
            item.itemName = "アイテムリストから追加";
            player1.itemList.Add(item) ;

            
            SaveTest(player1);//

            //string jsondata = JsonUtility.ToJson(player1); //JSONデータはC#上で文字列として扱う
        }

#if cryptography
        public void SaveTest(PlayerData player) {//セーブのメソッド
            string jsonstr = JsonUtility.ToJson(player);//受け取ったPlayerDataをJSONに変換
            string jsonText = AES.Encrypt(jsonstr);//暗号化
            StreamWriter writer = new StreamWriter(datapath, false, Encoding.UTF8);//初めに指定したデータの保存先を開く
            writer.WriteLine(jsonText);//JSONデータを書き込み
            writer.Flush();//バッファをクリアする
            writer.Close();//ファイルをクローズする
            Debug.Log("暗号あり　書き込んだ");
        }
#else
        public void SaveTest(PlayerData player) {//セーブのメソッド
            string jsonText = JsonUtility.ToJson(player);//受け取ったPlayerDataをJSONに変換
           
            StreamWriter writer = new StreamWriter(datapath, false, Encoding.UTF8);//初めに指定したデータの保存先を開く
            writer.WriteLine(jsonText);//JSONデータを書き込み
            writer.Flush();//バッファをクリアする
            writer.Close();//ファイルをクローズする
            Debug.Log("暗号なし　書き込んだ");
        }
#endif




//Jsonファイルを読み込む
        public PlayerData JsonRead() {
            PlayerData player2 = LoadTest(datapath);
            Debug.Log("名前:" + player2.name + " HP:" + player2.hp + " Attack:" + player2.attack + " Defense:" + player2.defense);
            return LoadTest(datapath);
        }
#if cryptography
        public PlayerData LoadTest(string dataPath) {
            StreamReader reader = new StreamReader(dataPath, Encoding.UTF8); //受け取ったパスのファイルを読み込む
            string jsonstr = reader.ReadToEnd();             //ファイルの中身をすべて読み込む
            string jsonText = AES.Decrypt(jsonstr);//複合化
            reader.Close();//ファイルを閉じる
            Debug.Log("暗号あり　読み込んだ");
            return JsonUtility.FromJson<PlayerData>(jsonText);//読み込んだJSONファイルをPlayerData型に変換して返す
        }
#else
        public PlayerData LoadTest(string dataPath) {
            StreamReader reader = new StreamReader(dataPath, Encoding.UTF8); //受け取ったパスのファイルを読み込む
            string jsonText = reader.ReadToEnd();             //ファイルの中身をすべて読み込む            
            reader.Close();//ファイルを閉じる
            Debug.Log("暗号なし　読み込んだ");
            return JsonUtility.FromJson<PlayerData>(jsonText);//読み込んだJSONファイルをPlayerData型に変換して返す
        }
#endif

    }
}

