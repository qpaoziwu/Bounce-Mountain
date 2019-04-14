using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSound : MonoBehaviour, IPointerEnterHandler
{
    [FMODUnity.EventRef]
    public string buttonHighlightEvent;
    [FMODUnity.EventRef]
    public string buttonClickEvent;

    Button thisButton;



    // Start is called before the first frame update
    void Awake()
    {
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(OnTaskClicked);
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    void OnTaskClicked()
    {
        FMODUnity.RuntimeManager.PlayOneShot(buttonClickEvent);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        FMODUnity.RuntimeManager.PlayOneShot(buttonHighlightEvent);
    }
}
