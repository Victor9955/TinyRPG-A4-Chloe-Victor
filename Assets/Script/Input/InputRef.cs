using UnityEngine;

[CreateAssetMenu(fileName = "InputRef", menuName = "Scriptable Objects/InputRef")]
public class InputRef : ScriptableObject
{
    Controls controls;
    public Controls.GameActions actions;


    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    void InitInputs()
    {
        controls = new Controls();
        controls.Enable();
        actions = controls.Game;
    }
}
