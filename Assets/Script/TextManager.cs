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

    private void TextUpdate(int index)
    {
        _text.text = "";
        if (_text != null && _textDataScriptable?.Texts[index] != null)
        {
            StartCoroutine(TextCor(_textDataScriptable?.Texts[index]));
        }
        else
        {
            _text.text = "Error:Text‚ª‘¶Ý‚µ‚Ü‚¹‚ñ";
        }
    }

    IEnumerator TextCor(string text)
    {
        Debug.Log("Cor");
        bool isFinish = false;
        int index = 0;
        _text.text += text[index];

        while (isFinish)
        {
            Debug.Log(text[index]);
            yield return new WaitForSeconds(_waitTime);
            index++;
            _text.text += text[index];

            if(index > text.Length)
            {
                isFinish = true;
            }
        }
    }
}
