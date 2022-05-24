using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Canvas))]
public class UI_Element : MonoBehaviour
{
    [SerializeField] private List<UI_Element> childrenUI;
    private UI_Element parentUI = null;

    private Canvas mainCanvas;

    private void Awake()
    {
        foreach (UI_Element element in childrenUI)
        {
            element.InitializeParentUI(this);
        }

        mainCanvas = GetComponent<Canvas>();
    }

    protected void OnEnable()
    {
        Open();
    }

    protected void OnDisable()
    {
        Close();
    }

    public void InitializeParentUI(UI_Element parent)
    {
        this.parentUI = parent;
    }

    protected virtual void Close()
    {
        foreach (UI_Element element in childrenUI)
        {
            element.Close();
        }
    }

    protected virtual void Open()
    {
    }
}
