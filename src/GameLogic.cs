using System;
using SwinGameSDK;

namespace MyGame
{
class GameLogic
{
	/// <summary>
	/// The entry point of the program, where the program control starts and ends.
	/// </summary>
	public void Main()
	{
		//Opens a new Graphics Window
		SwinGame.OpenGraphicsWindow("Battle Ships", 800, 600);

		//Load Resources
		GameResources.LoadResources();

		SwinGame.PlayMusic(GameMusic("Background"));

		//Game Loop
		do {
			HandleUserInput();
			DrawScreen();
		} while (!(SwinGame.WindowCloseRequested() == true | CurrentState == GameState.Quitting));

		SwinGame.StopMusic();

		//Free Resources and Close Audio, to end the program.
		GameResources.FreeResources();
	}
}
}