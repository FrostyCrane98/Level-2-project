using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class InputController : MonoBehaviour
{
    public PlayerParams PlayerParams;

    public InputAction HorizontalMoveAction;
    public InputAction Jump;
    public InputAction Slide;
    public InputAction Dash;

    private Rigidbody2D _rigidBody;
    private BoxCollider2D _collider;

    private float _input;
    private float _moveSpeed;

    private bool _hasDoubleJumped = false;
    private bool _isGrounded = true;

    private Vector2 _wallDirection;
    private bool _canWallJump = false;


    #region Unity
    private void OnEnable()
    {
        HorizontalMoveAction.Enable();
        Jump.Enable();
        Slide.Enable();
        Dash.Enable();
        HorizontalMoveAction.started += OnMoveStarted;
        HorizontalMoveAction.canceled += OnMoveEnded;
        Jump.started += OnJumpStarted;
    }

    private void OnDisable()
    {
        HorizontalMoveAction.Disable();
        Jump.Disable();
        Slide.Disable();
        Dash.Disable();
        HorizontalMoveAction.started -= OnMoveStarted;
        HorizontalMoveAction.canceled -= OnMoveEnded;
        Jump.started -= OnJumpStarted;
    }

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
        _moveSpeed = PlayerParams.BaseSpeed;
    }

    private void FixedUpdate()
    {
        //jump mechanics
        JumpReset();
        JumpGravity();

        //run
        Move();
    }
    #endregion

    #region Inputs
    #region Move
    private void OnMoveStarted(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<float>();
    }

    private void OnMoveEnded(InputAction.CallbackContext context)
    {
        _input = 0;
        _rigidBody.velocity = new Vector2(_input, _rigidBody.velocity.y);
    }

    private void Move()
    {
        Vector2 direction = Vector2.right * _input;
        if (WallJumpCheck(direction))
        {
            WallSlide();
        }
        else
        {
        _rigidBody.AddForce(direction * _moveSpeed, ForceMode2D.Impulse);
        _rigidBody.velocity = new Vector2(Mathf.Clamp(_rigidBody.velocity.x, -PlayerParams.MaxSpeed, PlayerParams.MaxSpeed), _rigidBody.velocity.y);
        }
    }

    #endregion
    #region Jump
    private void OnJumpStarted(InputAction.CallbackContext context)
    {
        //first jump
        if (!_hasDoubleJumped && _isGrounded)
        {
            _rigidBody.AddForce(Vector2.up * PlayerParams.JumpForce, ForceMode2D.Impulse);
            _isGrounded = false;
        }
        //double jump
        else if (!_hasDoubleJumped && !_isGrounded && !_canWallJump)
        {
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, 0);
            _rigidBody.AddForce(Vector2.up * PlayerParams.DoubleJumpForce, ForceMode2D.Impulse);
            _hasDoubleJumped = true;
        }
        //walljump
        else if (_canWallJump && !_isGrounded)
        {
            WallJump();
        }
    }

    private void JumpReset()
    {
        RaycastHit2D hit = Physics2D.Raycast(_rigidBody.position + Vector2.down * (_collider.size.y / 2 + 0.01f), Vector2.down);

        if (hit.distance <= 0.01 && _rigidBody.velocity.y <= 0)
        {
            _hasDoubleJumped = false;
            _isGrounded = true;
        }
    }

    private void JumpGravity()
    {
        if (_rigidBody.velocity.y < 0)
        {
            _rigidBody.gravityScale = 3;
        }
        if (_rigidBody.velocity.y >= 1)
        {
            _rigidBody.gravityScale = 1;
        }
    }

    #region WallJump
    private bool WallJumpCheck(Vector2 _direction)
    {
        RaycastHit2D check = Physics2D.Raycast(_rigidBody.position + _direction * (_collider.size.x / 2 + 0.01f), _direction, 0.01f);
        if (check.transform != null && check.transform.gameObject.layer == LayerMask.NameToLayer("World"))
        {
            _wallDirection = _direction;
            _canWallJump = true;
            return true;
        }
        _canWallJump = false;
        return false;
    }

    private void WallSlide()
    {
        _rigidBody.AddForce(Vector2.down * PlayerParams.WallSlideSpeed);
        _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, Mathf.Clamp(_rigidBody.velocity.y, -PlayerParams.WallSlideSpeed, float.MaxValue));
    }

    private void WallJump()
    {
        if (_wallDirection.x < 0)
        {
            Vector2 _wallJumpDirection = (Quaternion.AngleAxis(PlayerParams.WallJumpAngle, Vector3.forward) * -_wallDirection);
            _rigidBody.AddForce(_wallJumpDirection * PlayerParams.WallJumpForce, ForceMode2D.Impulse);
            _rigidBody.velocity = new Vector2(Mathf.Clamp(_rigidBody.velocity.x, -PlayerParams.WallJumpForce, PlayerParams.WallJumpForce), _rigidBody.velocity.y);
        }
        else
        {
            Vector2 _wallJumpDirection = (Quaternion.AngleAxis(-PlayerParams.WallJumpAngle, Vector3.forward) * -_wallDirection);
            _rigidBody.AddForce(_wallJumpDirection * PlayerParams.WallJumpForce, ForceMode2D.Impulse);
            _rigidBody.velocity = new Vector2(Mathf.Clamp(_rigidBody.velocity.x, -PlayerParams.WallJumpForce, PlayerParams.WallJumpForce), _rigidBody.velocity.y);
        }
    }

    #endregion
    #endregion
    #endregion
}
