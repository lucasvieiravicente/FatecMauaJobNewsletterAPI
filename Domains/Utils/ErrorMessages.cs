namespace FatecMauaJobNewsletter.Domains.Utils
{
    public static class ErrorMessages
    {
        public const string MaxLengthError = "{0} aceita no máximo {1} caracteres";
        public const string IsRequired = "{0} é obrigatório";
        public const string MinRequired = "{0} tem o mínimo de {1} dígitos";
        public const string MaxRequired = "{0} tem o máximo de {1} dígitos";
        public const string IncorrectEmail = "Necessário inserir um tipo de e-mail válido";
        public const string IncorrectPhoneNumber = "Insira somente números no campo telefone";
    }
}
