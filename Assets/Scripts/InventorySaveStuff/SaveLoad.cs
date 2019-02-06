using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public CharacterData characterData;

    static void SaveCharacter (CharacterData data, int characterSlot)
    {


        PlayerPrefs.SetInt("dungeon1_CharacterSlot" + characterSlot, data.dungeon1);
        PlayerPrefs.SetInt("dungeon2_CharacterSlot" + characterSlot, data.dungeon2);
        PlayerPrefs.SetInt("dungeon3_CharacterSlot" + characterSlot, data.dungeon3);
        PlayerPrefs.SetInt("dungeon4_CharacterSlot" + characterSlot, data.dungeon4);
        PlayerPrefs.SetInt("dungeon5_CharacterSlot" + characterSlot, data.dungeon5);
        PlayerPrefs.SetInt("dungeon6_CharacterSlot" + characterSlot, data.dungeon6);
        PlayerPrefs.SetInt("dungeon7_CharacterSlot" + characterSlot, data.dungeon7);
        PlayerPrefs.SetInt("dungeonF_CharacterSlot" + characterSlot, data.dungeonF);

        PlayerPrefs.SetFloat("playerX_CharacterSlot" + characterSlot, data.playerX);
        PlayerPrefs.SetFloat("playerY_CharacterSlot" + characterSlot, data.playerY);
        PlayerPrefs.SetFloat("playerZ_CharacterSlot" + characterSlot, data.playerZ);

        PlayerPrefs.SetInt("playerCurrency_CharacterSlot" + characterSlot, data.playerCurrency);

        PlayerPrefs.SetString("ObjInViewX_CharacterSlot" + characterSlot, data.ObjInViewX);
        PlayerPrefs.SetString("ObjInViewY_CharacterSlot" + characterSlot, data.ObjInViewY);



        PlayerPrefs.Save ();
    }

    static CharacterData LoadCharacter (int characterSlot)
    {
        CharacterData loadedCharacter = new CharacterData ();


        //loadedCharacter.characterName = PlayerPrefs.GetString ("characterName_CharacterSlot" + characterSlot);
        //loadedCharacter.power = PlayerPrefs.GetFloat ("power_CharacterSlot" + characterSlot);
        //loadedCharacter.bullets = PlayerPrefs.GetInt ("bullets_CharacterSlot" + characterSlot);

        return loadedCharacter;
    }
}
