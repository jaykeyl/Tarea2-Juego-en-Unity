using TMPro;
using UnityEngine;

public class UIAssigner : MonoBehaviour
{
    public TMP_Text p1Text;
    public TMP_Text p2Text;
    void Start()
    {
        GameManager.Instance.collectiblesTextP1 = p1Text;
        GameManager.Instance.collectiblesTextP2 = p2Text;
        
    }
}