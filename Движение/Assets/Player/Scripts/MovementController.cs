using UnityEngine;

namespace PlayerSpace
{
    public class MovementController : MonoBehaviour
    {
        internal float _moveInput;
        private Player _player;

        private void Start()
        {
            _player = GetComponent<Player>();
        }
        private void Update()
        {
             _moveInput = Input.GetAxis("Horizontal");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _player.Jump();
            }

            if (_player._isGrounded)
            {
                _player._isDoubleGround = true;
            }
        }
    }
}