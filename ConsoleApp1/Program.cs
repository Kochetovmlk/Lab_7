using Lab_07.comment;
using Lab_07.myclass;
using System.Reflection;
using System.Xml;

class Program
{
    static void Main()
    {
        // Создаем новый XML-документ.
        XmlDocument doc = new XmlDocument();
        // Создаем корневой элемент "ClassDiagram".
        XmlElement rootElement = doc.CreateElement("ClassDiagram");
        // Добавляем корневой элемент к документу.
        doc.AppendChild(rootElement);

        // Загружаем сборку "Lab_07", содержащую классы с пользовательским атрибутом.
        Assembly asm = Assembly.Load("Lab_07");
        // Получаем все типы из загруженной сборки.
        Type[] types = asm.GetTypes();
        // Проходимся по каждому типу.
        foreach (Type t in types)
        {
            // Проверяем, принадлежит ли тип пространству имен "Lab_07".
            if (t.Namespace.Contains("Lab_07"))
            {
                // Инициализируем строку "str" значением null.
                string str = null;
                // Проверяем, является ли тип классом.
                if (t.IsClass) { str = "Class"; }
                // Проверяем, является ли тип перечислением.
                if (t.IsEnum) { str = "Enum"; }
                // Создаем XML-элемент с именем, соответствующим типу (Class или Enum).
                XmlElement element = doc.CreateElement(str);
                // Добавляем созданный элемент в корневой элемент.
                rootElement.AppendChild(element);
                // Устанавливаем атрибут "name" элемента, равным имени типа.
                element.SetAttribute("name", t.Name);

                // Получаем пользовательский атрибут CommentAttribute для текущего типа.
                CommentAttribute comment = (CommentAttribute)t.GetCustomAttribute(typeof(CommentAttribute));
                // Создаем XML-элемент "comment".
                XmlElement c_element = doc.CreateElement("comment");

                // Проверяем, был ли найден атрибут CommentAttribute.
                if (comment !=  null)
                { 
                    c_element.InnerText = comment.Comment; 
                    element.AppendChild(c_element); 
                }

                // Получаем все свойства текущего типа.
                object[] propiproperties = t.GetProperties();
                // Проходимся по каждому свойству.
                foreach (object p in propiproperties)
                {
                    // Создаем XML-элемент "properties".
                    XmlElement p_element = doc.CreateElement("properties");
                    // Устанавливаем текстовое значение элемента "properties" равным строковому представлению свойства.
                    p_element.InnerText = p.ToString();
                    // Добавляем элемент "properties" к текущему элементу (Class или Enum).
                    element.AppendChild(p_element);
                }

                // Получаем все методы текущего типа.
                object[] methods = t.GetMethods(/*BindingFlags.DeclaredOnly*/);
                // Проходимся по каждому методу.
                foreach (object m in methods)
                {
                    // Создаем XML-элемент "methods".
                    XmlElement m_element = doc.CreateElement("methods");
                    // Устанавливаем текстовое значение элемента "methods" равным строковому представлению метода.
                    m_element.InnerText = m.ToString();
                    // Добавляем элемент "properties" к текущему элементу (Class или Enum).
                    element.AppendChild(m_element);
                }
            }
        }
        doc.Save(Console.Out);
    }
}