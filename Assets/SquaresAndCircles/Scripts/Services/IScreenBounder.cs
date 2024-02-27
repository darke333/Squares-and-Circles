using UnityEngine;

namespace SquaresAndCircles.Services
{
    public interface IScreenBounder
    {
        public ScreenBounds GetBounds(SpriteRenderer spriteRenderer);
    }
}