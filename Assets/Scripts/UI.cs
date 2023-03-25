using Cinemachine;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] private TMP_Text m_ammoCounter;
    [SerializeField] private TMP_Text m_healthCounter;
    // [SerializeField] private UnityEngine.UI.Image m_weaponImageOuput;

    // [SerializeField] private CinemachineVirtualCamera m_virtualCamera;
    // [SerializeField] private UnityEngine.U2D.PixelPerfectCamera m_pixelPerfect;

    private Vector3 m_cameraFollowStartVector;

    private void Start()
    {
        // GameManager.Instance.HealthChangedEvent += OnHealthChanged;
        GameManager.Instance.PlayerEvents.AmmoChangedEvent += OnAmmoChanged;
        // GameManager.Instance.PlayerEvents.ScopeChangedEvent += OnScopeChanged;
        // GameManager.Instance.WeaponImageAndCameraFollowChangeEvent += WeaponImageAndCameraFollowChange;
    }

    private void OnDisable()
    {
        // GameManager.Instance.HealthChangedEvent -= OnHealthChanged;
        GameManager.Instance.PlayerEvents.AmmoChangedEvent -= OnAmmoChanged;
        // GameManager.Instance.PlayerEvents.ScopeChangedEvent -= OnScopeChanged;
        // GameManager.Instance.WeaponImageAndCameraFollowChangeEvent -= WeaponImageAndCameraFollowChange;
    }


    public void OnHealthChanged(int value)
    {
        m_healthCounter.text = value.ToString();
    }
    private void OnAmmoChanged(string value)
    {
        m_ammoCounter.text = value;
        if (value[0] == '0')
            m_ammoCounter.color = Color.red;
        else
            m_ammoCounter.color =  Color.white;
    }
    // private void OnScopeChanged(int value, float multiplier)
    // {
    //     m_pixelPerfect.assetsPPU = value;
    //     Debug.Log(m_virtualCamera.Follow.localPosition);
    //     m_virtualCamera.Follow.localPosition = new Vector3(m_cameraFollowStartVector.x,
    //     m_cameraFollowStartVector.y * multiplier,
    //     m_cameraFollowStartVector.z);
    //     Debug.Log(m_virtualCamera.Follow.localPosition);
    // }
    // private void WeaponImageAndCameraFollowChange(Color image, Transform cameraFollowTransform)
    // {
    //     m_weaponImageOuput.color = image;
    //     m_virtualCamera.Follow = cameraFollowTransform;
    //     m_cameraFollowStartVector = m_virtualCamera.Follow.localPosition;
    // }
}