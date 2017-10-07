using System;
namespace Models
{
	public interface ITextToSpeech
	{
		void Speak(string text);
	}
}
