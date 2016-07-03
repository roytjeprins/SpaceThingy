using System;
using System.Collections.Generic;

namespace first.console.solution
{
	class OrbitingBody {
		public double Mass = 0;
		public int OrbitingRadius = 0;
		static Random generate = new Random();

		public OrbitingBody (){
			OrbitingRadius = generate.Next(0,1000);
			Mass = generate.Next (0,1000);
		}
		public void SetMass (double min, double max){
			Mass = generate.NextDouble() * (max - min) + min;
		}

	}
	class Star: OrbitingBody {
		string StarCategory;
		string StarType;


		static string[] StarCategoryArray = new string[]{
			"Star", "Pulsar","Black Hole","Supernova"
		};
		static string[] StarTypeArray = new string[] {
			"Red Dwarf", "Orange Dwarf", "Yellow Star", "White Dwarf", "White Giant", "Blue Giant", "Blue Hypergiant"
		};
		static Choose Dice = new Choose ();

		public Star(){
			StarCategory = StarCategoryArray [Dice.Roll (new int[]{ 95, 3, 2, 1 })];

			if (StarCategory == "Star") {
				StarType = StarTypeArray [Dice.Roll (new int[]{ 765, 121, 76, 30, 6, 2, 1})];				
			} else {
				StarType = StarCategory;
			}
			if (StarType == "Red Dwarf") {
				SetMass (0.15E33, 0.9E33);
			} else if (StarType == "Orange Dwarf") {
				SetMass (0.9E33, 1.6E33);
			} else if (StarType == "Yellow Star") {
				SetMass (1.6E33, 2.08E33);
			} else if (StarType == "White Dwarf") {
				SetMass (2.08E33, 2.8E33);
			} else if (StarType == "White Giant") {
				SetMass (2.8E33, 4.2E33);
			} else if (StarType == "Blue Giant") {
				SetMass (4.2E33, 32E33);
			} else if (StarType == "Blue Hypergiant") {
				SetMass (32E33, 64E33);
			} else if (StarType == "Black Hole") {
				SetMass (10E33, 80E33);
			} else if (StarType == "Supernova") {
				Mass = double.NaN;
			}
		}
		public void Print (){
			Console.WriteLine ("Category           : " + StarCategory);
			if(StarCategory != StarType){
				Console.WriteLine (" Type              : " + StarType);
			}

			Console.WriteLine (" Distance to center: " + OrbitingRadius);
			Console.WriteLine (" Mass              : " + Mass.ToString("E2"));
		}
	}

	class Planet: OrbitingBody {
		public string PlanetType;
		public static List <string> PlanetTypeList = new List<string>{
			"Volcanic","Barren","Continental","Oceanic","Gas Giant"
		};
		static Random Generate = new Random ();

		Planet[] Moons;

		public Planet(int nummoons){
			int x = Generate.Next (0, PlanetTypeList.Count);
			PlanetType = PlanetTypeList [x];

			if (nummoons < 0) {
				nummoons = Generate.Next(0,5);
			}
				
			Moons = new Planet[nummoons];
			for (int i = 0; i < nummoons; i++) {					
				Moons [i] = new Planet (0);	
		 	}		
		}

		public void Print (string h){
			Console.WriteLine (h + "Type               : " + PlanetType);
			Console.WriteLine (h + " Distance to center: " + OrbitingRadius);
			Console.WriteLine (h + " Mass              : " + Mass);
			Console.WriteLine (h + " Number of moons   : " + Moons.Length);
			for (int i = 0; i < Moons.Length; i++) {
				Moons [i].Print("   ");
			}
		
		}

	}

	public class Choose{
		static Random Generate = new Random ();

		public int Roll (int[] a){
			int l = a.Length;
			int max = 0;
			for (int i = 0; i < l; i++) {
				max += a[i];
			}
			int x = Generate.Next (0, max);
			max = 0;
			for (int i = 0; i < l; i++) {
				int oldmax = max; 
				max += a[i];
				if ((x >= oldmax)&&(x < max)){
					return i;
				}
			}
			return 0;
		}
		
	}
	class MainClass
	{
		public static void Main (string[] args)
		{
			for (int i = 1; i == 1; i = 1) 
			{
				SolarSystemGen ();
				Console.WriteLine ();
				Console.WriteLine ("Press key to generate new solar system");
				Console.WriteLine ();
				Console.WriteLine ();
				Console.ReadKey ();
				Console.Clear ();
			}

		}


		public static void PrintBody(OrbitingBody[] b){
			for (int i = 0; i < b.Length; i++) {
				Console.WriteLine ("Body.Mass           = " + b[i].Mass);
				Console.WriteLine ("Body.OrbitingRadius = " + b[i].OrbitingRadius);
			}
		}

		public static void PrintPlanetArray(Planet[] ps){
			for (int i = 0; i < ps.Length; i++) {
				ps[i].Print("");
			}

		}
		public static void PrintStarArray(Star[] ps){
			for (int i = 0; i < ps.Length; i++) {
				ps[i].Print();
			}
		}

		/*Creates stars and orbiting bodies.
		Step one: decide how many stars.
		Step two: decide star category.
		Step three: decide star type
		Step four: spawn planets*/
		public static void SolarSystemGen ()
		{
			Random Generate = new Random ();
			Choose Dice = new Choose ();

			int PlanetAmount = Generate.Next (0,1);
			int StarAmount = Dice.Roll (new int[] {800, 170, 26, 4}) + 1;
			//int[] bla = { 1, 2, 3 };

			Planet[] Planets = new Planet[PlanetAmount];

			Star[] Stars = new Star[StarAmount];

			for (int i = 0; i < StarAmount; i++) {
				int StarRand = Generate.Next (0, 5);
				Stars [i] = new Star();
				if (i == 0) {
					Stars [i].OrbitingRadius = 0;
				} else {
					Stars [i].OrbitingRadius = (Stars [i].OrbitingRadius % 5) + 1;
				}
			}


			for (int i = 0; i < PlanetAmount; i++)
			{
				Planets [i] = new Planet(-1);
			}
			Console.WriteLine ("Number of stars: " + StarAmount);
			PrintStarArray (Stars);

			if (PlanetAmount == 0) {
				Console.WriteLine ("There are no planets in this system.");
			} else 
			{

				Console.WriteLine ("There are " + PlanetAmount + " Planets in this system.");
				PrintPlanetArray (Planets);
			}



		}
	}
}
