using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Superbest_random;

namespace first.console.solution
{
	class OrbitingBody {
		public static int Instances = 0;
		public double Mass = 0;				//in grams
		public double Diameter = 0;			//in meters
		public int OrbitingRadius = 0;
		static Random generate = new Random();



		public OrbitingBody (){
			Instances++;
			OrbitingRadius = generate.Next(100,1500);
			Mass = generate.Next (0,1000);
		}
		public void SetMass (double min, double max){
			Mass = generate.NextDouble() * (max - min) + min;
		}
	}
	class Star: OrbitingBody {
		string StarCategory;
		string StarSize;
		string StarColor;
		string StarType;


		static string[] StarCategoryArray = new string[]{
			"Star", "Neutron Star","Black Hole","Supernova"
		};
		static string[] StarColorArray = new string[] {
			"Red", "Orange", "Yellow", "Yellow White", "White", "Blue White", "Blue"
		};
		static string[] StarSizeArray = new string[] {
			"Dwarf", "Giant", "Supergiant", "Hypergiant"
		};
		static Choose Dice = new Choose ();

		public Star(){
			StarCategory = StarCategoryArray [Dice.Roll (new int[]{ 950, 15, 7, 4 })];

			if (StarCategory == "Star") {
				StarColor = StarColorArray [Dice.Roll (new int[]{ 765, 121, 76, 30, 6, 2, 1})];
				StarSize = StarSizeArray [Dice.Roll (new int[]{ 80, 16, 3, 1 })];
			} else {
				StarType = StarCategory;
				StarColor = "N/A";
				StarSize = "N/A";
			}
			if (StarColor == "Red") {
				if (StarSize == "Dwarf") {
					SetMass (0.15E33, 0.9E33);				
				} else if (StarSize == "Giant") {
					SetMass (1E33, 8E33);
				}else if(StarSize == "Supergiant"){
					SetMass (8.1E33, 12E33);
				}else if(StarSize=="Hypergiant"){
					SetMass (12.1E33, 20E33);
				}
				Diameter = (Mass / 1E33) * 14E8;
			} else if (StarColor == "Orange") {
				if (StarSize == "Dwarf") {
					SetMass (0.9E33, 1.6E33);				
				} else if (StarSize == "Giant") {
					SetMass (1.7E33, 8.6E33);
				}else if(StarSize == "Supergiant"){
					SetMass (8.7E33, 15E33);
				}else if(StarSize=="Hypergiant"){
					SetMass (15.1E33, 26E33);
				}	
				Diameter = (Mass / 1E33) * 12E8;
			} else if (StarColor == "Yellow") {
				if (StarSize == "Dwarf") {
					SetMass (1.6E33, 2.08E33);				
				} else if (StarSize == "Giant") {
					SetMass (2.09E33, 9E33);
				}else if(StarSize == "Supergiant"){
					SetMass (9.1E33, 18E33);
				}else if(StarSize=="Hypergiant"){
					SetMass (18.1E33, 40E33);
				}	
				Diameter = (Mass / 1E33) * 10E8;
			} else if (StarColor == "Yellow White") {
				if (StarSize == "Dwarf") {
					SetMass (2.08E33, 2.8E33);			
				} else if (StarSize == "Giant") {
					SetMass (2.9E33, 10.5E33);
				}else if(StarSize == "Supergiant"){
					SetMass (10.6E33, 20E33);
				}else if(StarSize=="Hypergiant"){
					SetMass (20.1E33, 44E33);
				}	
				Diameter = (Mass / 1E33) * 3.5E8;
			} else if (StarColor == "White") {
				if (StarSize == "Dwarf") {
					SetMass (2.8E33, 4.2E33);			
				} else if (StarSize == "Giant") {
					SetMass (4.3E33, 12E33);
				}else if(StarSize == "Supergiant"){
					SetMass (12.1E33, 25E33);
				}else if(StarSize=="Hypergiant"){
					SetMass (25.1E33, 48E33);
				}		
				Diameter = (Mass / 1E33) * 2.5E8;
			} else if (StarColor == "Blue White") {
				if (StarSize == "Dwarf") {
					SetMass (4.2E33, 32E33);			
				} else if (StarSize == "Giant") {
					SetMass (32.1E33, 40.3E33);
				}else if(StarSize == "Supergiant"){
					SetMass (40.4E33, 62.5E33);
				}else if(StarSize=="Hypergiant"){
					SetMass (62.5E33, 87E33);
				}	
				Diameter = (Mass / 1E33) * 1.5E8;
			} else if (StarColor == "Blue") {
				if (StarSize == "Dwarf") {
					SetMass (32E33, 64E33);			
				} else if (StarSize == "Giant") {
					SetMass (64.1E33, 82.2E33);
				}else if(StarSize == "Supergiant"){
					SetMass (82.3E33, 122E33);
				}else if(StarSize=="Hypergiant"){
					SetMass (122.1E33, 235E33);
				}
				Diameter = (Mass / 1E33) * 1E8;
			}
			if (StarCategory == "Black Hole") {
				SetMass (10E33, 80E33);
			} else if (StarCategory == "Supernova") {
				Mass = double.NaN;
			} else if (StarCategory == "Neutron Star") {
				SetMass (2.2E33, 6E33);
			}
			if (StarCategory == "Star") {
				StarType = StarColor + " " + StarSize;
			}
		}
		public void Print (){
			Console.WriteLine ("Category           : " + StarCategory);
			if(StarCategory != StarType){
				Console.WriteLine (" Type              : " + StarType);
				Console.WriteLine (" Diameter          : " + Diameter.ToString("E2"));
			}

			Console.WriteLine (" Distance to center: " + OrbitingRadius);
			Console.WriteLine (" Mass              : " + Mass.ToString("E2"));
		}

		public JObject toJObject(){
			JObject o = new JObject (); //The object to be returned.
			JValue jMass = new JValue (Mass);
			JValue jOR = new JValue (OrbitingRadius);
			JValue jCat = new JValue (StarCategory);
			JValue jType = new JValue (StarType);
			JValue jDiameter = new JValue (Diameter);
			o["Mass"] = jMass;
			o["Diameter"] = jDiameter;
			o["OrbitingRadius"] = jOR;
			o["StarCategory"] = jCat;
			o["StarType"] = jType;
			return o;
		}
	}

	class Planet: OrbitingBody {
		public string PlanetType;
		public static List <string> PlanetTypeList = new List<string>{
			"Volcanic","Barren","Continental","Oceanic","Gas Giant"
		};
		static Random Generate = new Random ();
		public string Name;

		Planet[] Moons;

		public Planet(int nummoons){
			int x = Generate.Next (0, PlanetTypeList.Count);
			PlanetType = PlanetTypeList [x];

			if (nummoons < 0) {
				nummoons = Generate.Next(0,3);
			}

			Moons = new Planet[nummoons];
			for (int i = 0; i < nummoons; i++) {
				Moons [i] = new Planet (0);
			}

			//Set the name:
			Name = "Planet" + Instances;
		}

		public void Print (string h){
			Console.WriteLine (h + "Name:              : " + Name);
			Console.WriteLine (h + "Type               : " + PlanetType);
			Console.WriteLine (h + " Distance to center: " + OrbitingRadius);
			Console.WriteLine (h + " Mass              : " + Mass);
			Console.WriteLine (h + " Number of moons   : " + Moons.Length);
			for (int i = 0; i < Moons.Length; i++) {
				Moons [i].Print("   ");
			}

		}

		public JObject toJObject(){
			JObject o = new JObject (); //The object to be returned.
			JValue jMass = new JValue (Mass);
			JValue jOR = new JValue (OrbitingRadius);
			JValue jType = new JValue(PlanetType);
			JValue jName = new JValue(Name);
			JValue jDiameter = new JValue(Diameter);

			o["Mass"] = jMass;
			o["Diameter"] = jDiameter;
			o["OrbitingRadius"] = jOR;
			o["PlanetType"] = jType;
			o["Name"] = jName;

			//Moon array:
			JArray jmoons = new JArray();

			for (int i = 0; i < Moons.Length; i++) {
				JObject m = Moons [i].toJObject ();
				jmoons.Add (m);
			}

			if (Moons.Length > 0) {
				o ["Moons"] = jmoons;
			}

			return o;
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
			Console.WriteLine ("Testing");


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

		public static JArray StarArraytoJObject(Star[] s){
			JArray arr = new JArray ();
			for (int i =0;i<s.Length;i++){
				arr.Add (s [i].toJObject ());
			}
			return arr;
		}

		public static JArray PlanetArraytoJObject(Planet[] s){
			JArray arr = new JArray ();
			for (int i =0;i<s.Length;i++){
				arr.Add (s[i].toJObject ());
			}
			return arr;
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

			int PlanetAmount = Generate.Next (4,9);
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

			//Meuk van Dick:

			//Build Json objects, and write them to file.
			JObject jsector = new JObject ();
			JArray s = StarArraytoJObject (Stars);
			JArray p = PlanetArraytoJObject (Planets);
			if (Stars.Length > 0) {
				jsector ["Stars"] = s;
			}
			if (Planets.Length > 0) {
				jsector ["Planets"] = p;
			}
			string jsonstring = "var solarsystem = " + jsector.ToString () + ";";
			File.WriteAllText("output.json", jsonstring);
			//End write to file.

			//Show me the file.
			//Console.WriteLine (jsonstring);

			//Test gaussian distribution.


		}
	}
}
