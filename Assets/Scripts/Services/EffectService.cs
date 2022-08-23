using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace MiniClip.Challenge.Service
{
    public class EffectService : MonoBehaviour
    {

        public void PlayEffect(Effects effect, Vector3 position, Action callback = null)
        {

            GameObject obj = Services.TrickyElements.effects.Find(x => x.name.Equals(effect.ToString()));

            if (obj)
            {
                GameObject particleEffect = Instantiate(obj);
                particleEffect.transform.position = position;

                Extensions.PerformActionWithDelay(this, 0.2f, () =>
                {
                    callback?.Invoke();
                });
            }
            else
            {
                callback?.Invoke();
                Debug.Log("No Particle Effect fouund with the name " + effect.ToString());
            }
        }

        public void PlayEffect(Effects effect, Vector3 position, Color color, Action callback = null)
        {

            GameObject obj = Services.TrickyElements.effects.Find(x => x.name.Equals(effect.ToString()));

            if (obj)
            {
                GameObject particleEffect = Instantiate(obj);
                particleEffect.transform.position = position;

                var main = particleEffect.GetComponent<ParticleSystem>().main;
                main.startColor = color;

                Extensions.PerformActionWithDelay(this, 0.2f, () =>
                {
                    callback?.Invoke();
                });
            }
            else
            {
                callback?.Invoke();
                Debug.Log("No Particle Effect fouund with the name " + effect.ToString());
            }
        }
    }
}