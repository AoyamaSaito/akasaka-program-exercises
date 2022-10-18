using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    [SerializeField]
    private TextDataScriptable _textDataScriptable;
    [SerializeField]
    private Text _text;
    [SerializeField]
    private float _waitTime = 0.1f;

    private int _index = 0;

    private void Start()
    {
        _index = 0;
        TextUpdate(_index);
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            _index++;
            TextUpdate(_index);
        }
    }

    private Coroutine _currentCor;
    /// <summary>
    /// テキストを更新する
    /// </summary>
    /// <param name="index"></param>
    private void TextUpdate(int index)
    {
        _text.text = "";
        if (_text != null && _textDataScriptable.Texts[index] != null)
        {
            if(_currentCor != null)
            {
                StopCoroutine(_currentCor);
            }
            _currentCor = StartCoroutine(TextCor(_textDataScriptable?.Texts[index], _waitTime));
        }
        else
        {
            _text.text = "Error:Textが存在しません";
        }
    }

    /// <summary>
    /// 引数の文字列を_waitTimeずつ表示する
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    IEnumerator TextCor(string text, float waitTime)
    {
        bool isFinish = false;
        int index = 0;
        _text.text += text[index];

        while (isFinish == false)
        {
            yield return new WaitForSeconds(waitTime);
            index++;
            if (index >= text.Length)
            {
                yield break;
            }
            _text.text += text[index];

        }
    }
}
