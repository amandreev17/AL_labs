using Mylib;
using System.Reflection;
using System.Xml.Linq;

Assembly assembly = Assembly.Load("MyLib");
var types = assembly.GetExportedTypes();
XElement xElement = new XElement("Program");
foreach(var type in types)
{
    XElement element = new XElement(type.Name);
    if (type.IsEnum)
    {
        element.Add(new XElement("MyComment", type.GetCustomAttribute<MyComment>()!.Comment));
        XElement elmentValues = new XElement("Values");
        foreach(var val in type.GetEnumValues())
        {
            elmentValues.Add(val + " ");
        }
        element.Add(elmentValues);
    }
    else
    {
        if (type.Name == "MyComment")
        {
            element.Add(new XElement("Properties", from t in type.GetProperties() select t.Name + " "));
        }
        else
        {
            element.Add(new XElement("MyComment", type.GetCustomAttribute<MyComment>()!.Comment),
                new XElement("Properties", from t in type.GetProperties() select t.Name + " "),
                new XElement("Methods",
                from t in type.GetMethods()
                where (!t.Name.StartsWith("get_") && !t.Name.StartsWith("set_"))
                select t.Name + " "));

        }
    }
    xElement.Add(element);
}

XDocument xDocument = new XDocument(xElement);
xDocument.Save("/Users/olesaandreeva/Desktop/lab07.xml");