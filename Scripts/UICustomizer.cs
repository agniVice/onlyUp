using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICustomizer : MonoBehaviour
{
    [SerializeField] private Transform _joystickMove;
    [SerializeField] private Transform _joystickLook;
    [SerializeField] private Transform _buttonJump;

    [SerializeField] private Transform _realMove;
    [SerializeField] private Transform _realLock;
    [SerializeField] private Transform _realJump;

    [SerializeField] private Vector2 _defaultJoystickMove;
    [SerializeField] private Vector2 _defaultJoystickLook;
    [SerializeField] private Vector2 _defaultJump;

    [SerializeField] private GameObject _hud;
    [SerializeField] private GameObject _editor;

    private void Start()
    {
        //if(Игра на телефоне)
        //{
        //    CloseEditor();
        //    
        //    _defaultJump = _realJump.position;
        //    _defaultJoystickLook = _realLock.position;
        //    _defaultJoystickMove = _realMove.position;
        //    
        //    Init();
        //}
        //else
        //    ничего не делать
    }
    private void Init()
    {
        _joystickMove.position = new Vector2(PlayerPrefs.GetInt("JoystickMoveX", Mathf.RoundToInt(_defaultJoystickMove.x)), PlayerPrefs.GetInt("JoystickMoveY", Mathf.RoundToInt(_defaultJoystickMove.y)));
        _joystickLook.position = new Vector2(PlayerPrefs.GetInt("JoystickLookX", Mathf.RoundToInt(_defaultJoystickLook.x)), PlayerPrefs.GetInt("JoystickLookY", Mathf.RoundToInt(_defaultJoystickLook.y)));
        _buttonJump.position = new Vector2(PlayerPrefs.GetInt("JumpX", Mathf.RoundToInt(_defaultJump.x)), PlayerPrefs.GetInt("JumpY", Mathf.RoundToInt(_defaultJump.y)));

        _realMove.position = new Vector2(PlayerPrefs.GetInt("JoystickMoveX", Mathf.RoundToInt(_defaultJoystickMove.x)), PlayerPrefs.GetInt("JoystickMoveY", Mathf.RoundToInt(_defaultJoystickMove.y)));
        _realLock.position = new Vector2(PlayerPrefs.GetInt("JoystickLookX", Mathf.RoundToInt(_defaultJoystickLook.x)), PlayerPrefs.GetInt("JoystickLookY", Mathf.RoundToInt(_defaultJoystickLook.y)));
        _realJump.position = new Vector2(PlayerPrefs.GetInt("JumpX", Mathf.RoundToInt(_defaultJump.x)), PlayerPrefs.GetInt("JumpY", Mathf.RoundToInt(_defaultJump.y)));
    }
    public void OpenEditor()
    {
        _hud.SetActive(false);
        _editor.SetActive(true);
    }
    public void CloseEditor()
    {
        _hud.SetActive(true);
        _editor.SetActive(false);
    }
    public void SaveCustomization()
    {
        PlayerPrefs.SetInt("JoystickMoveX", Mathf.RoundToInt(_joystickMove.position.x));
        PlayerPrefs.SetInt("JoystickMoveY", Mathf.RoundToInt(_joystickMove.position.y));

        PlayerPrefs.SetInt("JoystickLookX", Mathf.RoundToInt(_joystickLook.position.x));
        PlayerPrefs.SetInt("JoystickLookY", Mathf.RoundToInt(_joystickLook.position.y));

        PlayerPrefs.SetInt("JumpX", Mathf.RoundToInt(_buttonJump.position.x));
        PlayerPrefs.SetInt("JumpY", Mathf.RoundToInt(_buttonJump.position.y));

        Init();
    }
    public void DefaultSettings()
    {
        _joystickMove.position = _defaultJoystickMove;
        _joystickLook.position = _defaultJoystickLook;
        _buttonJump.position = _defaultJump;

        SaveCustomization();
    }
}
