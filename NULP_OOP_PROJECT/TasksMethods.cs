using Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPProject
{
    public class TasksMethods
    {
        // FORMING UNSORTED ARRAY FROM DATA FILE
        public static void ReadFromFile(Animal[] animals, string dataPath)
        {
            using StreamReader reader = new(dataPath);
            for (var i = 0; !reader.EndOfStream; i++)
            {
                var line = reader.ReadLine();
                var part = line!.Split(' ');
                switch (part[0].ToLower())
                {
                    case "horse":
                        animals[i] = new Horse
                        {
                            Name = part[1],
                            YearOfBirth = Convert.ToInt16(part[2]),
                            Color = part[3],
                            Breed = part[4]
                        };
                        Log.Debug($"Animal added to array: Horse {{ [{animals[i].Name}], [{animals[i].YearOfBirth}] }}");
                        break;
                    case "donkey":
                        animals[i] = new Donkey
                        {
                            Name = part[1],
                            YearOfBirth = Convert.ToInt16(part[2]),
                            Type = part[3],
                            Height = Convert.ToDouble(part[4])
                        };
                        Log.Debug($"Animal added to array: Donkey {{ [{animals[i].Name}], [{animals[i].YearOfBirth}] }}");
                        break;
                }
            }
        }
        // FORMING ARRAY OF ANIMALS SORTED BY BIRTH YEAR + OUTPUT IN TXT FILE
        public static void FirstTaskMethod(Animal[] animals, string firstOutputPath)
        {
            var sortedAnimals = animals.OrderBy(animal => animal.YearOfBirth);

            using (StreamWriter writer = new(firstOutputPath))
            {
                foreach (var animal in sortedAnimals)
                {
                    switch (animal)
                    {
                        case Horse horse:
                            writer.WriteLine($"Horse data\nname: {horse.Name}, birth year: {horse.YearOfBirth} breed: {horse.Breed}, color: {horse.Color}");
                            break;
                        case Donkey donkey:
                            writer.WriteLine($"Donkey data\nname: {donkey.Name}, birth year: {donkey.YearOfBirth}, type: {donkey.Type}, height: {donkey.Height}");
                            break;
                    }
                }
            }
            Log.Debug($"First task performed successfully, output file path: {firstOutputPath}");
        }
        // WHITE HORSES && SHORT DONKEYS (<1,5) OUTPUT IN TXT FILE
        public static void SecondTaskMethod(Animal[] animals, string secondOutputPath)
        {
            var horsesCount = 0;
            var donkeysCount = 0;
            using (StreamWriter writer = new(secondOutputPath))
            {
                foreach (var animal in animals)
                {
                    switch (animal)
                    {
                        case Horse horse when horse.Color.ToLower() == "white":
                            horsesCount++;
                            writer.WriteLine($"Horse data\nname: {horse.Name}, birth year: {horse.YearOfBirth} breed: {horse.Breed}, color: {horse.Color}");
                            break;
                        case Donkey { Height: <= 1.5 } donkey:
                            donkeysCount++;
                            writer.WriteLine($"Donkey data\nname: {donkey.Name}, birth year: {donkey.YearOfBirth}, type: {donkey.Type}, height: {donkey.Height}");
                            break;
                    }
                }
                writer.WriteLine($"\nWhite horses count: {horsesCount}");
                writer.WriteLine($"Donkeys shorter than 1.5 meters count: {donkeysCount}");
            }
            Log.Debug($"Second task performed successfully, output file path: {secondOutputPath}");
        }
        // CHECK IF DATA.TXT EXISTS, IF NO - CREATE A SAMPLE
        public static void DataFileEnsureCreated(string path)
        {
            if (File.Exists(path)) return;
            using var fs = File.Create(path);
            var info = new UTF8Encoding(true).GetBytes("Horse HORSE_NAME1 2005 WHITE HORSE_BREED1\n");
            fs.Write(info, 0, info.Length);
            info = new UTF8Encoding(true).GetBytes("Donkey DONKEY_NAME1 2015 DONKEY_TYPE1 1,1\n");
            fs.Write(info,0, info.Length);
            info = new UTF8Encoding(true).GetBytes("Donkey DONKEY_NAME2 2020 DONKEY_TYPE2 1,6\n");
            fs.Write(info, 0, info.Length);
            info = new UTF8Encoding(true).GetBytes("Horse HORSE_NAME3 2001 HORSE_COLOR3 HORSE_BREED3\n");
            fs.Write(info, 0, info.Length);
            info = new UTF8Encoding(true).GetBytes("Donkey DONKEY_NAME2 2000 DONKEY_TYPE2 0,9");
            fs.Write(info, 0, info.Length);
        }
        // CHECK IF FILES DIRECTORY EXISTS, IF NO - CREATE
        public static void FilesDirectoryEnsureCreated(string path)
        {
            if (Directory.Exists(path)) return;
            Directory.CreateDirectory(path);
        }
    }
}
