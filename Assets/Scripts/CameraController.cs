using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Variables

    private GameObject player;
    public float y, z;

    #endregion
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }
    void Update()
    {
        //Player tagine sahip objeyi bulup takip ediyor.Daha smooth şekilde Lerp ile yapılabilir tabii şimdilik böyle bıraktım.
        player = GameObject.FindGameObjectWithTag("Player");
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y+y, player.transform.position.z-z);  
    }
}