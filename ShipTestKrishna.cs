using NUnit.Framework;
using System;

namespace MyGame
{
	[TestFixture ()]
	public class ShipTestKrishna
	{
		[Test ()]
		public void TestCase ()
		{
			Ship myShip = new Ship (ShipName.Submarine);
			myShip.Hit ();

			Assert.IsTrue (myShip.Hits == 1);
			myShip.Hit ();
			myShip.Hit ();
			Assert.IsTrue (myShip.Hits == 3);
		}
	}
}

