using DoodleShader.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;

namespace DoodleShader
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class NezGame : Core
    {

        public const int designWidth = 1280;
        public const int designHeight = 720;

        public NezGame() :base (designWidth, designHeight, windowTitle: "DOOOODLE SHADER")
        {
            Scene.setDefaultDesignResolution(designWidth, designHeight, Scene.SceneResolutionPolicy.BestFit, 0, 0);
            Window.AllowUserResizing = true;
            // weird thing I'm required to do running Windows on a retina Macbook (¯\_(ツ)_/¯)
            Window.Position = new Point(0, 0);
        }

        protected override void Initialize()
        {
            base.Initialize();
            // little hack to fix some potential bugs with post processing effects
            scene = Scene.createWithDefaultRenderer();
            base.Update(new GameTime());
            base.Draw(new GameTime());
            // load your actual scene
            scene = new TestScene();
        }
    }
}
