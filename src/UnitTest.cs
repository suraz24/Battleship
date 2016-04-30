/// <summary>
/// Zaid Shakil
/// </summary>

using System;
using NUnit.Framework;

[TestFixture]
public static class UnitTest
{

    /// <summary>
    /// NUnit testing 
    /// </summary>
    private static void MockRunTheGameFromScratch()
    {
        GameController.SetupInitialStateStack();
        GameController.AddNewState(GameState.Deploying); // simulate being in the deploying screen 
    }

    /// <summary>
    /// NUnit testing 
    /// </summary>
    [Test] // (these methods must return void and take no parameters) 
    public static void MockDeployingState()
    {
        MockRunTheGameFromScratch();
        Assert.AreEqual(GameState.Deploying, GameController.CurrentState); // test that GameController reports it as current state 
    }

    /// <summary>
    /// NUnit testing 
    /// </summary>
    [Test] // (these methods must return void and take no parameters) 
    public static void MockPerformMenuAction()
    {
        MockRunTheGameFromScratch();
        MenuController.PerformMenuAction(MenuController.DEPLOYING_MENU, MenuController.DEPLOYING_MENU_BACK_BUTTON); // simulate pushing the menu item 
        Assert.AreEqual(GameState.ViewingMainMenu, GameController.CurrentState); // test that GameController "went to main menu" 
    }

    /// <summary>
    /// NUnit testing 
    /// </summary>
    [Test] // (these methods must return void and take no parameters) 
    public static void MockPerformDeployingMenuAction()
    {
        MockRunTheGameFromScratch();
        MenuController.PerformDeployingMenuAction(MenuController.DEPLOYING_MENU_BACK_BUTTON); // simulate pushing the menu item 
        Assert.AreEqual(GameState.ViewingMainMenu, GameController.CurrentState); // test that GameController "went to main menu" 
    }
}

