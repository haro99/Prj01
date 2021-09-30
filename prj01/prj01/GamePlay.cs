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
    /// ゲームプレイクラス
    /// </summary>
    class GamePlay : IScene
    {
        //メンバー変数の宣言
        private Basis player;          //プレイヤー
    

        //ブロックを複数入れるコレクション
        private List<Basis> blocks = new List<Basis>();
        private Basis ball;              //ボール
        private Timer timer;            //タイマー
        private Score score;            //スコア
        private int x = 0, y = 0;                  //敵の配置x,yの間隔
        private bool isEnd;             //終了か？
        private bool clear;             //クリアをしてるか？
        private int ymax;               //敵の段数
        private int seed = 0;           //シード
        private int a = 0;
 
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public GamePlay()
        {
            player = new Player();  //プレイヤー
            //block = new Block();    //ブロック
            ball = new Ball();      //ボール
            timer = new Timer();    //タイマー
            score = new Score();    //スコア

        }

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialize()
        {
            Random rand = new Random(seed++);
            ymax = rand.Next(1, 6);
            //コレクションに敵を追加（ブロックの個数でループ）
            for (int i = 0; i < ymax; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    blocks.Add(new Block());
                }
            }
            player.Initialize();
            //block.Initialize(0);
            //コレクションの中身の初期化
            x = 0;
            y = 0;
            a = 0;
            for (int i = 0; i < ymax; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    
                    blocks[a].Initialize(x, y);     //ブロック
                    a++;
                    x += 130;
                }
                x = 0;
                y += 50;
            }
            ball.Initialize();
            timer.Initialize();
            score.Initialize();
            isEnd = false;  //シーン継続に設定
            clear = false;  //クリアしてないに設定
        }

        /// <summary>
        /// 更新
        /// </summary>
        public void Update()
        {
            //各クラスを更新処理を呼び出す
            player.Update();
            timer.Update();
            //block.Update();
            ball.Update();
            //バーとボールの判定
            if (ball.IsCollision(player) == true)
            {
                ball.Inverted(player);
            }
            else 
            {

            }
            //ブロックとボールの判定
            foreach (var b in blocks)
            {
                if (ball.IsCollision(b) == true)
                {
                    ball.Inverted(b);
                    b.Hit();
                    //衝突したので、スコアを加算する
                    score.Add();
                }
            }
            blocks.RemoveAll(Basis => Basis.IsDead() == true);


            //ゲームタイムが0以下ならば
            if (timer.IsEnd() == true || ball.Over() == true||blocks.Count==0)
            {
                //すべてのブロックを壊したならば
                if (blocks.Count == 0)
                {
                    clear = true;   //クリアしたに設定
                }
                isEnd = true;   //シーン終了に設定
            }
        }
        /// <summary>
        /// 終了か？
        /// </summary>
        /// <returns></returns>
        public bool IsEnd()
        {
            //終了かを返す
            return isEnd;
        }

        public Scene Next()
        {
            blocks.Clear();
            //クリアはしたか？
            if (clear == true)
            {
                //クリアしてないに戻す
                clear = false;
                //次のシーンを返す（クリア）
                return Scene.clear;
            }
            else
            {
                //次のシーンを返す(エンディング)
                return Scene.Ending;
            }
        }
        /// <summary>
        /// 表示
        /// </summary>
        /// <param name="renderer"></param>
        public void Draw(Renderer renderer)
        {
            renderer.DrawTexture("stage", new Vector2(0, 0)); //表示

            //各クラスの表示処理を呼び出す
            player.Draw(renderer);
            //block.Draw(renderer);
            //ブロックのコレクションの表示（敵の個数でループ）
            foreach (var b in blocks)
            {
                b.Draw(renderer);
            }
            ball.Draw(renderer);
            timer.Draw(renderer);   //タイマー
            score.Draw(renderer);   //スコア
        }
    }
}
