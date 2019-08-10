using System;
using System.IO;
using System.Xml.Serialization;

namespace XmlDemo.Common.Helpers
{
    public static class XmlHelper
    {
        public static T DeserializeXmlString<T>(string xml)
        {
            try
            {
                return TryDeserializeXmlString<T>(xml);
            }
            catch (Exception e)
            {
                CatchDeserializeXmlString(e);
                throw;
            }
        }

        private static T TryDeserializeXmlString<T>(string xmlString)
        {
            using (TextReader reader = new StringReader(xmlString))
            {
                return (T)new XmlSerializer(typeof(T)).Deserialize(reader);
            }
        }

        private static void CatchDeserializeXmlString(Exception e)
        {
            ExceptionHelper.WriteExceptionToConsole(e, "Ett fel inträffade vid deserialiseringen");
        }



        public static string SerializeObject<T>(T obj)
        {
            try
            {
                return TrySerializeObject(obj);
            }
            catch (Exception e)
            {
                CatchSerializeObject(e);
                throw;
            }
        }

        private static string TrySerializeObject<T>(T obj)
        {
            if (ObjectIsNull(obj))
            {
                throw new ArgumentNullException("Kan inte serialisera ett objekt som är \"null\".");
            }

            using (StringWriter writer = new StringWriter())
            {
                var serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, obj);
                return writer.ToString();
            }
        }

        private static void CatchSerializeObject(Exception e)
        {
            ExceptionHelper.WriteExceptionToConsole(e, "Ett fel inträffade vid serialiseringen");
        }



        private static bool ObjectIsNull<T>(T obj)
        {
            return obj == null;
        }
    }
}
