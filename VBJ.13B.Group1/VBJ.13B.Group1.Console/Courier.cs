using System;
using System.Collections.Generic;

namespace VBJ._13B.Group1.Console
{
    /// <summary>
    /// Futár osztály, ki tud vinni csomagokat.
    /// Az osztály, olyan mint egy recept.
    /// </summary>
    public class Courier
    {
        // Field/ mező - mint egy lokális változó -> mindig private
        // Staticból csak egy van, bármennyi Couriert hozol létre
        private static int idIndex = 1;
        private static Random rnd = new Random();

        private List<Package> packages;

        // Konstruktor
        // Célja: példányosítás, inicializálás
        // Shortcut: ctor -> tab
        // Olyan mintha egy konkrét recept megvalósítás -> főzés
        // Fontos: megadja, hogy az adott osztály, miket használ
        // -> dependenciák, függőségek
        // Itt a dependencia a név (Dependency Injection) (DI)
        public Courier(string name)
        {
            Name = name;
            ID = idIndex++;
            packages = new List<Package>();
        }

        // Tulajdonság -> Azért lett kitalálva, hogyan férjünk hozzá a mezőkhöz.
        // Alapértelmezetten, ha nincs mögötte mező, akkor létrejön rejtetten.
        // Shortcut: prop -> tab
        public int ID { get; }

        // Immutable -> nem megváltoztatható a program során
        public string Name { get; }

        // Csomagfelvétel, a futár felvesz egy csomagot.
        // Visszatérési érték -> sikerült-e felvenni a csomagot.
        public bool PickUpPackage(Package package)
        {
            var packageCount = packages.Count;

            packages.Add(package);
            return true;
        }
    }
}
