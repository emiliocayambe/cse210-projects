using System;
using System.Collections.Generic;
using System.IO;


class Scripture
{
    private Reference _reference;
    private List<string> _words = new List<string>();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        string[] wordsArray = text.Split(' ');
        foreach (string word in wordsArray)
        {
            _words.Add(word);
        }
    }

    public string GetDisplayText()
    {   
        string displayText = _reference.GetDisplayText() + " ";
        foreach (string word in _words)
        {
            displayText += word + " ";
        }
        return displayText.Trim();
    }

    public void HideRandomWord()
    {
        Random rand = new Random();
        
        // Repetimos el proceso 3 veces para ocultar hasta 3 palabras
        for (int i = 0; i < 3; i++)
        {
            // Creamos una lista de los índices de las palabras que NO están ocultas
            List<int> visibleIndices = new List<int>();
            
            for (int j = 0; j < _words.Count; j++)
            {
                // Verificamos si la palabra contiene al menos una letra (no es solo guiones)
                if (!_words[j].All(c => c == '_'))
                {
                    visibleIndices.Add(j);
                }
            }

            // Si ya no hay palabras visibles, salimos del bucle
            if (visibleIndices.Count == 0)
            {
                break;
            }

            // Elegimos un índice al azar de nuestra lista de palabras visibles
            int randomIndex = visibleIndices[rand.Next(visibleIndices.Count)];
            
            // Ocultamos esa palabra
            _words[randomIndex] = new string('_', _words[randomIndex].Length);
        }
    }  

    public bool isCompletelyHidden()
    {
        foreach (string word in _words)
        {
            if (!word.All(c => c == '_'))
            {
                return false;
            }
        }
        // Verifica si ya no queda ninguna letra del abecedario visible
        return !_words.Any(word => word.Any(c => char.IsLetter(c)));
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename)) return;

        // 1. Leemos todas las líneas del archivo
        string[] lines = File.ReadAllLines(filename);
        
        if (lines.Length > 0)
        {
            // 2. Generamos un índice aleatorio entre 0 y el total de líneas
            Random rand = new Random();
            int randomIndex = rand.Next(lines.Length);

            // 3. Usamos la línea elegida al azar en lugar de siempre usar la 0
            string selectedLine = lines[randomIndex];
            
            string[] parts = selectedLine.Split('|').Select(p => p.Trim()).ToArray();

            if (parts.Length >= 4)
            {
                string book = parts[0];
                int chapter = int.Parse(parts[1]);
                int startVerse = int.Parse(parts[2]);
                string text = "";

                if (int.TryParse(parts[3], out int endVerse))
                {
                    _reference = new Reference(book, chapter, startVerse, endVerse);
                    text = parts[4]; 
                }
                else
                {
                    _reference = new Reference(book, chapter, startVerse);
                    text = parts[3]; 
                }

                _words = text.Split(' ').ToList();
            }
        }
    }
}