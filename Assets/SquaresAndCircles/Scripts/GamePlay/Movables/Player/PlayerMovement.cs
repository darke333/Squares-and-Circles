using System;
using System.Collections.Generic;
using SquaresAndCircles.Data;
using SquaresAndCircles.GamePlay.Distance;
using SquaresAndCircles.Infrastructure.AssetProviding;
using SquaresAndCircles.Infrastructure.InputSystem;
using SquaresAndCircles.Services;
using UnityEngine;
using Zenject;

namespace SquaresAndCircles.GamePlay.Movables.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Collider2D     _collider;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private float          _speed;

        private float _startSpeed   => _playerDataProvider.StaticData.StartSpeed;
        private float _endSpeed     => _playerDataProvider.StaticData.EndSpeed;
        private float _acceleration => _playerDataProvider.StaticData.Acceleration;

        private Vector2 target => _movePoints.Peek();

        private IInputProvider                            _inputProvider;
        private Camera                                    _mainCamera;
        private IDistanceSetter                           _distanceSetter;
        private IScreenBounder                            _screenBounder;
        private IAssetProvider<PlayerStaticDataContainer> _playerDataProvider;

        private Queue<Vector2> _movePoints = new();
        private ScreenBounds   _bounds;

        [Inject]
        public void Constructor(IInputProvider inputProvider, Camera mainCamera, IDistanceSetter distanceSetter,
                                IAssetProvider<PlayerStaticDataContainer> playerDataProvider,
                                IScreenBounder screenBounder)
        {
            _inputProvider      = inputProvider;
            _mainCamera         = mainCamera;
            _distanceSetter     = distanceSetter;
            _playerDataProvider = playerDataProvider;
            _screenBounder      = screenBounder;

            _speed = _startSpeed;

            ConnectToEvents();
            SetScreenBounds();
        }

        private void Update()
        {
            Move();
        }

        private void ConnectToEvents()
        {
            _inputProvider.InputEvents.OnFingerDown     += OnFingerDown;
            _inputProvider.InputEvents.OnFingerPressing += OnFingerPressing;
        }

        private void OnFingerPressing(Vector2 pos)
        {
            AddMovingPoints(pos);
        }

        private void OnFingerDown(Vector2 pos)
        {
            CheckIfPlayerPressed(pos);
        }

        private void RestartMovement()
        {
            _movePoints = new Queue<Vector2>();
            _speed      = _startSpeed;
        }

        private void CheckIfPlayerPressed(Vector2 pos)
        {
            Vector2 worldPosition = _mainCamera.ScreenToWorldPoint(pos);

            RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);

            if (hit.collider != null && hit.collider == _collider)
            {
                RestartMovement();
            }
        }

        private void AddMovingPoints(Vector2 pos)
        {
            Vector2 mousePosition = _mainCamera.ScreenToWorldPoint(pos);
            mousePosition = CorrectPosition(mousePosition);
            _movePoints.Enqueue(mousePosition);
        }

        private void Move()
        {
            if (_movePoints.Count > 1)
            {
                transform.position = Vector3.MoveTowards(transform.position, _movePoints.Peek(), _speed);
                if (_speed > _endSpeed)
                {
                    _speed -= _acceleration * Time.deltaTime;
                }

                if (Math.Abs(transform.position.x + transform.position.y - (target.x + target.y)) < 0.05f)
                {
                    _movePoints.Dequeue();
                }

                _distanceSetter.AddDistance(_speed * Time.deltaTime * 100);
            }
            else if (Math.Abs(_speed - _startSpeed) > 0.01)
            {
                _speed = _startSpeed;
            }
        }

        private Vector2 CorrectPosition(Vector2 pos)
        {
            pos.x = Mathf.Clamp(pos.x, _bounds.MinX, _bounds.MaxX);
            pos.y = Mathf.Clamp(pos.y, _bounds.MinY, _bounds.MaxY);
            return pos;
        }

        private void SetScreenBounds()
        {
            _bounds = _screenBounder.GetBounds(_spriteRenderer);
        }
    }
}