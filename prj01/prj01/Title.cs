using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//XNA特有の機能
using Microsoft.Xna.Framework;      //基本機能
using Microsoft.Xna.Framework.Input;    //入力

namespace prj01
{
    /// <summary>
    /// タイトルクラス
    /// </summary>
    class Title2 : IScene
    {
        //メンバー変数の宣言
        private bool isEnd; //終了か？
        private bool isPressKey; //キーを押したか？

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Title2()
        {
 
        }

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialize()
        {
            isEnd = false;  //シーン継続に設定
            isPressKey = true;  //「押した」に設定
        }

        /// <summary>
        /// 更新
        /// </summary>
        public void Update()
        {
            //スペースキーを押したら
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                //前回が押してなければ
                if (isPressKey == false)
                {
                    isEnd = true;//シーン終了に設定
                }
            }
            else
            {
                isPressKey = false;     //「押してない」に設定
            }
        }

        /// <summary>
        /// 終了か？
        /// </summary>
        /// <returns></returns>
        public bool IsEnd()
        {
            //終了か？を返す
            return isEnd;
        }

        public Scene Next()
        {
            //次のシーンを返す
            return Scene.GamePlay;
        }
        /// <summary>
        /// 表示
        /// </summary>
        /// <param name="renderer"></param>
        public void Draw(Renderer renderer)
        {
            //タイトルの表示
            renderer.DrawTexture("Title2", new Vector2(0, 0));
        }
    }
}
