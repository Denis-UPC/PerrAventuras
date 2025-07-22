using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData : MonoBehaviour
{
    //ScriptableObject para datos reutilizables

    [CreateAssetMenu(fileName = "CharacterData", menuName = "Perraventuras/Character")]
    public class CharacterData : ScriptableObject
    {
        public string characterName;
        public float speed;
        public float jumpForce;
        public Sprite icon;
    }
}
