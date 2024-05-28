using UnityEngine;

namespace CodeBase.UI
{
    public class UIRoot : MonoBehaviour
    {
        [SerializeField] private GameObject _deadZoneWarningUI;
        
        public void ShowDeadZoneWarning() => 
            _deadZoneWarningUI.SetActive(true);

        public void HideDeadZoneWarning() => 
            _deadZoneWarningUI.SetActive(false);
    }
}