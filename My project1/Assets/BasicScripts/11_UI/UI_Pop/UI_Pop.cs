using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace UI_Pop {
    public class ButtonExtension : MonoBehaviour
    {        
        Button button;// 対象のボタン本体

        [Header("クリックした時のアニメーション")]
        
        [SerializeField] float _expand_rate;// 拡大率        
        [SerializeField] Ease ease;// イージング（速度が早いのであんまり意味ないかも）  
        [SerializeField] float expand_time;// 拡大時間        
        [SerializeField] float contract_time;// 戻り時間        
        Vector3 originalScale;// サイズをもとに戻すときのオリジナルサイズ


        void Start() {
            button = GetComponentInChildren<Button>();
            originalScale = button.transform.localScale;

            button.onClick.AddListener(OnClick);
        }

        public void OnClick() {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(button.transform.DOScale(_expand_rate, expand_time)
                .SetRelative()
                .SetEase(ease));
            sequence.Append(button.transform.DOScale(originalScale, contract_time)
                .SetEase(ease));
            sequence.Play();
        }
    }
}
