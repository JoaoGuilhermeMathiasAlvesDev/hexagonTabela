namespace hexagonTabela.ValidacaoDominio
{
    public class Validacao
    {
        public static bool CPFValidacao(string cpf)
        {
            if (cpf == null)
                throw new CustomeException.CustomeException("Campo CPF não pode ser vazio ou Nulo.");

            cpf =  new string(cpf.Where(char.IsDigit).ToArray());

            if(cpf.Length != 11  || cpf.Distinct().Count() == 1) 
                throw new CustomeException.CustomeException("Esta faltando digitos ou esta com varias numerações iguais no campo CPF, Por favor digite corretamente!");

            int[] multiplicador1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };


            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            int digito1 = resto < 2 ? 0 : 11 - resto;

            tempCpf += digito1;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            int digito2 = resto < 2 ? 0 : 11 - resto;

            string cpfValidado = tempCpf + digito2;
            return cpf == cpfValidado;


        }
    }
}
