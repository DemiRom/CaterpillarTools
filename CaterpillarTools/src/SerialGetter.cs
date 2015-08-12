using System;
using System.Windows.Forms;
using System.Xml;

namespace CaterpillarTools
{
    class SerialGetter
    {
        #region Fields

        private readonly XmlDocument _document;

        private string _engineSerial;
        private string _ecmSerial;
        private string _toolVersion;
        private string _toolSerial;
        #endregion

        public SerialGetter(String fileName)
        {
            try
            {
                _document = new XmlDocument();
                _document.Load(fileName);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            Init();
        }

        public SerialGetter(XmlDocument doc)
        {
            _document = doc;
            Init();
        }

        private void Init()
        {
            if (_document != null)
            {
                _ecmSerial = _document.GetElementsByTagName("Value")[0]?.InnerText.ToUpper();
                _engineSerial = _document.GetElementsByTagName("Value")[2]?.InnerText.ToUpper();
                _toolVersion = _document.GetElementsByTagName("ServiceToolVersionNumber")[0]?.InnerText.ToUpper();
                _toolSerial = _document.GetElementsByTagName("ServiceToolSerialNumber")[0]?.InnerText.ToUpper();
            }
        }

        public XmlDocument GetDocument()
        {
            return _document;
        }

        public string GetECMSerial()
        {
            return _ecmSerial;
        }

        public string GetENGSerial()
        {
            return _engineSerial;
        }

        public string GetTOOLVersion()
        {
            return _toolVersion;
        }

        public string GetTOOLSerial()
        {
            return _toolSerial;
        }
    }
}
