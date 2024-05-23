using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MySystemP
{
    [CreateAssetMenu(fileName = "MyParticle", menuName = "ScriptableObjects/MySystemP/Particle")]
    public class MyParticle : ScriptableObject
    {
        [SerializeField] private Texture _sprite;
        [SerializeField] private Color _color;
        private float _timeToLive;
        [SerializeField] public AnimationCurve velocityCurve;
        public Texture Sprite { get { return _sprite; } set { _sprite = value; } }
        public Color Color { get { return _color; }  set { _color = value; } }
        public float TimeToLive { get { return _timeToLive; }  set { _timeToLive = value; } }
    
        private void OnEnable()
        {

        }
        public Vector3 Move(Vector3 postioninit, Vector3 direction,float velocity)
        {
            return postioninit+ direction* (velocityCurve.Evaluate(Time.time)* velocity);
        }
        public void ChangeColor(Renderer _renderer, MaterialPropertyBlock _material)
        {
            _renderer.GetPropertyBlock(_material);
            _material.SetTexture("_MainTex", Sprite);
            _material.SetColor("_Color", Color);
            _renderer.SetPropertyBlock(_material);
        }
    }
}
