using System;
using UnityEngine;

namespace PlayerSpace
{
       public class Player : MonoBehaviour
    {
        [Header("Movement")] [SerializeField] private float _speed = 1f;
        [SerializeField] private float _jumpForce = 10f;
        [SerializeField] private int _lives = 5;
        
        [Header("CollisionInfo")]
        [SerializeField] private Transform _checkTransform;
        [SerializeField] private float _groundCheckRadius;
        [SerializeField] private LayerMask _groundLayerMask;
        internal bool _isGrounded;
        internal bool _isDoubleGround;
        //private bool _doubleJump = false;
    
        private bool _isMoving;
        private bool _isFlip = true;
    
        private Rigidbody2D _rb;
        
        private MovementController _movementController;
    
        private Animator _animator;
    
        void Start()
        {
             _movementController = GetComponent<MovementController>();
            _rb = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }
    
        private void Update()
        {
            _isMoving = _rb.velocity.x != 0;
            _animator.SetBool("isMove", _isMoving);
            _animator.SetBool("isGrounded", _isGrounded);
            _animator.SetFloat("velocityY",_rb.velocity.y);
    
            Flip();
           // if (_isGrounded && Input.GetButtonDown("Jump"))
            CollisionCheck();
            
           //if (Input.GetButtonDown("Jump"))
                Jump(); 
        }
        
        private void FixedUpdate()
        { 
            _rb.velocity = new Vector2(x: _movementController._moveInput * _speed, _rb.velocity.y);
        }
        
        internal void Jump()
        {
            if (_isGrounded)
            {
                _rb.velocity = new Vector2(_rb.velocity.x, y: _jumpForce);
            }
            else if(_isDoubleGround)
            {
                _isDoubleGround = false;
                _rb.velocity = new Vector2(_rb.velocity.x, y: _jumpForce);
            }
        }
    
        private void CollisionCheck()
        { 
            _isGrounded = Physics2D.OverlapCircle((Vector2)_checkTransform.position, _groundCheckRadius, _groundLayerMask);
        }

       /* private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(_checkTransform.position, _groundCheckRadius);
        }
*/
        private void Flip()
        {
            if ((_rb.velocity.x > 0 && !_isFlip) || (_rb.velocity.x < 0 && _isFlip))
            {
                _isFlip = !_isFlip;
                transform.Rotate(0,180,0);
            }
        }

        
    }
}