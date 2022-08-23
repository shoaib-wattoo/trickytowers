using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lofelt.NiceVibrations;

public class VibrationService : MonoBehaviour
{
    public bool isVibrationEnable = true;

    public void VibratePhone(HapticPatterns.PresetType vibrationType)
    {
#if PLATFORM_ANDROID || UNITY_ANDROID
        if(isVibrationEnable)
            HapticPatterns.PlayPreset(vibrationType);
#endif
    }
    
}
