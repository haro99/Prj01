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
    /// ボールクラス
    /// </summary>
    class Ball:Basis
    {
        //メンバー変数の宣言
        //private float speedx, speedy;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Ball()
            : base("ball", 12, 12)
        {

        }

        /// <summary>
        /// 初期化
        /// </summary>
        public override void Initialize()
        {
            //座標の初期化
            position.X = 400;
            position.Y = 400;
            //ボールのスピードの初期化
            speedx = 3f;
            speedy = -3f;

        }

        /// <summary>
        /// 更新
        /// </summary>
        public override void Update()
        {
            Move();
            InScreen();
        }

        /// <summary>
        /// 表示
        /// </summary>
        /// <param name="renderer"></param>

        /// <summary>
        /// 移動
        /// </summary>
        private void Move()
        {
            position.X += speedx;
            position.Y += speedy;
        }
        /// <summary>
        /// 移動範囲の制限
        /// </summary>
        private void InScreen()
        {
            //画面の左
            if (position.X < radiusx)
            {
                speedx *= -1;
            }

            //画面の右
            if (position.X > Screen.Width - radiusx)
            {
                speedx *= -1;
            }
            
            //画面の上
            if (position.Y < radiusy )
            {
                speedy *= -1;
            }
        }


    }
}
