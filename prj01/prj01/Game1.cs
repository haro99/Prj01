using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace prj01
{
    /// <summary>
    /// 基底 Game クラスから派生した、ゲームのメイン クラスです。
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        //メンバー変数の宣言
        GraphicsDeviceManager graphics;     //グラフィックデバイス
        private Renderer renderer;      //レンダラー（表示）クラス

        private SceneManager sceneManager;      //シーンマネージャー

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            sceneManager = new SceneManager();  //シーンマネージャー

            //画面サイズ
            graphics.PreferredBackBufferWidth = Screen.Width;
            graphics.PreferredBackBufferHeight = Screen.Height;

            //クラスの生成

            //初期化
        }

        /// <summary>
        /// ゲームが実行を開始する前に必要な初期化を行います。
        /// ここで、必要なサービスを照会して、関連するグラフィック以外のコンテンツを
        /// 読み込むことができます。base.Initialize を呼び出すと、使用するすべての
        /// コンポーネントが列挙されるとともに、初期化されます。
        /// </summary>
        protected override void Initialize()
        {
            // TODO: ここに初期化ロジックを追加します。

            //左上のタイトルの指定
            base.Window.Title = "ブロック崩し";
            //クラスの生成
            renderer = new Renderer(Content, GraphicsDevice);

            //シーンクラスの登録
            sceneManager.Add(Scene.Title2, new Title2());    //タイトル 
            sceneManager.Add(Scene.GamePlay, new GamePlay()); //ゲームプレイ
            sceneManager.Add(Scene.Ending, new Ending());   //エンディング
            sceneManager.Add(Scene.clear, new Clear());     //クリア

            //最初のシーンへ変更
            sceneManager.Change(Scene.Title2);
            //初期化
            base.Initialize();
        }

        /// <summary>
        /// LoadContent はゲームごとに 1 回呼び出され、ここですべてのコンテンツを
        /// 読み込みます。（ロード）
        /// </summary>
        protected override void LoadContent()
        {
            // TODO: this.Content クラスを使用して、ゲームのコンテンツを読み込みます。
            //絵の読み込み
            renderer.LoadTexture("stage");
            renderer.LoadTexture("bar");
            renderer.LoadTexture("blue");
            renderer.LoadTexture("ball");
            renderer.LoadTexture("timer");
            renderer.LoadTexture("score");
            renderer.LoadTexture("number");
            renderer.LoadTexture("Title2");
            renderer.LoadTexture("clear");
            renderer.LoadTexture("ending");

        }

        /// <summary>
        /// UnloadContent はゲームごとに 1 回呼び出され、ここですべてのコンテンツを
        /// アンロードします。
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: ここで ContentManager 以外のすべてのコンテンツをアンロードします。
            renderer.Unload();
        }

        /// <summary>
        /// ワールドの更新、衝突判定、入力値の取得、オーディオの再生などの
        /// ゲーム ロジックを、実行します。
        /// </summary>
        /// <param name="gameTime">ゲームの瞬間的なタイミング情報</param>
        protected override void Update(GameTime gameTime)
        {
            // ゲームの終了条件をチェックします。
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
                ||Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            // TODO: ここにゲームのアップデート ロジックを追加します。

            //各クラスの更新処理を呼び出す

            sceneManager.Update();      //シーンマネージャー
            base.Update(gameTime);
        }

        /// <summary>
        /// ゲームが自身を描画するためのメソッドです。
        /// </summary>
        /// <param name="gameTime">ゲームの瞬間的なタイミング情報</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: ここに描画コードを追加します。
            renderer.Begin();       //表示の開始

            sceneManager.Draw(renderer);    //シーンマネージャー
            renderer.End();         //表示の終了
            base.Draw(gameTime);
        }
    }
}
