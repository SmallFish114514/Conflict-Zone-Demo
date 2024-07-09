using System.Collections;
using UnityEngine;
public class CharacterBuilderDirectior : MonoBehaviour
{
    public static ICharacter Construct(ICharacterBuilder characterBuilder)
    {
        characterBuilder.AddCharacterAttr();
        characterBuilder.AddGameObject();
        characterBuilder.AddWeapon();
        characterBuilder.AddInCharacterSystem();
        return characterBuilder.GetResult();
    }

}
