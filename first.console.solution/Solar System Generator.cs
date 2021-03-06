using System;

namespace first.console.solution
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			for (int i = 1; i == 1; i = 1) 
			{
				PlanetGen();
				Console.WriteLine ();
				Console.WriteLine ("Press key to generate new solar system");
				Console.WriteLine ();
				Console.WriteLine ();
				Console.ReadKey ();
			}

		}

		public static void PlanetGen ()
		{
			Random Generate = new Random ();

			int PlanetAmount = Generate.Next (0,16);

			string[] StarType = new string[5]; 
			StarType[0] = "yellow dwarf";
			StarType[1] = "red dwarf";
			StarType[2] = "white dwarf";
			StarType[3] = "binary system";
			StarType[4] = "standard yellow star";


			string[] PlanetType = new string[5]; 
			PlanetType [0] = "barren";
			PlanetType [1] = "volcanic";
			PlanetType [2] = "gas giant";
			PlanetType [3] = "continental";
			PlanetType [4] = "oceanic";

			int StarRand = Generate.Next (1, 6);
			switch(StarRand) 
			{
			case 1:
				Console.WriteLine ("Star : " + StarType[0]);
				break;
			case 2:
				Console.WriteLine ("Star : " + StarType[1]);
				break;
			case 3:
				Console.WriteLine ("Star : " + StarType[2]);
				break;
			case 4:
				Console.WriteLine ("Star : " + StarType[3]);
				break;
			case 5:
				Console.WriteLine ("Star : " + StarType[4]);
				break;
			}

			if (PlanetAmount == 0) 
			{
				Console.WriteLine ("There are no planets in this system.");
			}

			for (int i = 1; i <= PlanetAmount; i++)
			{
				

				if (i < 3) 
				{
					Console.WriteLine ("Planet " + i + " : " + PlanetType [1]);
				} 
				else if (i > 6) {
					int PlanetRand01 = Generate.Next (1, 3);
					switch (PlanetRand01) 
					{
					case 1:
						Console.WriteLine ("Planet " + i + " : " + PlanetType [0]);
						break;
					case 2:
						Console.WriteLine ("Planet " + i + " : " + PlanetType [2]);
						break;
					}
				} 
				else 
				{
					int PlanetRand02 = Generate.Next (1,4);
					switch (PlanetRand02)
					{
					case 1:
						Console.WriteLine ("Planet " + i + " : " + PlanetType [0]);
						break;
					case 2: 
						Console.WriteLine ("Planet " + i + " : " + PlanetType [3]);
						break;
					case 3:
						Console.WriteLine ("Planet " + i + " : " + PlanetType [4]);
						break;
					}
				}
			}


		}

	}
}
