using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MySystemP
{
    public class MovementParticle : MonoBehaviour
    {
        public float velocity=0.1f;
        public Vector3 direction;
        public MyParticle _particle;
        [SerializeField] CustomVector randomDirection;
        void Start()
        {
            Renderer _renderer = GetComponent<Renderer>();
            MaterialPropertyBlock _material = new MaterialPropertyBlock();
            _particle.ChangeColor(_renderer, _material);
            DirectionRandom();
        }
        private void OnEnable()
        {
            
        }
        void Update()
        {
            transform.position =_particle.Move(transform.position,direction,velocity);
        }

        public void DirectionRandom()
        {
           
            direction = randomDirection.RandomVector();
        }
        public void Hide(float timeToHide, Transform posInit)
        {
            StartCoroutine(MytimeToHide(timeToHide, posInit));
           
        }
        public void Active()
        {
            gameObject.SetActive(true);
        }
        public void SetPositionInit(Transform posInit)
        {
            transform.position = posInit.position;
        }
        [System.Serializable]
        public struct CustomVector
        {
            public AxisMovement AxisX;
            public AxisMovement AxisY;
            public AxisMovement AxisZ;
            public Vector3 RandomVector()
            {
                return new Vector3(AxisX.GetRandomMovementAxis(), AxisY.GetRandomMovementAxis(), AxisZ.GetRandomMovementAxis());
            }
        }
        [System.Serializable]
        public struct AxisMovement
        {
            public float minAxis;
            public float maxAxis;
            public float GetRandomMovementAxis()
            {
                return Random.Range(minAxis, maxAxis);
            }
        }
        IEnumerator MytimeToHide(float time, Transform posInit)
        {
            Active();
            SetPositionInit(posInit);

            yield return new WaitForSecondsRealtime(time);
            gameObject.SetActive(false);
        }
    }

}
