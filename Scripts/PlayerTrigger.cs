using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class PlayerTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _lastObject;
    [SerializeField] private ThirdPersonController _controller;
    public LayerMask layer;
    public LayerMask layerr;
    private bool _isWin;
    public Joystick fixedJoystick;

    public StarterAssetsInputs starterAssets;
    public ParticleSystem[] particleSystems;
    public GameObject CanvasGetBack;
    public GameObject HUD;
    public GameObject CanvasRewardedException;
    public Timer timer;

    private void OnEnable()
    {
    }
    private void OnDisable()
    {
    }
    private void Start()
    {
        CanvasGetBack.SetActive(false);
    }
    public void SpawnOnLastObject()
    {
        Time.timeScale = 1f;
        _controller._controller.enabled = false;
        if (GetPosToSpawn() != Vector3.zero)
        {
            _controller._verticalVelocity = 0.01f;
            _controller.gameObject.transform.position = GetPosToSpawn() + Vector3.up;
            fixedJoystick.input = Vector2.zero;
        }
        _controller._controller.enabled = true;

    }
    private void OnReward()
    {
        SpawnOnLastObject();
        CanvasGetBack.SetActive(false);
        HUD.SetActive(true);
    }
    private void OnRewardFailed()
    {
        CanvasGetBack.SetActive(false);
        HUD.SetActive(true);
    }
    private Vector3 GetPosToSpawn()
    {
        RaycastHit hit;
        if (_lastObject == null)
            return Vector3.zero;
        _lastObject.layer = 7;
        Physics.Linecast(_lastObject.transform.position + Vector3.up * 100f, _lastObject.transform.position, out hit, layerr);
        if (hit.collider != null)
        {
            _lastObject.layer = 6;
            return hit.point;
        }
        _lastObject.layer = 6;
        return Vector3.zero;
    }
    public void ShowAd()
    {
        //
    }
    public void CloseCanvas()
    {
        Time.timeScale = 1f;
        fixedJoystick.input = Vector2.zero;
        HUD.SetActive(true);
        CanvasGetBack.SetActive(false);
        CanvasRewardedException.SetActive(false);
    }
    public void ShowRewardedException()
    {
        CanvasGetBack.SetActive(false);
        CanvasRewardedException.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "TriggerGetBack")
        {
            if (_lastObject == null)
                return;
            if (Vector3.Distance(_controller.gameObject.transform.position, _lastObject.transform.position) >= 20f)
            {
                if (GetPosToSpawn() != Vector3.zero)
                {
                    HUD.SetActive(false);
                    CanvasGetBack.SetActive(true);
                    Time.timeScale = 0f;
                }
                return;
            }
        }
        if (other.gameObject.tag == "Trampoline")
        {
            _controller.OnTrampolineEnter();
        }
        if (other.gameObject.name == "Win")
        {
            if (!_isWin)
            {
                _isWin = true;

                foreach (ParticleSystem ps in particleSystems)
                    ps.Play();
            }
        }
        if (other.gameObject.name == "Empty")
        {
            _controller._controller.enabled = false;
            _controller.gameObject.transform.position = new Vector3(10, 1, -10);
            _controller._controller.enabled = true;
        }
        if (other.gameObject.layer == 6)
        {
            _lastObject = other.gameObject;
        }
    }
}
