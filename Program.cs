using System;
using System.Collections.Generic;
using System.Threading;

namespace WWII
{
	public class Unit
	{
		//Define soldiers. I think tank will be a seperate class?
		public int IdNum { get; set; }
		public string Type { get; set; }
		public string Name { get; set; }
		private int hp;
		public int Hp { 
			get
            {
				return hp;
            }
			set
			{
				if (value <1)
                {
					hp = 0;
					IsDead = true;
                }
				else
                {
					hp = value;
                }
			}
		}
		
		public int Leadership { get; set; }
		private int ammo;
		public int Ammo
		{
			get
			{
				return ammo;
			}
			set
			{
				if (value < 1)
				{
					ammo = 0;
				}
				else
				{
					ammo = value;
				}
			}
		}

		public int FireRate { get; set; }
		public int Accuracy { get; set; }
		
		public bool IsActive { get; set; }

		public bool IsDead { get; set; }

		public Unit(int idnum, string type, string name, int hp, int leadership, int ammo, int fireRate, int accuracy, bool isActive, bool isDead)
		{
			IdNum = idnum;
			Type = type;
			Name = name;
			
			Hp = hp;
			Leadership = leadership;
			Ammo = ammo;
			FireRate = fireRate;
			Accuracy = accuracy;
			

			IsActive = isActive;
			IsDead = isDead;
		}
		public void GetUnitDetails()
		{
            if (Hp < 1) { IsDead = true; }
			string active = "";
			if (IsActive) {active = "SELECTED"; }
			if (IsDead == false)
			{
				Console.WriteLine($"ID{IdNum} {Type}: Hp {Hp}, Bravery {Leadership}, Fire Rate {FireRate}, Aim {Accuracy},  Ammo {Ammo}  {Name} {active}");
			}
            else
            {
				Console.WriteLine($"DEAD: ID{IdNum} {Type}: {Name} {active}");
			}
		}

	}




















	class Program
	{








		static void Main(string[] args)
		{
			Console.WriteLine("Welcome to WWII");
			Console.ReadLine();
			Setup();
		}










		static void Setup()
		{
			//Define name arrays. Make player unit lists. Add 5 units to each list. Press enter then start battle.

			Random rand = new Random();
			string[] FirstNames = new string[104] { "Abelard", "Adie", "Adler", "Adolph", "Alaric", "Albert", "Albrecht", "Alger", "Ancel", "Arland", "Armand", "Arnold", "Avicus", "Baldwin", "Baltasar", "Baron", "Bergen", "Bernard", "Bernstein", "Bertram", "Bingham", "Bogart", "Brandeis", "Bronson", "Bud", "Burke", "Burle", "Carsten", "Clay", "Clovis", "Colbert", "Dagobert", "Dalbert", "Dale", "Derek", "Dewitt", "Dian", "Dieter", "Dietrich", "Dolf", "Drake", "Dutch", "Eberhard", "Egmont", "Elbert", "Emery", "Ethelred", "Everett", "Falk", "Ferdinand", "Dora", "Hans", "Franz", "Walfried", "Wendelgred", "Waldtraunt", "Wedis", /*RUSSIAN SECTION*/ "Adrian", "Akim", "Alek", "Alexei", "Andrey", "Anatoly", "Arkadi", "Armen", "Artyom", "Boris", "Damien", "Danyl", "Denis", "Dima", "Dimitri", "Eriks", "Hedeon", "Gennady", "Igor", "Ilias", "Ioann", "Ivan", "Iosif", "Niko", "Jeremie", "Karlin", "Kirill", "Konstantin", "Lev", "Leonid", "Ludis", "Maxim", "Mikhail", "Nikolai", "Oleg", "Olezka", "Pavel", "Rodion", "Rolan", "Ruslan", "Sacha", "Sergei", "Simeon", "Tima", "Vas", "Vasili", "Vlad" };
			string[] LastNames = new string[104] { "Altmann", "Ames", "Anders", "Angert", "Anschuetz", "Appel", "Biehl", "Biel", "Birk", "Blackert", "Blaschko", "Blatt", "Eben", "Eberhhardt", "Eckard", "Eckelman", "Edinger", "Egle", "Eichmann", "Gerwig", "Giebler", "Ginger", "Glaser", "Glassmann", "Goethe", "Gossmann", "Goth", "Grande", "Greber", "Heimacher", "Kafer", "Kahl", "Kalbach", "Kant", "Kaplan", "Lichtenberg", "Lieder", "Liebe", "Lillich", "Linde", "Lindt", "Neider", "Nessel", "Neuer", "Neumann", "Nickol", "Nimz", "Perleberg", "Pfeiffer", "Picker", "Pier", "Pine", "Pittman", "Ringwald", "Rinkel", "Ritter", "Rockefeller", /*RUSSIAN SECTION*/ "Ivanov", "Rabinovich", "Vasiliev", "Rozhdestvensky", "Semenov", "Bortnik", "Voznesensky", "Plotnikov", "Egorov", "Portnov", "Prostakov", "Rybakov", "Sobol", "Kalashnik", "Nikolaev", "Chugunkin", "Lenin", "Tortayev", "Meknikov", "Morozov", "Putin", "Rasputin", "Vinogradov", "Dmitriev", "Zima", "Petukhov", "Alexeev", "Bogomolov", "Molchalin", "Pavlov", "Chernov", "Gorky", "Agafonov", "Kamenev", "Krovopuskov", "Krupin", "Lagunov", "Molotov", "Pasternak", "Petukhov", "Sobolev", "Sorokin", "Stepanov", "Voronin", "Zhuravlev", "Zolotov", "Zhugalov" };
			//size is normal

			List<Unit> playerUnits = new List<Unit>();
			List<Unit> pcUnits = new List<Unit>();

			//Russian general
			Unit soldier = GenerateSoldier(0, 'k', rand, FirstNames, LastNames, false);
			playerUnits.Add(soldier);
			for (int i = 1; i < 6; i++)
			{
				//Russian solders
				soldier = GenerateSoldier(i, 'r', rand, FirstNames, LastNames, false);
				playerUnits.Add(soldier);
			}

			Console.WriteLine("");
			//German general
			soldier = GenerateSoldier(0, 'n', rand, FirstNames, LastNames, false);
			pcUnits.Add(soldier);

			for (int i = 1; i < 6; i++)
			{
				//German solders
				soldier = GenerateSoldier(i, 'g', rand, FirstNames, LastNames, false);
				pcUnits.Add(soldier);
			}

			DisplayUnits(playerUnits, pcUnits);
			Console.ReadLine();
			YourTurn(playerUnits, pcUnits, rand);

			/*
	-Purchase your army or be assigned a random one
-Generate army
- Print army
	 press enter
 - Select your terrain or be assigned random
		-enemy army generated
	press enter */
		}

		static void DisplayUnits(List<Unit> playerUnits, List<Unit> pcUnits)
        {
			Console.WriteLine("");
			foreach (Unit soldier in playerUnits)
            {
				soldier.GetUnitDetails();
            }
			Console.WriteLine("");
			foreach (Unit soldiers in pcUnits)
			{
				soldiers.GetUnitDetails();
			}
		}


		static void YourTurn(List<Unit> playerUnits, List<Unit> pcUnits, Random rand)
		{

			Console.WriteLine("Press 's' to shoot with all units");

			//the keystroke logger
			ConsoleKeyInfo keyinfo;
			do
			{
				keyinfo = Console.ReadKey();
				Console.WriteLine(keyinfo.Key + " was pressed");

				if (keyinfo.Key == ConsoleKey.S)
				{
					Console.WriteLine("shoot with all units");
					int[] enemyIdArray = new int[pcUnits.Count]; 
					int i = 0;
					int highestEnemyLeadership = 0;
					//map enemy soldiers to an enemyIdArray with no holes starting at 0.
					foreach (Unit enSoldier in pcUnits)
					{
						if (enSoldier.Leadership > highestEnemyLeadership) //sets enemy squad leadership to highest indiv. value 
                        {
							highestEnemyLeadership = enSoldier.Leadership;
                        }
						if (enSoldier.IsDead == false)
						{
							enemyIdArray[i] = enSoldier.IdNum;
						}
						i++;
					}
					//write enemy array
				/*	foreach (int j in enemyIdArray)
					{
						Console.WriteLine(enemyIdArray[j]);
					} */

					int target = 0;
					int targetUnit;
					//each of your soldiers shoot
					foreach (Unit soldier in playerUnits)
					{
						if (soldier.IsDead == false)
						{
							if (soldier.Ammo > 0) //I tried getting rid of array... didnt fix it
							{
								
								target = rand.Next(0, pcUnits.Count); //random place in enemy array 								target = rand.Next(0, enemyIdArray.Length);
																			//MAYBE JUST GET RID OF A LOT OF THESE FOREACH AND ADD ISDEAD PROPERTY
								//targetUnit = enemyIdArray[target]; //choose soldier the ID of the value at this random point in enemyIdArray   								targetUnit = enemyIdArray[target];
								foreach (Unit enSoldier in pcUnits)
								{
									if (enSoldier.IdNum == target && enSoldier.IsDead == true) //if target dead find another  									if (enSoldier.IdNum == targetUnit && enSoldier.IsDead == true)
									{
										target = rand.Next(0, pcUnits.Count);
									}
									else if (enSoldier.IdNum == target && enSoldier.IsDead == false) //if target
									{

									

									    if (Shoot(soldier, enSoldier, rand) == true) //hit?
										{
											CalculateDamage(soldier, enSoldier, rand, highestEnemyLeadership);
											if (enSoldier.Hp<1)
                                            {
												enSoldier.IsDead = true;
                                            }
											break;
										}
									
									} //theres paths that return no message for shoot w all.

								}

								soldier.Ammo -= soldier.FireRate;
							}
							else
							{
								Console.WriteLine($"{soldier.Type} {soldier.Name} is out of ammo.");
							}

						}



					}



					/*
					bool[] aboutToDie = new bool[10];
					int k = 0;
					foreach (Unit enSoldier in pcUnits) //declare death
					{
						if (enSoldier.Hp < 1)
						{
							Console.WriteLine($"{enSoldier.Type} {enSoldier.Name} killed.");
							aboutToDie[k] = true; //index2 dead. aboutToDie[2] == true. 
						}
						k++;
					}
					//k is size of abouttodie
					int z = 0;
					foreach (bool bol in aboutToDie)
                    {
						if (bol == true)
						{
							pcUnits.RemoveAt(z);
						}
						z++;
					}
					*/



				}
				DisplayUnits(playerUnits, pcUnits);




			}
			while (keyinfo.Key != ConsoleKey.X);

			/*
Check if units are broken
	Leadership check
	If false,
		units run/disappear

-move your units
	IF MOVE
	SELECT UNIT
	SELECT DIRECTION
	THEY MOVE ACCORDING TO SPEED
	msg result/display result

-shoot with your units or not
	IF SHOOT
	SELECT UNIT
	Check Ammo, 
	if false, msg 'no ammo'
	if true
	SELECT TARGET
	IF IN RANGE
	if false, msg 'no ammo'
	if true
	Calculate if hit (w cover modifier)
	Calculate if penetrate (w cover modifier)
	Calculate damage/injuries
	Msg result */
		}



		static bool Shoot(Unit shooter, Unit target, Random rand)
		{
			int hitScore = rand.Next(0, shooter.Accuracy);
			if (hitScore > 2)
			{
				return true;
			}
			else
			{
				Console.WriteLine($"{shooter.Type} {shooter.Name} misses  {target.Type} {target.Name}.");
				return false;
			}
		}


		static void CalculateDamage(Unit shooter, Unit target, Random rand, int highestEnemyLeadership)
		{
			int hitNum = rand.Next(0, 8);
			switch (hitNum)
			{
				case 0:
					{
						Console.WriteLine($"{shooter.Type} {shooter.Name} shoots a hole in {target.Type} {target.Name}'s clothing.");
						break;
					}
				case 1:
					{
						Console.WriteLine($"{shooter.Type} {shooter.Name} grazes {target.Type} {target.Name}");
						break;
					}
				case 2:
					{
						target.Hp -= 1;
						Console.WriteLine($"{shooter.Type} {shooter.Name} hits {target.Type} {target.Name} in the leg.");
						break;
					}
				case 3:
					{
						target.Hp -= 1;
						Console.WriteLine($"{shooter.Type} {shooter.Name} hits {target.Type} {target.Name} in the arm.");
						break;
					}
				case 4:
					{
						target.Hp -= 1;
						Console.WriteLine($"{shooter.Type} {shooter.Name} hits {target.Type} {target.Name} in the waist.");
						BreakTest(6, shooter, target, rand, highestEnemyLeadership);

						break;
					}
				case 5:
					{
						target.Hp -= 2;
						Console.WriteLine($"{shooter.Type} {shooter.Name} hits {target.Type} {target.Name} in the stomach.");
						BreakTest(7, shooter, target, rand, highestEnemyLeadership);

						break;
					}
				case 6:
					{
						target.Hp -= 3;
						Console.WriteLine($"{shooter.Type} {shooter.Name} hits {target.Type} {target.Name} in the vitals.");
						BreakTest(8, shooter, target, rand, highestEnemyLeadership);

						break;
					}
				case 7:
					{
						target.Hp -= 4;
						Console.WriteLine($"{shooter.Type} {shooter.Name} blows off {target.Type} {target.Name}'s head, possibly scaring the others.");
						BreakTest(9, shooter, target, rand, highestEnemyLeadership);

						break;
					}
				default:
					{
						Console.WriteLine($"{shooter.Type} {shooter.Name} shoots a DEFAULT hole in {target.Type} {target.Name}'s clothing.");
						break;
					}
			}  //moved message to before breaktest
			
		}

		static void BreakTest(int testDifficulty, Unit shooter, Unit target, Random rand, int highestLeadership)
		{
			int result = rand.Next(0, testDifficulty);
			//find highest bravery

			if (result > highestLeadership)
            {
				UnitsBreak(false);
            }
		}

		static void UnitsBreak(bool isRussian)
		{
			if (isRussian) { Console.WriteLine("Russians break!"); }
			else { Console.WriteLine("Germans break!"); }
		}

		static Unit GenerateSoldier(int idNum, char countryType, Random rand, string[] firstnames, string[] lastnames, bool isActive)
		{
			//r russian soldier, k russian captain. g german soldier, n german captain
			string name = "";
			string unitType = "";
			int hp = 2;
			int leadership = 4;
			int ammo = 0;
			int fireRate = 1;
			int accuracy = 5;
			switch (countryType) //Pass in the type of soldier and it generates name, sets values, creates object, & returns to add to list.
			{
				case 'r':
					unitType = "Russian soldier";
                    name = GenerateName(true, rand, firstnames, lastnames);
					if (name.Length == 12) { accuracy = 4; leadership = 3; }
					else if (name.Length == 14) { accuracy = 6; leadership = 5; };
					ammo = name.Length / 3;
					break;
				case 'k':
					unitType = "Russian Captain";
					name = GenerateName(true, rand, firstnames, lastnames);
					hp = 3;
					leadership = 6;
					ammo = name.Length;
					break;
				case 'g':
					unitType = "German Soldier";
					name = GenerateName(false, rand, firstnames, lastnames);
					if (name.Length == 12) { accuracy = 6; leadership = 5; }
					ammo = name.Length;
					leadership = 5;
					break;
				case 'n':
					unitType = "German Captain";
					name = GenerateName(false, rand, firstnames, lastnames);
					hp = 3;
					leadership = 7;
					accuracy = 6;
					ammo = name.Length;
					break;
			}


			//create unactive random soldier
			Unit soldier = new Unit(idNum, unitType, name, hp, leadership, ammo, fireRate, accuracy, false, false);
			return soldier;
		}


		static string GenerateName(bool isRussian, Random rand, string[] firstnames, string[] lastnames)
		{
			int randomNum = 0;
			string firstName = "";
			string lastName = "";

			if (isRussian == false)
			{
				randomNum = rand.Next(0, 59);
				firstName = firstnames[randomNum];
				Thread.Sleep(17);
				randomNum = rand.Next(0, 59);
				lastName = lastnames[randomNum];
			}
			else
			{
				//58-104 in either array are the russian names
				randomNum = rand.Next(58, 104);
				firstName = firstnames[randomNum];
				Thread.Sleep(16);
				randomNum = rand.Next(58, 104);
				lastName = lastnames[randomNum];
			}

			//ger name
			string result = ($"{firstName} {lastName}");
			return result;

			/*
	check what unit type and make name */
		}













































	}
}







