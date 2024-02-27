using System;
using UniRx;
using UnityEngine;

namespace SquaresAndCircles.Infrastructure.InputSystem
{
    public class InputProviderMobile : IInputEvents
    {
        public event Action<Vector2> OnFingerDown;
        public event Action<Vector2> OnFingerPressing;

        public InputProviderMobile()
        {
            ConnectEvents();
        }

        private void ConnectEvents()
        {
            Observable.EveryUpdate()
                      .Subscribe(_ =>
                      {
                          if (Input.touchCount > 0)
                          {
                              Touch touch = Input.GetTouch(0);

                              if (touch.phase == TouchPhase.Began)
                                  OnFingerDown?.Invoke(touch.position);

                              if (touch.phase == TouchPhase.Moved)
                                  OnFingerPressing?.Invoke(touch.position);
                          }
                      });
        }
    }
}