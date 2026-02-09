using System;
using System.Collections.Generic;
using static SistemaGenrenciamentoDeUsuarios.Program;
namespace SistemaGerenciamentoDeUsuarios
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Usuario> usuarios = new List<Usuario>();
            int proximoId = 1;

            while (true)
            {
                Console.WriteLine(
                    "Escolha uma opção:\n" +
                    "1 - Cadastrar usuário\n" +
                    "2 - Listar usuários\n" +
                    "3 - Buscar usuário\n" +
                    "4 - Atualizar usuário\n" +
                    "5 - Remover usuário\n" +
                    "0 - Sair"
                );

                int opcao;
                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Opção inválida! Digite um número.");
                    continue;
                }

                if (opcao == 0)
                {
                    Console.WriteLine("Sistema encerrado.");
                    break;
                }

                switch (opcao)
                {
                    case 1:
                        CadastrarUsuario(usuarios, ref proximoId);
                        break;

                    case 2:
                        ListarUsuarios(usuarios);
                        break;

                    case 3:
                        BuscarUsuario(usuarios);
                        break;

                    case 4:
                        AtualizarUsuario(usuarios);
                        break;

                    case 5:
                        RemoverUsuario(usuarios);
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

        static void CadastrarUsuario(List<Usuario> usuarios, ref int proximoId)
        {
            bool emailExistente = false;
            Usuario novoUsuario = new Usuario();

            Console.Write("Insira seu nome: ");
            novoUsuario.Nome = Console.ReadLine();

            Console.Write("Insira seu email: ");
            novoUsuario.Email = Console.ReadLine();

            foreach (var usuarioExistente in usuarios)
            {
                if (usuarioExistente.Email == novoUsuario.Email)
                {
                    Console.WriteLine("Este email já existe, tente novamente!");
                    emailExistente = true;
                    break;
                }
            }

            if (!emailExistente)
            {
                novoUsuario.Id = proximoId;
                proximoId++;
                usuarios.Add(novoUsuario);
                Console.WriteLine("\nUsuário cadastrado com sucesso!\n");
            }
        }

        static void ListarUsuarios(List<Usuario> usuarios)
        {
            if (usuarios.Count == 0)
            {
                Console.WriteLine("Nenhum usuário cadastrado.\n");
                return;
            }

            foreach (var usuarioAtual in usuarios)
            {
                Console.WriteLine($"Nome: {usuarioAtual.Nome}");
                Console.WriteLine($"Email: {usuarioAtual.Email}");
                Console.WriteLine($"ID: {usuarioAtual.Id}");
                Console.WriteLine("---------------------");
            }
        }

        static void BuscarUsuario(List<Usuario> usuarios)
        {
            Console.Write("Insira o ID do usuário: ");
            if (!int.TryParse(Console.ReadLine(), out int idBusca))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            bool usuarioEncontrado = false;

            foreach (var usuarioAtual in usuarios)
            {
                if (usuarioAtual.Id == idBusca)
                {
                    Console.WriteLine($"Nome: {usuarioAtual.Nome}");
                    Console.WriteLine($"Email: {usuarioAtual.Email}");
                    Console.WriteLine($"ID: {usuarioAtual.Id}");
                    usuarioEncontrado = true;
                    break;
                }
            }

            if (!usuarioEncontrado)
            {
                Console.WriteLine("Usuário não encontrado.");
            }
        }

        static void AtualizarUsuario(List<Usuario> usuarios)
        {
            Console.Write("Digite o ID do usuário que deseja atualizar: ");
            if (!int.TryParse(Console.ReadLine(), out int idBusca))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            Usuario usuarioParaAtualizar = null;

            foreach (var u in usuarios)
            {
                if (u.Id == idBusca)
                {
                    usuarioParaAtualizar = u;
                    break;
                }
            }

            if (usuarioParaAtualizar == null)
            {
                Console.WriteLine("Usuário não encontrado.");
                return;
            }

            Console.Write($"Nome atual: {usuarioParaAtualizar.Nome} | Novo nome: ");
            string novoNome = Console.ReadLine();

            Console.Write($"Email atual: {usuarioParaAtualizar.Email} | Novo email: ");
            string novoEmail = Console.ReadLine();

            bool emailJaExiste = false;
            foreach (var u in usuarios)
            {
                if (u.Email == novoEmail && u.Id != idBusca)
                {
                    emailJaExiste = true;
                    break;
                }
            }

            if (emailJaExiste)
            {
                Console.WriteLine("Erro: já existe um usuário com esse email.");
                return;
            }

            usuarioParaAtualizar.Nome = novoNome;
            usuarioParaAtualizar.Email = novoEmail;
            Console.WriteLine("Usuário atualizado com sucesso!");
        }

        static void RemoverUsuario(List<Usuario> usuarios)
        {
            Console.Write("Digite o ID do usuário a remover: ");
            if (!int.TryParse(Console.ReadLine(), out int idRemover))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            Usuario usuarioParaRemover = null;
            foreach (var u in usuarios)
            {
                if (u.Id == idRemover)
                {
                    usuarioParaRemover = u;
                    break;
                }
            }

            if (usuarioParaRemover != null)
            {
                usuarios.Remove(usuarioParaRemover);
                Console.WriteLine("Usuário removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Usuário não encontrado.");
            }
        }
    }
}
