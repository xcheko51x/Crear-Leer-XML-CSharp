using System;
using System.Xml;

namespace EjemploCrearLeerXML
{
    class Program
    {
        static void Main(string[] args)
        {
            //crearXML();
            leerXML();
        }

        public static void leerXML() {
            XmlDocument document = new XmlDocument();

            document.Load("/Users/xcheko51x/Downloads/usuarios.xml");

            foreach(XmlNode node in document.DocumentElement.ChildNodes) { 
                if(node.HasChildNodes) { 
                    for(int i = 0; i < node.ChildNodes.Count; i++) {
                        Console.WriteLine(node.ChildNodes[i].Name + ": " + node.ChildNodes[i].InnerText);
                    }
                }
            }

            Console.ReadKey();
        }

        public static void crearXML() {
            XmlDocument document = new XmlDocument();

            XmlDeclaration xmlDeclaration = document.CreateXmlDeclaration("1.0","UTF-8", null);

            XmlElement raiz = document.DocumentElement;
            document.InsertBefore(xmlDeclaration, raiz);

            XmlElement usuarios = document.CreateElement(string.Empty, "usuarios", string.Empty);
            document.AppendChild(usuarios);

            XmlElement usuario = document.CreateElement(string.Empty, "usuario", string.Empty);
            usuarios.AppendChild(usuario);

            XmlElement id = document.CreateElement(string.Empty, "id", string.Empty);
            XmlText textId = document.CreateTextNode("1");
            id.AppendChild(textId);
            usuario.AppendChild(id);

            XmlElement nombre = document.CreateElement(string.Empty, "nombre", string.Empty);
            XmlText textNombre = document.CreateTextNode("Sergio P");
            nombre.AppendChild(textNombre);
            usuario.AppendChild(nombre);

            XmlElement telefono = document.CreateElement(string.Empty, "telefono", string.Empty);
            XmlText textTelefono = document.CreateTextNode("123244534");
            telefono.AppendChild(textTelefono);
            usuario.AppendChild(telefono);

            XmlElement email = document.CreateElement(string.Empty, "email", string.Empty);
            XmlText textEmail = document.CreateTextNode("sergio@hola.es");
            email.AppendChild(textEmail);
            usuario.AppendChild(email);

            document.Save("/Users/xcheko51x/Downloads/usuarios.xml");
        }
    }
}
