using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using QR_game.Objects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR_game.Drawing
{
    public class AnimatedSprite : Sprite
    {
        public AnimatedSprite(Texture2D texture, int frameWidth = 32, int frameHeight = 32, Dictionary<string, List<int>> animations = null) : 
            base(texture, frameWidth, frameHeight)
        {
            this._animations = animations;
        }

        public AnimatedSprite(Texture2D texture, Rectangle?[] sourceRectangles, int frameWidth = -1, int frameHeight = -1) : 
            base(texture, sourceRectangles, frameWidth, frameHeight)
        {
        }

        public override void Update()
        {
            base.Update();
            if (_currentAnimationName == "")
                return;
            if (Timer < 0)
            {
                Timer = TimerDuration;
                NextFrame();
            }
            else
            {
                Timer -= 0.1f;
            }
        }

        public override void Draw(GameObj from)
        {
            base.Draw(from);
        }

        private void NextFrame()
        {
            if (_currentAnimation.Count > _currentAnimationIndex)
            {
                _frameIndex = _currentAnimation[_currentAnimationIndex];
                _currentAnimationIndex++;
            }
            else
            {
                _currentAnimationIndex = 0;
                _frameIndex = _currentAnimation[_currentAnimationIndex];
            }
        }

        public void SetAnimation(string name)
        {
            if (name == _currentAnimationName)
                return;
            _currentAnimationIndex = 0;
            _currentAnimationName = name;
            _currentAnimation = _animations[_currentAnimationName];
        }

        protected float Timer
        {
            get; set;
        } = 1f;

        public float TimerDuration
        {
            get; set;
        } = 1f;


        private Dictionary<string, List<int>> _animations;
        private string _currentAnimationName = string.Empty;
        private List<int> _currentAnimation = new List<int>();
        private int _currentAnimationIndex = 0;
    }
}
