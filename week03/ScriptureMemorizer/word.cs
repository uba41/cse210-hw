using System;

namespace ScriptureHider
{
    public class Word
    {
        private string _text;
        private bool _isHidden;

        public Word(string text)
        {
            _text = text;
            _isHidden = false;
        }

        public bool IsHidden()
        {
            return _isHidden;
        }

        public void Hide()
        {
            _isHidden = true;
        }

        //Think of other challenges that people find when trying to memorize a scripture. Find a way to have your program help with these challenges.
        //Difficulty Mode (easy/medium/hard)
        public void Reveal()
        {
            _isHidden = false;
        }

        public string Text => _text; //Read only public access

        public string Display()
        {
            return _isHidden ? new string('_', _text.Length) : _text;
        } 
    }
}