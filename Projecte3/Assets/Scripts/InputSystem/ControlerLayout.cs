using UnityEngine;


    [CreateAssetMenu(fileName = "Controller Layout", menuName = "Controller/Create Controller Layout")]
   public class ControlerLayout:ScriptableObject
    {
        [Header("Movement")]
        public string HorizontalMovimentAxis;
        public string VerticalMovementAxis;
        public bool InvertHorizontalMovement;
        public bool InvertVertialMoviment;

        [Header("Actions")]
        public string Jump;
        public string Settings;
         
    }

