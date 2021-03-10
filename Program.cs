using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        //adicionar alunos
                        Console.WriteLine("Informe o nome do aluno:");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do aluno:");
                       if(decimal.TryParse(Console.ReadLine(), out decimal nota))
                       {
                           aluno.Nota = nota;
                       }
                       else{
                           throw new ArithmeticException("O valor da nota deve ser decimal");
                       }
                       alunos[indiceAluno] = aluno;
                       indiceAluno++;
                        break;
                    case "2":
                        //listar alunos
                        foreach(var a1 in alunos){
                            if(!string.IsNullOrEmpty(a1.Nome)){
                            Console.WriteLine($"Aluno: {a1.Nome} / Nota: {a1.Nota}");
                            }
                        }
                        break;

                    case "3":
                        //calcular media geral
                        decimal notaTotal = 0;
                        var nrAlunos = 0;
                        for(int i=0; i < alunos.Length; i++)
                        {
                            if(!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrAlunos++;
                            }
                        }
                        var medialGeral = notaTotal / nrAlunos;
                        Conceito conceitoGeral;

                        if(0 < medialGeral && medialGeral < 2)
                        {
                            conceitoGeral = Conceito.E;
                        }
                        else if(2 < medialGeral && medialGeral < 4){
                            conceitoGeral = Conceito.D;
                        }
                        else if(4 < medialGeral && medialGeral < 6){
                            conceitoGeral = Conceito.C;
                        }
                        else if(6 < medialGeral && medialGeral < 8){
                            conceitoGeral = Conceito.B;
                        }
                        else{
                            conceitoGeral = Conceito.A;
                        }


                        Console.WriteLine($"Media geral {medialGeral} // Conceito {conceitoGeral}");

                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1-Inserir novo aluno");
            Console.WriteLine("2-Listar alunos");
            Console.WriteLine("3-Calcular media geral");
            Console.WriteLine("X - sair");
            Console.WriteLine();
            string opcaoUsuario = Console.ReadLine();
            return opcaoUsuario;
        }
    }
}
