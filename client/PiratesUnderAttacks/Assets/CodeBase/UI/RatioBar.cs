using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI
{
    public class RatioBar : MonoBehaviour
    {
        [SerializeField] private Image _current;
        [SerializeField] private Image _target;
        [SerializeField] private float _smoothTimeInSeconds;

        private Coroutine _coroutine;
        
        public void Fill(float ratio)
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }

            _coroutine = StartCoroutine(Filling(ratio));
        }

        private IEnumerator Filling(float target)
        {
            var t = 0f;

            _target.fillAmount = target;
            var current = _current.fillAmount;

            while (t < _smoothTimeInSeconds)
            {
                t += Time.deltaTime;
                _current.fillAmount = Mathf.Lerp(current, target, t / _smoothTimeInSeconds);
                yield return null;
            }

            _current.fillAmount = target;
        }
    }
}