using UnityEngine;
using System;

namespace Sources.Gameplay.Character
{
    public class CharacterMovement : MonoBehaviour
    {
        public event Action<float> MoveComputed;

        private float _speed;

        private float _moveInputX;
        private bool _canLanded;

        private CharacterData _data;
        private Rigidbody2D _rigidbody2D;
        private CharacterInput _input;

        public void Init(CharacterData data, CharacterInput input)
        {
            _data = data;
            _input = input;

            _speed = _data.Speed;

            _rigidbody2D = GetComponent<Rigidbody2D>(); 
        }

        private void Update()
        {
            _moveInputX = ReadMoveInput().x;
            MoveComputed?.Invoke(_moveInputX);
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move() => _rigidbody2D.velocity = new Vector2(_moveInputX * _speed, _rigidbody2D.velocity.y);

        private Vector2 ReadMoveInput() => _input.Movement.Move.ReadValue<Vector2>();
    }
}
