using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//XNAの特有の機能
using Microsoft.Xna.Framework;      //基本機能

namespace prj01
{
    /// <summary>
    /// 基本クラス
    /// </summary>
    class Basis
    {
        //メンバー変数の宣言
        public Vector2 position;     //座標
        protected int radiusx, radiusy;           //半径
        protected float speedx, speedy;       //スピード
        protected string name;          //絵の名前
        protected bool isDead;          //削除判定

        /// <summary>
        /// コンストラクタ
        /// </summary>
        protected Basis(string name, int radiusx, int radiusy)
        {
            this.name = name;   //名前
            this.radiusx = radiusx; //x半径
            this.radiusy = radiusy; //y半径
            isDead = false;         //初期は削除しないに設定

            position = new Vector2(0, 0);
        }

        /// <summary>
        /// 初期化（引数あり）
        /// </summary>
        public virtual void Initialize(int x, int y)
        {

        }

        /// <summary>
        /// 初期化（引数なし）
        /// </summary>
        public virtual void Initialize()
        {

        }

        public virtual void Update()
        {
 
        }
        /// <summary>
        /// 表示
        /// </summary>
        /// <param name="renderer"></param>
        public void Draw(Renderer renderer)
        {
            renderer.DrawTexture(name, position - new Vector2(radiusx, radiusy));
        }

        /// <summary>
        /// 衝突判定
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool IsCollision(Basis other)
        {
            //左、右、上、下の座標を求める
            float left = position.X -radiusx;
            float rigth = position.X +radiusx;
            float up = position.Y-radiusy;
            float down=position.Y+radiusy;

            //持ってきたクラスの左、右、上、下の座標を求める
            float otherLeft = other.position.X - other.radiusx;
            float otherRight = other.position.X + other.radiusx;
            float otherUp = other.position.Y - other.radiusy;
            float otherDown = other.position.Y + other.radiusy;

            //右が相手よりの左より大きく
            //左が相手の右より小さく
            //下が相手の上より大きく
            //上が相手の下より小さければ
            if (rigth>otherLeft&&
                left<otherRight&&
                down>otherUp&&
                up<otherDown)
            {
                return true;    //衝突した

            }
            else
            {
                return false;   //衝突しない
            }
        }

        /// <summary>
        /// ブロックやプレイヤーに当たった方向の判定
        /// </summary>
        /// <param name="other"></param>
        public void Inverted(Basis other)
        {
            //別クラスの左、右、上、下の座標を求める
            float otherLeft = other.position.X - other.radiusx;
            float otherRight = other.position.X + other.radiusx;
            float otherUp = other.position.Y - other.radiusy;
            float otherDown = other.position.Y + radiusy;


            //xとｙの座標でどっちから来てるか調べる
            //ｘのエリア内
            if (position.X > otherLeft &&
                position.X < otherRight)
            {
                //上か下から来た
                speedy *= -1;
            }
            //ｙのエリア内
            else if (position.Y > otherUp &&
                position.Y < otherDown)
            {
                //左か右から来た
                speedx *= -1;
            }
            //角に当たった場合
            else
            {
                //上下左右の範囲外から来た
                speedx *= -1;
                speedy *= -1;
            }

        }

        /// <summary>
        /// 衝突した処理
        /// </summary>
        public void Hit()
        {
            //削除するように設定
            isDead = true;
        }

        /// <summary>
        /// 削除判定を返す
        /// </summary>
        /// <returns></returns>
        public bool IsDead()
        {
            return isDead;
        }

        /// <summary>
        /// 下を越えたか？
        /// </summary>
        /// <returns></returns>
        public bool Over()
        {
            if (position.Y > Screen.Height - radiusy)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
