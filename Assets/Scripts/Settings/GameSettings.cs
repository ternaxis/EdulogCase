using UnityEngine;

namespace Settings
{
    public class GameSettings : MonoBehaviour
    {
        public static GameSettings Settings;

        public float mouseSensitivity = 100f;


        private void Awake()
        {
            if (Settings == null)
            {
                Settings = this;
            }
        }
        
        
        
    }
}