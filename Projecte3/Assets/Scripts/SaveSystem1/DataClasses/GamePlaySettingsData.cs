using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace Assets.Scripts.SaveSystem1.DataClasses
{
    public class GamePlaySettingsData
    {
        /// <summary>
        /// True is hud is visible.
        /// </summary>
        public bool toggleHud = true;

        /// <summary>
        /// Contrast Settings.
        /// </summary>
        [Range(0.5f, 2)]
        public float contrastValue = 1.25f;

        /// <summary>
        /// Brithness Settings.
        /// </summary>
        [Range(0.5f, 2)]
        public float brightnessValue = 1.25f;
    }
}
