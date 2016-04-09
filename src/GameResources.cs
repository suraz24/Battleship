using Microsoft.VisualBasic;
using System;
using SwinGameSDK;
using System.Collections.Generic;

/// <summary>
/// The Resources Class stores all of the Games Media Resources, such as Images, Fonts
/// Sounds, Music.
/// </summary>
public static class GameResources
{
	private static Dictionary<string, Bitmap> _Images = new Dictionary<string, Bitmap>();
	private static Dictionary<string, Font> _Fonts = new Dictionary<string, Font>();
	private static Dictionary<string, SoundEffect> _Sounds = new Dictionary<string, SoundEffect>();
	private static Dictionary<string, Music> _Music = new Dictionary<string, Music>();
	private static Bitmap _Background;
	private static Bitmap _Animation;
	private static Bitmap _LoaderFull;
	private static Bitmap _LoaderEmpty;
	private static Font _LoadingFont;
	private static SoundEffect _StartSound;

	/// <summary>
	/// Loads the fonts the game needs
	/// </summary>
	private static void LoadFonts()
	{
		NewFont("ArialLarge", "arial.ttf", 80);
		NewFont("Courier", "cour.ttf", 14);
		NewFont("CourierSmall", "cour.ttf", 8);
		NewFont("Menu", "ffaccess.ttf", 8);
	}

	/// <summary>
	/// Loads the images the game needs
	/// </summary>
	private static void LoadImages()
	{
		//Backgrounds
		NewImage("Menu", "main_page.jpg");
		NewImage("Discovery", "discover.jpg");
		NewImage("Deploy", "deploy.jpg");

		//Deployment
		NewImage("LeftRightButton", "deploy_dir_button_horiz.png");
		NewImage("UpDownButton", "deploy_dir_button_vert.png");
		NewImage("SelectedShip", "deploy_button_hl.png");
		NewImage("PlayButton", "deploy_play_button.png");
		NewImage("RandomButton", "deploy_randomize_button.png");

		//Ships
		int i = 0;
		for (i = 1; i <= 5; i++)
		{
			NewImage("ShipLR" + i, "ship_deploy_horiz_" + i + ".png");
			NewImage("ShipUD" + i, "ship_deploy_vert_" + i + ".png");
		}

		//Explosions
		NewImage("Explosion", "explosion.png");
		NewImage("Splash", "splash.png");

	}

	/// <summary>
	/// Loads the sounds the game needs
	/// </summary>
	private static void LoadSounds()
	{
		NewSound("Error", "error.wav");
		NewSound("Hit", "hit.wav");
		NewSound("Sink", "sink.wav");
		NewSound("Siren", "siren.wav");
		NewSound("Miss", "watershot.wav");
		NewSound("Winner", "winner.wav");
		NewSound("Lose", "lose.wav");
	}

	/// <summary>
	/// Loads the music the game needs
	/// </summary>
	private static void LoadMusic()
	{
		NewMusic("Background", "horrordrone.mp3");
	}

	/// <summary>
	/// Gets a Font Loaded in the Resources
	/// </summary>
	/// <param name="font">Name of Font</param>
	/// <returns>The Font Loaded with this Name</returns>
	public static Font GameFont(string font)
	{
		return _Fonts[font];
	}

	/// <summary>
	/// Gets an Image loaded in the Resources
	/// </summary>
	/// <param name="image">Name of image</param>
	/// <returns>The image loaded with this name</returns>
	public static Bitmap GameImage(string image)
	{
		return _Images[image];
	}

	/// <summary>
	/// Gets a sound loaded in the Resources
	/// </summary>
	/// <param name="sound">Name of sound</param>
	/// <returns>The sound with this name</returns>
	public static SoundEffect GameSound(string sound)
	{
		return _Sounds[sound];
	}

	/// <summary>
	/// Gets the music loaded in the Resources
	/// </summary>
	/// <param name="music">Name of music</param>
	/// <returns>The music with this name</returns>
	public static Music GameMusic(string music)
	{
		return _Music[music];
	}

	/// <summary>
	/// Load in the resources (fonts, images, sounds, music)
	/// </summary>
	public static void LoadResources()
	{
		int width = 0;
		int height = 0;

		width = SwinGame.ScreenWidth();
		height = SwinGame.ScreenHeight();

		SwinGame.ChangeScreenSize(800, 600);

		ShowLoadingScreen();

		ShowMessage("Loading fonts...", 0);
		LoadFonts();
		SwinGame.Delay(100);

		ShowMessage("Loading images...", 1);
		LoadImages();
		SwinGame.Delay(100);

		ShowMessage("Loading sounds...", 2);
		LoadSounds();
		SwinGame.Delay(100);

		ShowMessage("Loading music...", 3);
		LoadMusic();
		SwinGame.Delay(100);

		SwinGame.Delay(100);
		ShowMessage("Game loaded...", 5);
		SwinGame.Delay(100);
		EndLoadingScreen(width, height);
	}

	/// <summary>
	/// Draws the loading screen
	/// </summary>
	private static void ShowLoadingScreen()
	{
		_Background = SwinGame.LoadBitmap(SwinGame.PathToResource("SplashBack.png", ResourceKind.BitmapResource));
		SwinGame.DrawBitmap(_Background, 0, 0);
		SwinGame.RefreshScreen();
		SwinGame.ProcessEvents();

		_Animation = SwinGame.LoadBitmap(SwinGame.PathToResource("SwinGameAni.jpg", ResourceKind.BitmapResource));
		_LoadingFont = SwinGame.LoadFont(SwinGame.PathToResource("arial.ttf", ResourceKind.FontResource), 12);
		_StartSound = Audio.LoadSoundEffect(SwinGame.PathToResource("SwinGameStart.ogg", ResourceKind.SoundResource));

		_LoaderFull = SwinGame.LoadBitmap(SwinGame.PathToResource("loader_full.png", ResourceKind.BitmapResource));
		_LoaderEmpty = SwinGame.LoadBitmap(SwinGame.PathToResource("loader_empty.png", ResourceKind.BitmapResource));

		PlaySwinGameIntro();
	}

	/// <summary>
	/// Plays the SwinGame intro
	/// </summary>
	private static void PlaySwinGameIntro()
	{
		const int ANI_X = 143;
		const int ANI_Y = 134;
		const int ANI_W = 546;
		const int ANI_H = 327;
		const int ANI_V_CELL_COUNT = 6;
		const int ANI_CELL_COUNT = 11;

		Audio.PlaySoundEffect(_StartSound);
		SwinGame.Delay(200);

		int i = 0;
		for (i = 0; i <= ANI_CELL_COUNT - 1; i++)
		{
			SwinGame.DrawBitmap(_Background, 0, 0);
			SwinGame.DrawBitmapPart(_Animation, (i / ANI_V_CELL_COUNT) * ANI_W, (i % ANI_V_CELL_COUNT) * ANI_H, ANI_W, ANI_H, ANI_X, ANI_Y);
			SwinGame.Delay(20);
			SwinGame.RefreshScreen();
			SwinGame.ProcessEvents();
		}

		SwinGame.Delay(1500);

	}

	/// <summary>
	/// Writes the passed in message to the screen
	/// </summary>
	/// <param name="message">Message to write to screen</param>
	/// <param name="number">?</param>
	private static void ShowMessage(string message, int number)
	{
		const int TX = 310;
		const int TY = 493;
		const int TW = 200;
		const int TH = 25;
		const int STEPS = 5;
		const int BG_X = 279;
		const int BG_Y = 453;

		int fullW = 0;

		fullW = 260 * number / STEPS;
		SwinGame.DrawBitmap(_LoaderEmpty, BG_X, BG_Y);
		SwinGame.DrawBitmapPart(_LoaderFull, 0, 0, fullW, 66, BG_X, BG_Y);

		SwinGame.DrawTextLines(message, Color.White, Color.Transparent, _LoadingFont, FontAlignment.AlignCenter, TX, TY, TW, TH);

		SwinGame.RefreshScreen();
		SwinGame.ProcessEvents();
	}

	/// <summary>
	/// Unload loading screen resources
	/// </summary>
	/// <param name="width">screen width</param>
	/// <param name="height">screen height</param>
	private static void EndLoadingScreen(int width, int height)
	{
		SwinGame.ProcessEvents();
		SwinGame.Delay(500);
		SwinGame.ClearScreen();
		SwinGame.RefreshScreen();
		SwinGame.FreeFont(_LoadingFont);
		SwinGame.FreeBitmap(_Background);
		SwinGame.FreeBitmap(_Animation);
		SwinGame.FreeBitmap(_LoaderEmpty);
		SwinGame.FreeBitmap(_LoaderFull);
		Audio.FreeSoundEffect(_StartSound);
		SwinGame.ChangeScreenSize(width, height);
	}

	/// <summary>
	/// Load new font
	/// </summary>
	/// <param name="fontname">name of font</param>
	/// <param name="filename">filename of font</param>
	/// <param name="size">font size</param>
	private static void NewFont(string fontName, string filename, int size)
	{
		_Fonts.Add(fontName, SwinGame.LoadFont(SwinGame.PathToResource(filename, ResourceKind.FontResource), size));
	}

	/// <summary>
	/// Load new image
	/// </summary>
	/// <param name="imageName">name of image</param>
	/// <param name="filename">filename of image</param>
	private static void NewImage(string imageName, string filename)
	{
		_Images.Add(imageName, SwinGame.LoadBitmap(SwinGame.PathToResource(filename, ResourceKind.BitmapResource)));
	}

	/// <summary>
	/// Load new transparent color image
	/// </summary>
	/// <param name="imageName">name of image</param>
	/// <param name="fileName">filename of image</param>
	/// <param name="transColor">transparent color</param>
	private static void NewTransparentColorImage(string imageName, string fileName, Color transColor)
	{
		_Images.Add(imageName, SwinGame.LoadBitmap(SwinGame.PathToResource(fileName, ResourceKind.BitmapResource), true, transColor));
	}

	/// <summary>
	/// Load new transparent colour image
	/// </summary>
	/// <param name="imageName">name of image</param>
	/// <param name="fileName">filename of image</param>
	/// <param name="transColor">transparent colour</param>
	private static void NewTransparentColourImage(string imageName, string fileName, Color transColor)
	{
		NewTransparentColorImage(imageName, fileName, transColor);
	}

	/// <summary>
	/// Load new sound
	/// </summary>
	/// <param name="soundName">name of sound</param>
	/// <param name="filename">filename of sound</param>
	private static void NewSound(string soundName, string filename)
	{
		_Sounds.Add(soundName, Audio.LoadSoundEffect(SwinGame.PathToResource(filename, ResourceKind.SoundResource)));
	}

	/// <summary>
	/// Load new music
	/// </summary>
	/// <param name="musicName">name of music</param>
	/// <param name="filename">filename of music</param>
	private static void NewMusic(string musicName, string filename)
	{
		_Music.Add(musicName, Audio.LoadMusic(SwinGame.PathToResource(filename, ResourceKind.SoundResource)));
	}

	/// <summary>
	/// Unload fonts
	/// </summary>
	private static void FreeFonts()
	{
		Font obj = default(Font);
		foreach ( obj in _Fonts.Values)
		{
			SwinGame.FreeFont(obj);
		}
	}

	/// <summary>
	/// Unload images
	/// </summary>
	private static void FreeImages()
	{
		Bitmap obj = default(Bitmap);
		foreach ( obj in _Images.Values)
		{
			SwinGame.FreeBitmap(obj);
		}
	}

	/// <summary>
	/// Unload sounds
	/// </summary>
	private static void FreeSounds()
	{
		SoundEffect obj = default(SoundEffect);
		foreach ( obj in _Sounds.Values)
		{
			Audio.FreeSoundEffect(obj);
		}
	}

	/// <summary>
	/// Unload music
	/// </summary>
	private static void FreeMusic()
	{
		Music obj = default(Music);
		foreach ( obj in _Music.Values)
		{
			Audio.FreeMusic(obj);
		}
	}

	/// <summary>
	/// Unload all resources
	/// </summary>
	public static void FreeResources()
	{
		FreeFonts();
		FreeImages();
		FreeMusic();
		FreeSounds();
		SwinGame.ProcessEvents();
	}
}
