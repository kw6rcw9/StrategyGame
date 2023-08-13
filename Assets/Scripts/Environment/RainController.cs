using System.Collections;
using UnityEngine;

namespace Environment
{
    public class RainController : MonoBehaviour
    {
        [SerializeField] Light _dirLight;
        private ParticleSystem _ps;
        private bool _isRain = false;

        private void Start()
        {
            _ps = GetComponent<ParticleSystem>();
            _ps.Stop();
            StartCoroutine(Weather());
        }

        private void Update()
        {
            if (_isRain && _dirLight.intensity > 0.3f)
            {
                LightIntensity(-1);
            }
            else if (!_isRain && _dirLight.intensity < 0.68f)
            {
                LightIntensity(1);
            }
        }

        private void LightIntensity(int i)
        {
            _dirLight.intensity += 0.1f * Time.deltaTime * i;
        }

        private IEnumerator Weather()
        {
            while (true)
            {
                yield return new WaitForSeconds(UnityEngine.Random.Range(30f, 60f));
                if (_isRain)
                    _ps.Stop();
                else
                    _ps.Play();
         
                _isRain = !_isRain;
            }
        }
    }
}
