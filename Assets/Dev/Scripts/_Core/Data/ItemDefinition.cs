using UnityEngine;

namespace Lootbox.Data
{
    [CreateAssetMenu(fileName = "NewItem", menuName = "Lootbox/Item Definition")]
    public class ItemDefinition : ScriptableObject
    {
        public string Id => _id;
        public Sprite Icon => _icon;
        public Color GlowColor => _glowColor;
        public int Weight => _weight;


        [SerializeField] private string _id;
        [SerializeField] private Sprite _icon;
        [SerializeField] private Color _glowColor = Color.white;
        [SerializeField] private int _weight = 1;

    }
}