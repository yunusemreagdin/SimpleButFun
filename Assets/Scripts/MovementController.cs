using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovementController : MonoBehaviour
{
    #region Variables

    private Rigidbody _rigidbody;

    [SerializeField] private float _runSpeed;
    [SerializeField] private float _moveSpeed;

    #endregion
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {
        //Eğer oyun başladıysa basit bir hareket histemi ile karakter sürekli ileri hareket ediyor.
        if (GameData.Instance.Get_CurrentState() == State.State_In_Game)
        {
            float x = Input.GetAxisRaw("Horizontal");
            _rigidbody.velocity = Vector3.forward * _runSpeed;

            if (x != 0)
            {
                _rigidbody.velocity = new Vector3(0, 0, _rigidbody.velocity.z) + Vector3.right * x * _moveSpeed;
            }
        }
        
       
            
    }
}
