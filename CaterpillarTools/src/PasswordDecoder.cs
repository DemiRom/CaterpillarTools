using System;
using System.Windows.Forms;
using System.Xml;

namespace CaterpillarTools
{
    class PasswordDecoder
    {
        #region Fields

        private readonly XmlDocument _document;

        private readonly string[] _rawPassword = new string[3];
        private readonly string[] _modPassword = new string[3];
        private string[] _password     = new string[3];

        private bool _whitespace;

        #endregion

        public PasswordDecoder(string fileName)
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

            GetEncryptedData();
            RemoveParasite();
            GetPassword();
        }

        #region AlgorithmVoid

        private void GetEncryptedData()
        {
            for (int i = 0; i < _password.Length; i++)
            {
                _rawPassword[i] = _document.GetElementsByTagName("RealValue")[i]?.InnerText;
            }
        }

        private void RemoveParasite()
        {
            for (int i = 0; i < _rawPassword.Length; i++)
            {
                for (int j = 6; j < _rawPassword[i].Length; j+=6)
                {
                    _modPassword[i] += _rawPassword[i].Substring(j, 2);
                    j += 2; 

                }
            }
        }

        private string[] GetPassword()
        {
            string[] ret = new string[3];

            for (int i = 0; i < _modPassword.Length; i++)
            {
                for (int j = 0; j < _modPassword[i].Length/2; j++)
                {
                    switch (_modPassword[i].Substring(j*2, 2).ToUpper())
                    {
                        case "A5":
                            ret[i] += _whitespace ? Dictionary.Alphabet[(int)Characters.A5W] : Dictionary.Alphabet[(int)Characters.A5];
                            break;

                        case "B0":
                            ret[i] += Dictionary.Alphabet[(int) Characters.B0];
                            break;
                        case "B1":
                            ret[i] += Dictionary.Alphabet[(int) Characters.B1];
                            break;
                        case "B2":
                            ret[i] += Dictionary.Alphabet[(int) Characters.B2];
                            break;
                        case "B3":
                            ret[i] += Dictionary.Alphabet[(int) Characters.B3];
                            break;
                        case "B4":
                            ret[i] += Dictionary.Alphabet[(int) Characters.B4];
                            break;
                        case "B5":
                            ret[i] += Dictionary.Alphabet[(int) Characters.B5];
                            break;
                        case "B6":
                            ret[i] += Dictionary.Alphabet[(int) Characters.B6];
                            break;
                        case "B7":
                            ret[i] += Dictionary.Alphabet[(int) Characters.B7];
                            break;
                        case "B8":
                            ret[i] += Dictionary.Alphabet[(int) Characters.B8];
                            break;
                        case "B9":
                            ret[i] += Dictionary.Alphabet[(int) Characters.B9];
                            break;

                        case "C0":
                            ret[i] += Dictionary.Alphabet[(int)Characters.C0];
                            break;
                        case "C1":
                            ret[i] += Dictionary.Alphabet[(int)Characters.C1];
                            break;
                        case "C2":
                            ret[i] += Dictionary.Alphabet[(int)Characters.C2];
                            break;
                        case "C3":
                            ret[i] += Dictionary.Alphabet[(int)Characters.C3];
                            break;
                        case "C4":
                            ret[i] += Dictionary.Alphabet[(int)Characters.C4];
                            break;
                        case "C5":
                            ret[i] += Dictionary.Alphabet[(int)Characters.C5];
                            break;
                        case "C6":
                            ret[i] += Dictionary.Alphabet[(int)Characters.C6];
                            break;
                        case "C7":
                            ret[i] += Dictionary.Alphabet[(int)Characters.C7];
                            break;
                        case "C8":
                            ret[i] += Dictionary.Alphabet[(int)Characters.C8];
                            break;
                        case "C9":
                            ret[i] += Dictionary.Alphabet[(int)Characters.C9];
                            break;

                        case "D0":
                            ret[i] += Dictionary.Alphabet[(int)Characters.D0];
                            break;
                        case "D1":
                            ret[i] += Dictionary.Alphabet[(int)Characters.D1];
                            break;
                        case "D2":
                            ret[i] += Dictionary.Alphabet[(int)Characters.D2];
                            break;
                        case "D3":
                            ret[i] += Dictionary.Alphabet[(int)Characters.D3];
                            break;
                        case "D4":
                            ret[i] += Dictionary.Alphabet[(int)Characters.D4];
                            break;
                        case "D5":
                            ret[i] += Dictionary.Alphabet[(int)Characters.D5];
                            break;
                        case "D6":
                            ret[i] += Dictionary.Alphabet[(int)Characters.D6];
                            break;
                        case "D7":
                            ret[i] += Dictionary.Alphabet[(int)Characters.D7];
                            break;
                        case "D8":
                            ret[i] += Dictionary.Alphabet[(int)Characters.D8];
                            break;
                        case "D9":
                            ret[i] += Dictionary.Alphabet[(int)Characters.D9];
                            break;

                        case "E0":
                            ret[i] += Dictionary.Alphabet[(int)Characters.E0];
                            break;
                        case "E1":
                            ret[i] += Dictionary.Alphabet[(int)Characters.E1];
                            break;
                        case "E2":
                            ret[i] += Dictionary.Alphabet[(int)Characters.E2];
                            break;
                        case "E3":
                            ret[i] += Dictionary.Alphabet[(int)Characters.E3];
                            break;
                        case "E4":
                            ret[i] += Dictionary.Alphabet[(int)Characters.E4];
                            break;
                        case "E5":
                            ret[i] += Dictionary.Alphabet[(int)Characters.E5];
                            break;
                        case "E6":
                            ret[i] += Dictionary.Alphabet[(int)Characters.E6];
                            break;
                        case "E7":
                            ret[i] += Dictionary.Alphabet[(int)Characters.E7];
                            break;
                        case "E8":
                            ret[i] += Dictionary.Alphabet[(int)Characters.E8];
                            break;
                        case "E9":
                            ret[i] += Dictionary.Alphabet[(int)Characters.E9];
                            break;

                        case "F0":
                            ret[i] += Dictionary.Alphabet[(int)Characters.F0];
                            break;
                        case "F1":
                            ret[i] += Dictionary.Alphabet[(int)Characters.F1];
                            break;
                        case "F2":
                            ret[i] += Dictionary.Alphabet[(int)Characters.F2];
                            break;
                        case "F3":
                            ret[i] += Dictionary.Alphabet[(int)Characters.F3];
                            break;
                        case "F4":
                            ret[i] += Dictionary.Alphabet[(int)Characters.F4];
                            break;
                        case "F5":
                            ret[i] += Dictionary.Alphabet[(int)Characters.F5];
                            break;
                        case "F6":
                            ret[i] += Dictionary.Alphabet[(int)Characters.F6];
                            break;
                        case "F7":
                            ret[i] += Dictionary.Alphabet[(int)Characters.F7];
                            break;
                        case "F8":
                            ret[i] += Dictionary.Alphabet[(int)Characters.F8];
                            break;
                        case "F9":
                            ret[i] += Dictionary.Alphabet[(int)Characters.F9];
                            break;
                    }
                }
            }
            _password = ret;
            return ret;
        }
        #endregion

        #region Getters
        public string[] GetPasswords()
        {
            return _password;
        }

        public string GetTheftDeterentPass()
        {
            return _password[0];
        }

        public string GetCustomerPassOne()
        {
            return _password[1];
        }

        public string GetCustomerPassTwo()
        {
            return _password[2];
        }

        public XmlDocument GetDocument()
        {
            return _document;
        }

        public void ChangeCheckState(bool _checked)
        {
            _whitespace = _checked;
            GetPassword();
        }
        #endregion
    }
}
