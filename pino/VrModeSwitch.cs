/*
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.VR;
using VRStandardAssets.Utils;

public class VrModeSwitch : MonoBehaviour
{
    // REFERENCE
    [SerializeField] private GyroCamera _gyroControl;
    [SerializeField] private Camera _camera;
    [SerializeField] private VREyeRaycaster _eyeRaycaster;

    // SETTINGS
    private const float Delay = 0.2f;

    public void SetModeMagicWindow()
    {
        StartCoroutine(SetModeMagicWindowRoutine());
    }

    public void SetModeStereoscopic()
    {
        StartCoroutine(SetModeStereoscopicRoutine());
    }

#if !UNITY_EDITOR
    private void Awake()
    {
        _eyeRaycaster.enabled = VRSettings.enabled;
    }
#endif

    private IEnumerator SetModeMagicWindowRoutine()
    {

        _eyeRaycaster.SetEnabled(false);
        VRSettings.LoadDeviceByName("none");

        // Delay as LoadDeviceByName "Loads the requested device at the beginning of the next frame."
        yield return new WaitForSeconds(Delay);
        VRSettings.enabled = false;
        yield return new WaitForSeconds(Delay);
        _camera.ResetAspect(); // We do ResetAspect as with Unity version 2017.1.b8 when disabling VR the camera aspect is distorted.
        yield return new WaitForSeconds(Delay);
        _gyroControl.SetEnabled(true);
    }

    private IEnumerator SetModeStereoscopicRoutine()
    {
        _gyroControl.SetEnabled(false);
        VRSettings.LoadDeviceByName("cardboard");

        // Delay as LoadDeviceByName "Loads the requested device at the beginning of the next frame."
        yield return new WaitForSeconds(Delay);
        VRSettings.enabled = true;

        yield return new WaitForSeconds(Delay);

        _eyeRaycaster.SetEnabled(true);

        // Reset the entire scene (below) at this point because in Unity version 2017.1.b8 if we do not then the VR camera orientation is reset to horizon no matter what orientation the device actually is in.
        // Note: we use 2017.1.b8 as all versions prior including 5.6.x break VR rendering for iOS. 
        SceneManager.LoadScene(0);

        // I think InputTracking.Recenter (below) would be the proper way to reset things instead of scene reset but as of 2017.1.b8 it doesn't work.
        //InputTracking.Recenter();
    }
}

*/