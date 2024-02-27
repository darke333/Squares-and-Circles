using UnityEngine;

namespace SquaresAndCircles.Services
{
    public class ScreenBounder : IScreenBounder, IScreenBounderInstaller
    {
        private Camera _mainCamera;
        
        public void SetCamera(Camera mainCamera)
        {
            _mainCamera = mainCamera;
        }

        public ScreenBounds GetBounds(SpriteRenderer spriteRenderer)
        {
            float objectWidth  = spriteRenderer.bounds.size.x;
            float objectHeight = spriteRenderer.bounds.size.y;

            return new ScreenBounds
            {
                MinX = _mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0)).x + objectWidth / 2,
                MaxX = _mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - objectWidth / 2,
                MinY = _mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0)).y + objectHeight / 2,
                MaxY = _mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y - objectHeight / 2
            };
        }
    }
}