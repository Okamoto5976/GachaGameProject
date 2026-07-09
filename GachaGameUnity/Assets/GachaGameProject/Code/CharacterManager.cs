using UnityEngine;
using System.Collections.Generic;

public class CharacterDataBase
{
    public int ID;
    public string Name;
    public Enum_CharaType Type;
    public Enum_RarityType Rarity;
    public int Value;
    public Texture2D Image;

    public int Level;
}

public class CharacterData
{
    public int ID;
    public int Level;
    public Enum_PlaceType PlaceType;
}

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager Instance;

    private List<CharacterDataBase> m_dataList = new();

    private SaveDataFile m_saveFile = new();

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AdddataList(CharacterDataBase data)
    {
        m_dataList.Add(data);
        //並べ替える（一応）
    }

    //idからdataを渡す
    public CharacterDataBase GetCharaData(int id)
    {
        return null;
    }

    //icon + id キャラ選択や　図鑑のため
    public CharacterDataBase GetCharaImage(int id)
    {
        //１から順に取っていき、
        //受け取り手がidとimageをもつことで図鑑ができる
        //ないときは受け取り手が真っ黒にする図鑑を

        //キャラ選択のとき
        //図鑑のときもそうだけど更新のとき
        //Coroutine（非同期処理）でimageとデータを更新しよう

        return null;
    }
}
