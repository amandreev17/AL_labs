using System.Xml.Serialization;
using MyLib;

Animal animal = new Animal("Russia", "tiger", false, eClassificationAnimal.Herbivores);
XmlSerializer xmlSerializer = new XmlSerializer(typeof(Animal));
FileStream fileStream = new FileStream("/Users/olesaandreeva/Desktop/lab08.xml", FileMode.OpenOrCreate);
xmlSerializer.Serialize(fileStream, animal);
Console.WriteLine("Object has been serialized");

