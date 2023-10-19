using System.Collections.Generic;

namespace CrossWord.Scripts.Interfaces
{
    /// <summary>
    /// Data that used to check the correct word.
    /// </summary>
    public interface IWordChecker
    {
        /// <summary>
        /// The collection of word that will be check when letters have collected.
        /// </summary>
        List<string> CorrectWord { get; set; }
    }
}