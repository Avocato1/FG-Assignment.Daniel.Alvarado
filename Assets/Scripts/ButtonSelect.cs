using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ButtonSelect : MonoBehaviour
{
    public Button primaryButton, primaryButton2;
    void Start()
    {
        primaryButton.Select();
    }
    

    public void BackButton()
    {
        EventSystem.current.SetSelectedGameObject(null);
        
        primaryButton.Select();
    }

    public void PlayModeButton()
    {
        EventSystem.current.SetSelectedGameObject(null);
        
        primaryButton2.Select();
    }
}
