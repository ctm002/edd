using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security;
using System.Net;

namespace Portal.Controller
{
    public class UtilController
    {
        /// <summary>
        /// Toma un Xml y lo escapa
        /// </summary>
        /// <param name="s">String xml a escapar</param>
        /// <returns></returns>
        public static string EscapeXML(string sXml)
        {

            if (string.IsNullOrEmpty(sXml))
            {
                return sXml;
            }

            return !SecurityElement.IsValidText(sXml)
            ? SecurityElement.Escape(sXml) : sXml;

        }

        /// <summary>
        /// Toma un xml escapado y lo regulariza
        /// </summary>
        /// <param name="s">String xml escapado a regularizar</param>
        /// <returns></returns>
        public static string UnescapeXML(string sXml)
        {

            if (string.IsNullOrEmpty(sXml))
            {
                return sXml;
            }

            string returnString = sXml;
            returnString = returnString.Replace("&apos;", "'");
            returnString = returnString.Replace("&quot;", "\"");
            returnString = returnString.Replace("&gt;", ">");
            returnString = returnString.Replace("&lt;", "<");
            returnString = returnString.Replace("&amp;", "&");
            return returnString;
        }

        /// <summary>
        /// Metodo que retorna la data de una url externa
        /// </summary>
        /// <param name="sUrl">Url a procesar</param>
        /// <returns>Resultado del proceso</returns>
        public static string OpenUrlExtern(string sUrl)
        {
            WebClient urlGrabber = new WebClient();
            byte[] html = urlGrabber.DownloadData(sUrl);
            //use the UTF8Encoding object to convert the byte
            //array into a string
            UTF8Encoding utf = new UTF8Encoding();
            //return the converted string
            urlGrabber.Dispose();
            return utf.GetString(html);
        }
    }
}
