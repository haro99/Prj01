using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//　XNA特有の機能
using Microsoft.Xna.Framework;          //基本機能
using Microsoft.Xna.Framework.Content;  //コンテンツ機能
using Microsoft.Xna.Framework.Graphics; //グラフィック機能
namespace prj01
{
    /// <summary>
    /// 表示（レンダラー）クラス
    /// </summary>
    class Renderer
    {
        //メンバー変数の宣言
        private ContentManager contentManager;     //コンテンツマネージャー
        private SpriteBatch spriteBatch;            //スプライトバッチ
        private GraphicsDevice graphicsDevice;      //グラフィックデバイス
        private Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();   //描画を管理するディクショナリー


        /// <summary>
        /// コンストラクタ（生成時に自動的に呼び出される）
        /// <paramref name="content"></paramref>/>
        /// <paramref name="graphics"></paramref>/>
        /// </summary>
        public Renderer(ContentManager content, GraphicsDevice graphics)
        {
            contentManager = content;                   //コンテンツマネージャー
            contentManager.RootDirectory = "Content";   //ルートの登録
            graphicsDevice = graphics;                  //グラフィックデバイス
            spriteBatch = new SpriteBatch(graphics);    //スプライトバッチ

        }

        /// <summary>
        /// 絵の読み込み
        /// </summary>
        /// <param name="name"></param>
        public void LoadTexture(string name)
        {
            //絵の読み込み
            textures[name] = contentManager.Load<Texture2D>(name);
        }

        /// <summary>
        /// 表示の開始
        /// </summary>
        public void Begin()
        {
            //表示
            spriteBatch.Begin();
        }
        /// <summary>
        /// 表示の終了
        /// </summary>
        public void End()
        {
            //表示の終了
            spriteBatch.End();
        }

        /// <summary>
        /// 絵の表示
        /// </summary>
        /// <param name="name"></param>
        /// <param name="position"></param>
        public void DrawTexture(string name, Vector2 position)
        {
            //絵の表示（絵、座標、色を指定）
            spriteBatch.Draw(textures[name], position, Color.White);
        }

        /// <summary>
        /// 読み込んだ絵の解放
        /// </summary>
        public void Unload()
        {
            textures.Clear();       //テクスチャーの解放
            contentManager.Unload();    //コンテンスマネージャーの解放
        }

        /// <summary>
        /// 数字の表示
        /// </summary>
        /// <param name="name"></param>
        /// <param name="position"></param>
        /// <param name="number"></param>
        /// <param name="digih"></param>
        public void DrawNumber(string name, Vector2 position, int number, int digih)
        {
            //名前（name）、座標（position）、数値（number）、桁数（digit）
            //をパラメーターとしてもらう

            //この処理は1文字の大きさが幅32、高さ64とする

            //マイナスの数は０とする
            if (number < 0)
            {
                number = 0;
            }

            //桁数だけ右へ表示座標を移動する
            position.X += (digih - 1) * 32;

            //桁数をループして、1の位を表示
            for (int i = 0; i < digih; i++)
            {
                //１０で割る余りで、表示する数値を出す。
                int n = number % 10;

                //幅をかけて座標を求め、1文字を絵から切り出して表示
                spriteBatch.Draw(textures[name], position,
                    new Rectangle(n * 32, 0, 32, 64), Color.White);

                //数値を10で割ることで次のけたへ移動する
                number /= 10;
                
                //表示座標のx座標を左へ移動する
                position.X -= 32;
            }
        }
    }
}
