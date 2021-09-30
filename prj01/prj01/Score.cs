using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//XNA特有の機能
using Microsoft.Xna.Framework;      //基本機能

namespace prj01
{
    /// <summary>
    /// スコアクラス
    /// </summary>
    class Score
    {
        //メンバー変数の宣言
        private int gameScore;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Score()
        {

        }

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialize()
        {
            //スコアの初期化
            gameScore = 0;
        }

        /// <summary>
        /// 加算
        /// </summary>
        public void Add()
        {
            //スコアの加算
            gameScore += 10;
        }
        /// <summary>
        /// 表示
        /// </summary>
        /// <param name="renderer"></param>
        public void Draw(Renderer renderer)
        {
            //スコア文字の表示（名前と座標を指定）
            renderer.DrawTexture("score", new Vector2(50, 10));

            //スコアの数字表示
            renderer.DrawNumber("number", new Vector2(250, 10), gameScore, 3);
        }
    }
}
