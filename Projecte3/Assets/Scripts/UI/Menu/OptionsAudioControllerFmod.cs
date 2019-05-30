using Assets.Scripts.SaveSystem1.DataClasses;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Options Menu Sound for FMOD
/// Fmod project have to had One mixer Group per slider in menu 
/// Must have one FMODUnity.Studio.Bus instanceEvent by Mixeer group in FMOD Project
/// Must have a string var of name of groupmixer in FMOD Project
/// To Add or Remove an Channel or FMOD Mixer Group
/// To add 
/// Add A default Method and a SetVolumeXXXX(float value)
/// Add  and slider in scene and in the insector on slider put function SetVolumeXXX On event OnValueChanged
/// // to Remove
/// // desactive the Sider in the Hierachy and comment the Default Method and the SetVolumeXXXX.  and if want the variables associated to this chanel or group mixer
/// </summary>
public class OptionsAudioControllerFmod : MonoBehaviour
{
    #region Variables
    /// <summary>
    /// Loaded Audio Parameters From File json
    /// </summary>
    private AudioSettingsData _loadedAudioParameters = null;
    /// <summary>
    /// Override Audio Parameters local
    /// </summary>
    private readonly AudioSettingsData _overrideAudioParameters;
    /// <summary>
    /// Default Audio Parameters
    /// </summary>
    public AudioSettingsData DefaultAudioParameters;
    /// <summary>
    /// Parameters Audio
    /// </summary>
    public AudioSettingsData Parameters
    {
        get
        {
            if (_loadedAudioParameters != null)
            {
                return _loadedAudioParameters;
            }
            else
            {
                return _overrideAudioParameters ?? DefaultAudioParameters;
            }
        }
        set { }
    }

    [Header("Bus Names")]
    /// <summary>
    /// name Bus Master in FMOD always be ""
    /// </summary>
    public readonly string nameBusMaster = "";
    /// <summary>
    /// name Bus Music in FMOD default "Music"
    /// </summary>
    public string nameBusMusic = "Music";
    /// <summary>
    /// name Bus SFX in FMOD default SFX
    /// </summary>
    public string nameBusSFX = "SFX";
    /// <summary>
    /// name Bus Voices in FMOD default Voices
    /// </summary>
   /// public string nameBusVoices = "Voices";

    [Header("Slidres Audio ")]
    /// <summary>
    /// Slider Master in scene
    /// </summary>
    public Slider MasterSlider;
    /// <summary>
    /// Slider Music in scene
    /// </summary>
    public Slider MusicSlider;
    /// <summary>
    /// Slider XFS in scene
    /// </summary>
    public Slider SFXSlider;
    /// <summary>
    /// Slider Voices in scene
    /// </summary>
//    public Slider VoicesSlider;
    /// <summary>
    /// FMOD Studio Bus Master
    /// </summary>
   public FMOD.Studio.Bus instanceEventMaster;
    ///// <summary>
    ///// FMOD Studio Bus Music
    ///// </summary>
    public FMOD.Studio.Bus instanceEventMusic;
    ///// <summary>
    ///// FMOD Studio Bus SFX
    ///// </summary>
   public FMOD.Studio.Bus instanceEventSFX;
    /// <summary>
    /// FMOD Studio Bus Voices
    /// </summary>
   // public FMOD.Studio.Bus instanceEventVoices;
    #endregion

    #region Unity Metohds
    void Start()
    {

        if (GameController.hasLoadedGameData)
        {
            /// Debug.Log("SSS");
            instanceEventMaster = FMODUnity.RuntimeManager.GetBus("Bus:/" + nameBusMaster);
            instanceEventMusic = FMODUnity.RuntimeManager.GetBus("Bus:/" + nameBusMusic);
            instanceEventSFX = FMODUnity.RuntimeManager.GetBus("Bus:/" + nameBusSFX);
            // instanceEventVoices = FMODUnity.RuntimeManager.GetBus("Bus:/" + nameBusVoices);
            if (GameController.Instance.fileExists)
                _loadedAudioParameters = SaveData.objcts.Parameters.Sound;
        }
        SetDefaultsValues();

    }
    void Update()
    {

    }

    #endregion

    #region Metodhs
    /// <summary>
    /// Set modified  variable local Parameters in object SaveData to save.
    /// </summary>
    private void SetParametersOnSaveData()
    {
        SaveData.objcts.Parameters.Sound = Parameters;
    }


        #region Reset Default Values
        /// <summary>
        /// Restore default Values for All Parameter
        /// </summary>
        public void ResetDefaults()
        {
            ResetDefaultMaster();
            ResetDefaultMusic();
            ResetDefaultSXF();
         //   ResetDefaultVoices();
        }
        /// <summary>
        /// Restore defaulr value for Master value
        /// </summary>
        public void ResetDefaultMaster()
        {
            SetVolumeMaster(DefaultAudioParameters.masterValue);
            MasterSlider.value = Parameters.masterValue;
        }
        /// <summary>
        /// Restore default value for Music 
        /// </summary>
        public void ResetDefaultMusic()
        {
            SetVolumeMusic(DefaultAudioParameters.musicValue);
            MusicSlider.value = Parameters.musicValue;
        }
        /// <summary>
        /// Restore Default Value for sound efects
        /// </summary>
        public void ResetDefaultSXF()
        {
            SetVolumeSFX(DefaultAudioParameters.soundFXValue);
            SFXSlider.value = Parameters.soundFXValue;
        }
        /// <summary>
        /// Restore default value for voices
        /// </summary>
        //public void ResetDefaultVoices()
        //{
        //    SetVolumeVoices(DefaultAudioParameters.voicesValue);
        //    VoicesSlider.value = Parameters.voicesValue;
        //}
        #endregion
        #region Set Defaults Methods
        /// <summary>
        /// Set All Defaults Values to Bus instances and Sliders
        /// </summary>
        public void SetDefaultsValues()
        {
            SetDefaultVolumeMaster();
            SetDefaultVolumeMusic();
            SetDefaultVolumeSFX();
      //      SetDefaultVolumeVoices();
        }
        /// <summary>
        /// Set Default Volume value for Master group
        /// </summary>
        public void SetDefaultVolumeMaster()
        {
            instanceEventMaster.setVolume(Parameters.masterValue);
            MasterSlider.value = Parameters.masterValue;
        }
        /// <summary>
        /// Set Default Volume value for Music Group 
        /// </summary>
        public void SetDefaultVolumeMusic()
        {
            instanceEventMusic.setVolume(Parameters.musicValue);
            MusicSlider.value = Parameters.musicValue;
        }
        /// <summary>
        /// Set Default Volume value for SFX Group 
        /// </summary>
        public void SetDefaultVolumeSFX()
        {
            instanceEventSFX.setVolume(Parameters.soundFXValue);
            SFXSlider.value = Parameters.soundFXValue;
        }
        /// <summary>
        /// Set Default Volume value for Voices Group 
        /// </summary>
        //public void SetDefaultVolumeVoices()
        //{
        //    instanceEventVoices.setVolume(Parameters.voicesValue);
        //    VoicesSlider.value = Parameters.voicesValue;
        //}
        #endregion

        #region Set Volumes Calls from Sliders
        /// <summary>
        /// Do this function every change of value changeslider
        /// Set Volume on instance Fmod,Set value on Parameters variable, Set Parameters on SaveData, Save Data on Master Slider
        /// </summary>
        /// <param name="value"></param>
        public void SetVolumeMaster(float value)
        {
            instanceEventMaster.setVolume(value);
            Parameters.masterValue = value;
            SetParametersOnSaveData();
            GameController.Save();
        }
        /// <summary>
        /// Do this function every change of value changeslider
        /// Set Volume on instance Fmod,Set value on Parameters variable, Set Parameters on SaveData, Save Data on Music Slider
        /// </summary>
        /// <param name="value"></param>
        public void SetVolumeMusic(float value)
        {
            instanceEventMusic.setVolume(value);
            Parameters.musicValue = value;
            SetParametersOnSaveData();
            GameController.Save();
        }
        /// <summary>
        /// Do this function every change of value changeslider
        /// Set Volume on instance Fmod,Set value on Parameters variable, Set Parameters on SaveData, Save Data on SFX Slider
        /// </summary>
        /// <param name="value"></param>
        public void SetVolumeSFX(float value)
        {
            instanceEventSFX.setVolume(value);
            Parameters.soundFXValue = value;
            SetParametersOnSaveData();
            GameController.Save();
        }
        /// <summary>
        /// Do this function every change of value changeslider
        /// Set Volume on instance Fmod,Set value on Parameters variable, Set Parameters on SaveData, Save Data on Voices Slider
        /// </summary>
        /// <param name="value"></param>
        //public void SetVolumeVoices(float value)
        //{
        //    instanceEventVoices.setVolume(value);
        //    Parameters.voicesValue = value;
        //    SetParametersOnSaveData();
        //    GameController.Save();
        //}
        #endregion
    #endregion
}
