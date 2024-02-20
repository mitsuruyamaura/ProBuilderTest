using UnityEngine;
using Cinemachine.PostFX;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingManager : MonoBehaviour
{
    [SerializeField] private CinemachinePostProcessing postProcessing;
    [SerializeField] private PostProcessProfile normalProfile;
    [SerializeField] private PostProcessProfile nightVisionProfile;

    private bool isNormalProfileActive = true;


    void Start() {
        if (isNormalProfileActive) {
            postProcessing.m_Profile = normalProfile;
        } else {
            postProcessing.m_Profile = nightVisionProfile;
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            ChangeProfile();
        }
    }

    /// <summary>
    /// Profile �̐؂�ւ�
    /// </summary>
    public void ChangeProfile() {
        if (isNormalProfileActive) {
            postProcessing.m_Profile = nightVisionProfile;
        } else {
            postProcessing.m_Profile= normalProfile;
        }
        isNormalProfileActive = !isNormalProfileActive;
        Debug.Log($"�؂�ւ�{isNormalProfileActive}");
    }
}
