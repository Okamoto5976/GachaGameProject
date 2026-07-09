using UnityEngine;
using System.Collections.Generic;

public enum TestType
{
    Grass,
    Onsen
}

public enum TestRarity
{
    C
}

public class CharaStateData
{
    public int ID;
    public string Name;
    public TestType Type;
    public TestRarity Rarity;
    public int Value;
    public Texture2D Image;

    public int Level;
}

public class CharaDataManager : MonoBehaviour
{
    private List<CharaStateData> m_dataList = new();

    public void AdddataList(CharaStateData data)
    {
        m_dataList.Add(data);
        //並べ替える（一応）
    }

    //idからdataを渡す
    public CharaStateData GetCharaData(int id)
    {
        return null;
    }

    //icon + id キャラ選択や　図鑑のため
    public CharaStateData GetCharaImage(int id)
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
