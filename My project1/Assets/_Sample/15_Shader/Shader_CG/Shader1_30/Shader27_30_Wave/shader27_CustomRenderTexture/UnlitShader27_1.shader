Shader "Unlit/UnlitShader27_1"
{
    Properties
    {
        _S2("PhaseVelocity^2", Range(0.0, 0.5)) = 0.2
        _Attenuation("Attenuation", Range(0.0, 1.0)) = 0.999
        _DeltaUV("Delta UV", Float) = 0.1
    }

    SubShader
    {
        Pass
        {
            CGPROGRAM
            #pragma vertex CustomRenderTextureVertexShader //専用の定義済みvertexシェーダ関数
            #pragma fragment frag

            #include "UnityCustomRenderTexture.cginc" //専用のcgincファイル

            half _S2;
            half _Attenuation;
            float _DeltaUV;
            sampler2D _MainTex;

            float4 frag(v2f_customrendertexture i) : SV_Target
            {
                float2 uv = i.globalTexcoord;//カスタムレンダーテクスチャそのものに関連するテクスチャ座標

                // 1pxあたりの単位を計算する
                float du = 1.0 / _CustomRenderTextureWidth;
                float dv = 1.0 / _CustomRenderTextureHeight;
                float2 duv = float2(du, dv) * _DeltaUV;

                // 現在の位置のテクセルをフェッチ
                float2 c = tex2D(_SelfTexture2D, uv);//テクセル テクスチャ空間の基本単位

                //2回微分　＝  変化量　の変化具合
                // 地点 x = n における x 方向の傾きの変化
                //(u[n+1] - u[n]) - (u[n] - u[n-1]) = u[n+1] + u[n-1] - 2 * u[n]

                //波動方程式  h(t+1) 次の瞬間の波の高さを求める
                //(h(t+1)-h(t))- (h(t)-h(t-1)) = c*c*( (h(x+1) - h(x)) - (h(x) - h(x-1) )  +  (h(y+1) - h(y)) - (h(y) - h(y-1) ) )
                //h(t+1)-2h(t)+h(t-1) = c*c  * (    h(x+1)-2h(x)+h(x-1) + h(y+1)-2h(y)+h(y-1)   )
                //h(t+1) = 2h(t) -h(t-1) + c*c (h(x+1)+h(x-1) + h(y+1)+h(y-1) -2h(x)-2h(y))
                //h(t+1) = 2h - h(t-1) + c(h(x+1)+h(x-1)      + h(y + 1) + h(y - 1) 　　　- 4h)　　　 
                
                //今回、h(t + 1)は次のフレームでの波の高さを表す
                //R,G  (float2の2成分) をそれぞれ高さとして使用
                float k = (2.0 * c.r) - c.g; //2h - h(t - 1) を先に計算
                float p = (k + _S2 * ( //_S2は位相の変化する速度 波動方程式では2乗されてる
                                        tex2D(_SelfTexture2D, uv + duv.x).r +
                                        tex2D(_SelfTexture2D, uv - duv.x).r +
                                        tex2D(_SelfTexture2D, uv + duv.y).r +
                                        tex2D(_SelfTexture2D, uv - duv.y).r - 4.0 * c.r
                                    )
                          ) * _Attenuation; //減衰係数

                // 現在の状態をテクスチャのR成分に、ひとつ前の（過去の）状態をG成分に書き込む。
                return float4(p, c.r, 0, 0);
            }
            ENDCG
        }
    }
}