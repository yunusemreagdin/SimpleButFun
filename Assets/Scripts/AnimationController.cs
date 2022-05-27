using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    #region Variables

    [SerializeField] private Animator _animator;

    #endregion
    
    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        //Oyun başladıysa animasyon değişiyor.
        if (GameData.Instance.Get_CurrentState() == State.State_In_Game)
        {
            _animator.SetBool("Idle", false);
            _animator.SetBool("Running", true);
        }else if (GameData.Instance.Get_CurrentState() == State.State_Before_Start || GameData.Instance.Get_CurrentState() == State.State_End_Game)
        {
            //Oyun balamadıysa veya oyun bittiyse animasyon değişiyor.
            _animator.SetBool("Running",false); 
            _animator.SetBool("Idle",true);
            
        }
    }
}
