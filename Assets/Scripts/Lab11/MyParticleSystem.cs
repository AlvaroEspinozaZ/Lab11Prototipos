using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MySystemP
{
    public class MyParticleSystem : MonoBehaviour
    {
        public MovementParticle movementParticle;
        public List<MovementParticle> listParticles;
        public AnimationCurve timetoSpawm;
        public Color colors;
        public Texture imagen;
        public int cantObjects=200;
        private float _timeToLive=2;

        private void Start()
        {
            for (int i = 0; i < cantObjects; i++)
            {
                MovementParticle tmp = Instantiate(movementParticle);
                tmp._particle.Sprite = imagen;
                tmp._particle.Color = colors;
                tmp.Hide(_timeToLive, transform);
                listParticles.Add(tmp) ;
            }
        }
    }
}