using System;
using System.Collections.Generic;

namespace ScriptureHider
{
    public class Scripture
    {
        private Reference _reference;
        private List<Word> _words;
        private Random _random;

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = new List<Word>();
            _random = new Random();

            string[] wordArray = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in wordArray)
            {
                _words.Add(new Word(word));
            }
        }

        public bool isCompletelyHidden()
        {
            foreach (var word in _words)
            {
                if (!word.IsHidden())
                    return false;
            }
            return true;
        }

        public void HideRandomWords(int count= 3)
        {
            List<Word> visibleWords = _words.FindAll(w => !w.IsHidden());

            if (visibleWords.Count == 0)
                return;

            if (visibleWords.Count < count)
                count = visibleWords.Count;

            
            for (int i= 0; i < count; i++)
            {
                int index = _random.Next(visibleWords.Count);
                visibleWords[index].Hide();
                visibleWords.RemoveAt(index);
            }
        }

        public override string ToString()
        {
            List<string> displayWords = new List<string>();
            foreach (var word in _words)
            {
                displayWords.Add(word.Display());
            }
            return $"{_reference}\n{string.Join(" ", displayWords)}";
        }

        public List<Word> GetWords()
        {
            return _words;
        }
    }
}