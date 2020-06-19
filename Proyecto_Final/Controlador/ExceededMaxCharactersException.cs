using System;

namespace Proyecto_Final.Controlador
{
    public class ExceededMaxCharactersException : Exception
    {
        public ExceededMaxCharactersException(string Message) : base(Message) { }
    }
}
