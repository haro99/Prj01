using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//XNA特有の機能
using Microsoft.Xna.Framework;      //基本機能

namespace prj01
{
    /// <summary>
    /// シーンマネージャー
    /// </summary>
    class SceneManager
    {
        //メンバー変数の宣言
        private IScene currentscene = null; //現在のシーン

        private Dictionary<Scene, IScene> scenes = new Dictionary<Scene, IScene>();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SceneManager()
        {
            //クラスの生成
        }

        /// <summary>
        /// シーンクラスの登録
        /// </summary>
        /// <param name="name"></param>
        /// <param name="scene"></param>
        public void Add(Scene name, IScene scene)
        {
            //渡されたシーンをコレクションに登録する
            scenes[name] = scene;
        }

        /// <summary>
        /// 変更
        /// </summary>
        /// <param name="name"></param>
        public void Change(Scene name)
        {
            //渡されたシーンを現在のシーンの登録する
            currentscene = scenes[name];

            //現在のシーンの初期化
            currentscene.Initialize();
        }
        /// <summary>
        /// 更新
        /// </summary>
        public void Update()
        {
            //更新
            currentscene.Update();  //現在のシーン

            //シーンが終了ならば
            if (currentscene.IsEnd() == true)
            {
                Change(currentscene.Next());
            }
        }

        /// <summary>
        /// 表示
        /// </summary>
        /// <param name="renderer"></param>
        public void Draw(Renderer renderer)
        {
            if (currentscene == scenes[Scene.Ending]||currentscene ==scenes[Scene.clear])
            {
                scenes[Scene.GamePlay].Draw(renderer);
            }
            //現在のシーンの表示
            currentscene.Draw(renderer);
        }
    }
}
