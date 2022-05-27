using System;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    #region Variables

    public static event Action OnUpdateScoreUI;
    public static event Action OnEndGameUIOpen;
    [SerializeField] public List<GameObject> levels;
    [SerializeField] public GameObject point;
    public GameObject anim;

    #endregion
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            //İyi objelere değince gold artıyor ve uı'da güncelliyor.
            GameData.Instance.Set_Gold(GameData.Instance.Get_Gold()+1);
            //Observer ile Puan güncelliyorum.
            OnUpdateScoreUI.Invoke();
            Instantiate(anim, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
        }
        else if(other.CompareTag("CollectableNegative"))
        {
            //Kötü objelere değince gold azalıyor ve uı'da güncelliyor.
            GameData.Instance.Set_Gold(GameData.Instance.Get_Gold()-1);
            //Observer ile Puan güncelliyorum.
            OnUpdateScoreUI.Invoke();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("GameEnd"))
        {
            //Level progress barında ki textleri güncelliyor daha dinamik yapılır normalde prototip olduğu için bu şekilde.
            LevelProgress.Instance.startText.text = "2";
            LevelProgress.Instance.endText.text = "3";

            //State'imi değiştiriyorum.
            GameData.Instance.Set_CurrentState(State.State_End_Game);
            
            //InGame uı kapatıp EndGame UI açılıyor.
            OnEndGameUIOpen.Invoke();
            
        }
    }

    public void TeleportToStart()
    {
        //State'imi değiştiriyorum.
        GameData.Instance.Set_CurrentState(State.State_Before_Start);
        
        //Bulunan leveli kapatıp dizide tuttuğum sonraki leveli açıyorum.
        levels[GameData.Instance.Get_Level()].SetActive(false);
        levels[GameData.Instance.Get_Level() + 1].SetActive(true);
            
        //Karakteri diğer levelin en başına ışınlıyor.
        transform.position = point.transform.position;
    }
}
