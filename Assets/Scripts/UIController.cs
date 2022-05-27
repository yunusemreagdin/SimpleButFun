using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIController : MonoBehaviour
{
    #region Variables

    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private GameObject _InGameUIPanel;
    [SerializeField] private GameObject _EndGameUIPanel;

    #endregion
    
    //Observer design pattern kullanarak fonksiyonlar olışturuyorum ve daha sonra gerekli yerlerde UI panelleri güncelliyorum
    void Awake()
    {
        TriggerController.OnUpdateScoreUI += UpdateScoreUI;
        TriggerController.OnEndGameUIOpen += OpenEndGameUI;
    }
    

    private void UpdateScoreUI()
    {
        //Topladığımız obje sayısını alıp güncelliyor.
        _scoreText.text = GameData.Instance.Get_Gold().ToString();
    }

    //Oyun sonu UI açma fonksiyonu.
    private void OpenEndGameUI()
    {
        _EndGameUIPanel.SetActive(true);
        _InGameUIPanel.SetActive(false);
    }

    //State değiştirme fonksiyonu
    public void ChangeStateToInGame()
    {
        GameData.Instance.Set_CurrentState(State.State_In_Game);
    }
}
