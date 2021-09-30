using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//XNA特有の機能
using Microsoft.Xna.Framework;      //基本機能
namespace prj01
{
    /// <summary>
    /// ブロッククラス
    /// </summary>
    class Block:Basis
    {
        //メンバー変数の宣言


        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Block()
            : base("blue", 50, 10)
        {
            //Vector2型の生成
            //変数の初期設定

        }

        /// <summary>
        /// 初期化
        /// </summary>
        public override void Initialize(int x, int y)
        {
            //定位置
            position.X = 150;
            position.Y = 130;
            //ブロックの配置
            position.X += x;
            position.Y += y;
        }

        /// <summary>
        /// 更新
        /// </summary>
        public override void Update()
        {

        }

        /// <summary>
        /// 表示
        /// </summary>
        /// <param name="renderer"></param>
    }
}
