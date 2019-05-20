using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.SaveSystem1.DataClasses
{ 
    /// <summary>
    /// //if is FMOD Project
    /// Must have one variable float by GroupMixer in FMOD counting Master chanel
    /// // if is not fmod project 
    /// 
    /// </summary>
    [System.Serializable]
    public class AudioSettingsData
    {
        /// <summary>
        /// Music Volume Setting.
        /// </summary>
        [Range(0, 1)]
        public float musicValue = 0.5f;

        /// <summary>
        /// Sound Effects Volume Settings.
        /// </summary>
        [Range(0, 1)]
        public float soundFXValue = 0.5f;

        /// <summary>
        /// Master Volume Settings.
        /// </summary>
        [Range(0, 1)]
        public float masterValue = 0.5f;

        /// <summary>
        /// Master Volume Settings.
        /// </summary>
        [Range(0, 1)]
        public float voicesValue = 0.5f;
    }
}
