using MyLib;
using System.Xml.Serialization;

XmlSerializer xmlSerializer = new XmlSerializer(typeof(Animal));
StreamReader reader = new StreamReader("/Users/olesaandreeva/Desktop/lab08.xml");
Animal? animal = xmlSerializer.Deserialize(reader) as Animal;
Console.WriteLine($"Name: {animal?.Name} Country: {animal?.Country} HideFromOtherAnimals: {animal?.HideFromOtherAnimals} WhatAnimal: {animal?.WhatAnimal}");



