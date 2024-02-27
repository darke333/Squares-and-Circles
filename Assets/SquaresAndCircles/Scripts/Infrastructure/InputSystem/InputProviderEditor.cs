using System;
using UniRx;
using UnityEngine;

namespace SquaresAndCircles.Infrastructure.InputSystem
{
    public class InputProviderEditor : IInputEvents
    {
        public event Action<Vector2> OnFingerDown;
        public event Action<Vector2> OnFingerPressing;

        public InputProviderEditor()
        {
            ConnectEvents();
        }

        private void ConnectEvents()
        {
            Observable.EveryUpdate()
                      .Subscribe(_ =>
                      {
                          if (Input.GetButtonDown("Fire1"))
                              OnFingerDown?.Invoke(Input.mousePosition);

                          if (Input.GetButton("Fire1"))
                              OnFingerPressing?.Invoke(Input.mousePosition);
                      });
        }
    }
}