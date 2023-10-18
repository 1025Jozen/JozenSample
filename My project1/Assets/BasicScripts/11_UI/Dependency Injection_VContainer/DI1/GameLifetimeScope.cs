using VContainer;
using VContainer.Unity;

//このスクリプトをコンポーネントにつける
namespace VContainer1 {
    public class GameLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder) {
            
            builder.Register<GameManager>(Lifetime.Singleton);// シングルトン登録            
            builder.RegisterEntryPoint<GameEntryPoint>();     //エントリーポイント登録
        }
    }
}