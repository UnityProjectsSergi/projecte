using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace FSM
{
    public class CookingBlackbloard : MonoBehaviour
    {
        public Image ImageCookingDone;
        public float TimeShowImageDone;
        public float timeWaitShowImageDone;
        public float timeHideImageDone;
        [HideInInspector]
        public FSM_ProgressBar progressBar;
        public GameObject ProgBarGO;
        public GameObject HideShowGO;
        [HideInInspector]
        public FSM_ShowHideImage FSM_ShowHideImage;

        // Use this for initialization
        void Awake()
        {
            progressBar = ProgBarGO.AddComponent<FSM_ProgressBar>();
            FSM_ShowHideImage = HideShowGO.AddComponent<FSM_ShowHideImage>();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}