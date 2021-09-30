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
    /// プレイヤークラス
    /// </summary>
    class Player:Basis
    {
        //メンバー変数の宣言


        /// <summary>
        /// コンストラクタ（生成時に自動的に呼び出される）
        /// </summary>
        public Player()
            : base("bar", 50, 5)
        {
            //position = new Vector2(400, 550);

        }
        /// <summary>
        /// 初期化
        /// </summary>
        public override void Initialize()
        {
            //座標の初期化
            position.X = 400;
            position.Y = 550;
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
        private void Move()     //移動
        {
            //右を推したら、右へ移動
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                position.X +=5;
            }

            //左を押したら、左へ移動
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                position.X -= 5;
            }
        }

        /// <summary>
        /// 移動範囲の制限
        /// </summary>
        private void InScreen()
        {
            //画面の左
            if (position.X < radiusx)
            {
                position.X = radiusx;
            }

            //画面の右
            if (position.X > Screen.Width - radiusx)
            {
                position.X = Screen.Width - radiusx;
            }

            
            //最小値の設定
            Vector2 min = new Vector2(radiusx, 0);

            //最大値の制限
            Vector2 max = new Vector2(Screen.Width, 600);

            //範囲の制限
            position = Vector2.Clamp(position, min, max);
        }
    }
}
