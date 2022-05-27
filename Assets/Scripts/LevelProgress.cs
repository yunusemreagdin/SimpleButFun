using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LevelProgress : MonoBehaviour
{
    //Singleteon design pattern kullanarak diğer classlardan değişkenlere ulaşıyorum.
    #region Singleton

    private static LevelProgress instance = null;

    public static LevelProgress Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<LevelProgress>();
                if (instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = "SingletonController";
                    instance = go.AddComponent<LevelProgress>();
                    DontDestroyOnLoad(go);
                }
            }

            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private LevelProgress()
    {
        
    }


    #endregion

    #region Variables

    public Image FillBar;
    public TextMeshProUGUI startText;
    public TextMeshProUGUI endText;

    public Transform playerTransform;
    public Transform endTransform;

    public Transform endPosition;
    public float mesafe;

    #endregion
   

    #region Unity Functions
    void Start()
    {
        mesafe = GetDİstance();
        
        startText.text = 1.ToString();
        endText.text = 2.ToString ();
    }
    
    private void Update()
    {
        float newMesafe = GetDİstance();
        float fillValue = Mathf.InverseLerp (mesafe, 0f, newMesafe);
     
        FillProgress (fillValue);    
    }

    #endregion
    

    
    private float GetDİstance()
    {
        //Player ve level sonu arasında ki mesafeyi hesaplıyorum.
        return playerTransform.position.z - endPosition.position.z;
    } 
    private void FillProgress(float value)
    {
        //Level progress varını dolduruyorum.
        FillBar.fillAmount = value;
    }

   
}