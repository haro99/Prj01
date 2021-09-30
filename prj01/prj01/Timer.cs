using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//XNA特有の機能
using Microsoft.Xna.Framework;      //基本機能

namespace prj01
{
    /// <summary>
    /// タイマークラス
    /// </summary>
    class Timer
    {
        //メンバー変数の宣言
        private int gameTime;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Timer()
        {
 
        }

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialize()
        {
            //タイマーの初期化
            gameTime = 60 * 300;
        }

        /// <summary>
        /// 更新
        /// </summary>
        public void Update()
        {
            //タイマーが減る
            gameTime -= 1;
        }

        /// <summary>
        /// 終了か？
        /// </summary>
        /// <returns></returns>
        public bool IsEnd()
        {

            if (gameTime <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 表示
        /// </summary>
        /// <param name="renderer"></param>
        public void Draw(Renderer renderer)
        {
            //タイマー文字の表示（名前と座標を指定）
            renderer.DrawTexture("timer", new Vector2(450, 10));

            //タイマーの数字表示
            renderer.DrawNumber("number", new Vector2(650, 13), gameTime / 60, 3);
        }
    }
}
