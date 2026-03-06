using UnityEngine;
using UnityEngine.InputSystem;

public class IdlePlayerState : PlayerState, IPlayerState
{
    public IdlePlayerState(PlayerController playerController, Animator animator, PlayerInput playerInput): 
    base(playerController,  animator, playerInput ) { }


    public void Enter()
    {
        //Idle애니메이션 실행
        
    }

    public void Update()
    {
        if (_playerInput.actions["Move"].IsPressed())
        {
            _playerController.SetState(PlayerController.EPlayerState.Move);
        }
    }

    public void Exit()
    {
        Debug.Log("## Idle Exit");
    }
}
