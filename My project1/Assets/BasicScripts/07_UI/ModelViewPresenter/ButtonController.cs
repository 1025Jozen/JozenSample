using UnityEngine;
using TMPro;


namespace MVP {
    ////ボタンのOnclickイベントに登録する方法
    public class ButtonController : MonoBehaviour
    {
        [SerializeField] TMP_InputField inputField;
        [SerializeField] TextPresenter presenter;

        public void OnButtonClick() {
            string newText = inputField.text;//入力してもらう
            presenter.UpdateText(newText);   //操作スクリプトに渡して実行
        }
    }



    //using UnityEngine.UI;
    ////スクリプト側にボタンのアドレスを持たせる方法
    //public class ButtonController : MonoBehaviour
    //{
    //    public TMP_InputField inputField;
    //    public Button buttonToClick;
    //    public TextPresenter presenter;

    //    private void Start() {
    //        // ボタンのUnity Eventにメソッドを追加
    //        buttonToClick.onClick.AddListener(OnClick);
    //    }

    //    private void OnClick() {
    //        string newText = inputField.text;//入力してもらう
    //        presenter.UpdateText(newText);   //操作スクリプトに渡して実行
    //    }
    //}
}

