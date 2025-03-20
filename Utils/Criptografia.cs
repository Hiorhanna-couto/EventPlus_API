namespace EventPlus_.Utils
{
    public class Criptografia
    {
        public static string GerarHash(string Senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(Senha);
        }

        public static bool CompararHash(string SenhaInformada, string SenhaBanco)
        {
            return BCrypt.Net.BCrypt.Verify(SenhaInformada, SenhaBanco);
        }

    }
}
