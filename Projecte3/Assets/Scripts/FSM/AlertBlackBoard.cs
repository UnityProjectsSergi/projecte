using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace FSM
{
    public class AlertBlackBoard : MonoBehaviour
    {

        // Use this for initialization
        public Image ImageCookingAlert;
        public float TimeShowImageDone;
        public float timeWaitShowImageDone;
        public float timeHideImageDone;
        public GameObject HideShowGO;
        [HideInInspector]
        public FSM_ShowHideImage FSM_ShowHideImage;
        private void Awake()
        {
            FSM_ShowHideImage = HideShowGO.AddComponent<FSM_ShowHideImage>();
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