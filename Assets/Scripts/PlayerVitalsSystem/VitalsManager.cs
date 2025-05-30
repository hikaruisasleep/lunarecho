using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerVitalsSystem
{
    public class VitalsManager : MonoBehaviour
    {

        [SerializeField] private float oxygenAmount;
        [SerializeField] private float maxOxygenAmount;
        [SerializeField] private float healthAmount;
        [SerializeField] private float maxHealthAmount;
        [SerializeField] private float vitalsDepletionRate;

        Coroutine breathingCoroutine;

        [SerializeField] Slider oxygenSlider;
        [SerializeField] Slider healthSlider;

        void Start()
        {
            healthAmount = maxHealthAmount;
            oxygenAmount = maxOxygenAmount;
            breathingCoroutine = StartCoroutine(Breathing());
        }

        void Update()
        {
            oxygenSlider.value = (oxygenAmount * 100 / maxOxygenAmount);
            healthSlider.value = (healthAmount * 100 / maxHealthAmount);
        }

        public void ReplenishOxygen()
        {
            StartCoroutine(SetRecentCharge());
            oxygenAmount = maxOxygenAmount;
        }

        IEnumerator Breathing()
        {
            while (true)
            {
                if (oxygenAmount > 0)
                {
                    oxygenAmount--;
                    yield return new WaitForSeconds(vitalsDepletionRate / 1000);
                }
                else if (oxygenAmount <= 0)
                {
                    healthAmount--;
                    yield return new WaitForSeconds((vitalsDepletionRate * 1.5f) / 1000);
                }
            }
        }

        IEnumerator SetRecentCharge()
        {
            StopCoroutine(breathingCoroutine);
            yield return new WaitForSeconds(10);
            breathingCoroutine = StartCoroutine(Breathing());
        }
    }
}