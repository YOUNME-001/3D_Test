using UnityEngine;
using UnityEngine.InputSystem;

public class JumpCharcterState : PlayerState, ICharcterState
{
    public JumpCharcterState(PlayerController playerController, Animator animator, PlayerInput playerInput) 
        : base(playerController, animator, playerInput) { }

    public void Enter()
    {
        _animator.SetTrigger(PlayerController.PlayerAniParamJump);
    }

    public void Update()
    {
        // 점프 중에도 카메라 방향으로 회전
        var moveVector = _playerInput.actions["Move"].ReadValue<Vector2>();
        if (moveVector != Vector2.zero)
        {
            Rotate(moveVector.x, moveVector.y);
        }
        
        //Ground Distance 업데이트
        var playerPosition = _playerController.transform.position;
        var distance = CharacterUtility.GetDistanceToGround(playerPosition, Constants.GroundLayerMask,
            10f);
       
        _animator.SetFloat(PlayerController.PlayerAniParamGroundDistance, distance);
        // 광선으로 출력하는 디버그
        Debug.DrawRay(playerPosition, Vector3.down * 10f, Color.red);
    }

    public void Exit()
    {
        
    }
}
