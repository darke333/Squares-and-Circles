using System;
using UnityEngine;

namespace SquaresAndCircles.Infrastructure.InputSystem
{
    public interface IInputEvents
    {
        public event Action<Vector2> OnFingerDown;
        public event Action<Vector2> OnFingerPressing;
    }
}