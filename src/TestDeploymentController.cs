using NUnit.Framework;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
//using System.Data;
using System.Diagnostics;
using SwinGameSDK;

namespace MyGame
{
	/// <summary>
	/// Test deployment controller due to a bug in the file resulting in the player
	/// not being able to switch between left/right and up/down ship placement directions
	/// </summary>
	[TestFixture ()]
	public class TestDeploymentController
	{
		//Values taken from DeploymentController; they're the pixel positions of the buttons to swap directions
		const int UP_DOWN_BUTTON_LEFT = 410;
		const int LEFT_RIGHT_BUTTON_LEFT = 350;

		/// <summary>
		/// Tests the direction enumeration works
		/// </summary>
		[Test()]
		public void TestDirection ()
		{
			Direction _dirup = Direction.UpDown;
			Direction _dirleft = Direction.LeftRight;

			Assert.IsTrue(_dirup == Direction.UpDown);
			Assert.IsTrue(_dirleft == Direction.LeftRight);
			Assert.IsFalse(_dirup == _dirleft);
		}

		/// <summary>
		/// Tests the mouse positions of the buttons differ.
		/// </summary>
		[Test()]
		public void TestMousePositionsDiffer ()
		{
			Assert.IsFalse(UP_DOWN_BUTTON_LEFT == LEFT_RIGHT_BUTTON_LEFT);
		}

		/// <summary>
		/// Tests the direction value can be changed
		/// </summary>
		[Test()]
		public void TestSetDirection()
		{
			Direction _dir;
			_dir = Direction.UpDown;

			Assert.IsTrue(_dir == Direction.UpDown);

			_dir = Direction.LeftRight;
			Assert.IsTrue(_dir == Direction.LeftRight);
		}

		/// <summary>
		/// Tests that ships can be deployed with different directions
		/// </summary>
		[Test()]
		public void TestShipDirectionDeployment()
		{
			Direction _dirUp = Direction.UpDown;
			Direction _dirLeft = Direction.LeftRight;

			Ship uShip = new Ship(ShipName.Tug);
			Ship lShip = new Ship(ShipName.Tug);

			uShip.Deployed(_dirUp, 0, 0);
			lShip.Deployed(_dirLeft, 1, 1);

			Assert.IsTrue(uShip.Direction == Direction.UpDown);
			Assert.IsTrue(lShip.Direction == Direction.LeftRight);

			Assert.IsFalse(uShip.Direction == lShip.Direction);
		}
	}
}