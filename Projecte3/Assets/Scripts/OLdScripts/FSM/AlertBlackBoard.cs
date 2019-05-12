using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace FSM
{
    public class AlertBlackBoard : MonoBehaviour
    {

        [Header("Alert States")]
        [Header("Slow")]
        public float timerHideSlow;
        public float timerShowSlow;
        public int numRepetitionsSlow;
        public float timeWaitShowSlow;
        [Header("Normal")]
        public float timerHideNormal;
        public float timerShowNormal;
        public int numRepetitionsNormal;
        public float timeWaitShowNormal;
        [Header("Fast")]
        public float timerHideFast;
        public float timerShowFast;
        public int numRepetitionsFast;
        public float timeWaitShowFast;

        public GameObject HideShowGO;
          
        [HideInInspector]
        public FSM_ShowHideImage FSM_ShowHideImage;
        private void Awake()
        {
            FSM_ShowHideImage = HideShowGO.AddComponent<FSM_ShowHideImage>();
            FSM_ShowHideImage.enabled = false;

        }
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}