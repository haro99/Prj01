using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prj01
{
    /// <summary>
    /// 画面サイズ
    /// </summary>
    static class Screen
    {
        public const int Width = 800;   //幅
        public const int Height = 600;  //高さ
    }
    interface IScene
    {
        //初期化
        void Initialize();

        //更新
        void Update();

        //表示
        void Draw(Renderer renderer);

        //終了か？
        bool IsEnd();

        //次のシーンへ
        Scene Next();
    }
    //シーンの名前
    public enum Scene
    {
        Title2,      //タイトル
        GamePlay,   //ゲームプレイ
        Ending,     //エンディング
        clear       //ゲームクリア
    }
}
