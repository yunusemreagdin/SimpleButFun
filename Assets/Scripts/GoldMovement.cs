using UnityEngine;

public class GoldMovement : MonoBehaviour
{
    public GameObject goldAnim;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //İyi objeleri toladığımızda oynatılan animasyon.
            GameObject goldAnimTemp = Instantiate(goldAnim, new Vector3(0,-50,0), new Quaternion(0, 0, 0, 0));
            goldAnimTemp.transform.SetParent(GameObject.FindGameObjectWithTag("Respawn").transform);
            Destroy(gameObject);
        }
    }
}
