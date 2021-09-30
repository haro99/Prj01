using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//XNA特有の機能
using Microsoft.Xna.Framework;          //基本機能
using Microsoft.Xna.Framework.Input;    //入力
namespace prj01
{
    /// <summary>
    /// クリアクラス
    /// </summary>
    class Clear:IScene
    {
        //メンバー変数の宣言
        private bool isEnd;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Clear()
        {
 
        }

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialize()
        {
            isEnd = false;  //シーン継続に設定
        }

        /// <summary>
        /// 更新
        /// </summary>
        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                isEnd = true;       //シーン終了に設定
            }
        }

        /// <summary>
        /// 終了
        /// </summary>
        /// <returns></returns>
        public bool IsEnd()
        {
            //終了か？を返す
            return isEnd;
        }

        /// <summary>
        /// 次のシーンを返す
        /// </summary>
        /// <returns></returns>
        public Scene Next()
        {
            //次のシーンを返す（タイトル）
            return Scene.Title2;
        }
        public void Draw(Renderer renderer)
        {
            //clearの表示（名前と座標を指定）
            renderer.DrawTexture("clear", new Vector2(110, 200));
        }
    }
}
