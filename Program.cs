using System.Linq;
using System.Xml.Linq;

namespace LogsChanger9000
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "C:/Users/Vansir/Desktop/LogsChanger9000/test.xml";
            string newFilePath = "C:/Users/Vansir/Desktop/LogsChanger9000/results.xml";
            string stageName = "Start";

            XDocument xmlFile = XDocument.Load(filePath);
            
            var allStages = from element in xmlFile.Elements("process").Elements("stage")
            select element;

            foreach (XElement element in allStages) 
            {
                if (element.Attribute("type").Value == stageName)
                {   
                    var childElements = from child in element.Elements("loginhibit")
                    select child;
                    foreach (XElement child in childElements)
                    {
                        child.Remove();
                    }
                    //linijka ponizej tylko do testow
                    element.Attribute("type").Value = "a co to sie stalo?";
                }
            }
            xmlFile.Save(newFilePath);
        }
    }
}
