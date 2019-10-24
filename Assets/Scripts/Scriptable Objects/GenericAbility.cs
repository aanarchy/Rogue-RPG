using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Abilities/Generic Ability", fileName = "New Generic Ability")]
public class GenericAbility : ScriptableObject
{
    public string Description;
    public Sprite icon;
    public int levelNeeded;
    public int XPNeeded;

    public virtual void Ability(Vector2 playerPosition, Vector2 playerDirection) {
        
    }
}
