using System.Collections;
using UnityEngine;

public class GoldAnimTimer : MonoBehaviour
{
    //İyi objeleri topladığımızda oluşan animasyonu bir zaman sonra destroy ediyorum.
    void Start()
    {
        StartCoroutine(DestroyIt());
    }
    IEnumerator DestroyIt()
    {
        yield return new WaitForSeconds(.6f);
        Destroy(gameObject);
    }
}