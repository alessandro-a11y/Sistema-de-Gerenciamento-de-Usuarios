# Sistema de Gerenciamento de Usuários (CRUD) - C# Puro

## Descrição do Projeto
Este é um sistema básico de gerenciamento de usuários, desenvolvido inteiramente em **C# puro**, sem frameworks web ou ASP.NET.  
O projeto permite **cadastrar, listar, buscar, atualizar e remover usuários**, utilizando **listas em memória** para armazenar os dados.

O objetivo é exercitar conceitos de lógica de programação, estruturas de controle, classes e métodos em C#, aplicando um CRUD funcional de forma simples.

Futuramente, o projeto será aprimorado com **frameworks**, **persistência em banco de dados** e possivelmente uma interface web.

---

## Funcionalidades

1. **Cadastrar Usuário**
   - Solicita nome e email.
   - Verifica se o email já existe.
   - Gera um ID automático incremental.
   
2. **Listar Usuários**
   - Exibe todos os usuários cadastrados com nome, email e ID.

3. **Buscar Usuário**
   - Busca por ID.
   - Exibe nome, email e ID do usuário encontrado.

4. **Atualizar Usuário**
   - Busca usuário por ID.
   - Permite atualizar nome e email.
   - Verifica duplicidade de email.

5. **Remover Usuário**
   - Busca usuário por ID.
   - Remove usuário da lista em memória.

---

## Estrutura do Código

- **Program.cs**
  - Contém o menu principal e a execução do sistema.
  - Métodos separados para cada operação: `CadastrarUsuario`, `ListarUsuarios`, `BuscarUsuario`, `AtualizarUsuario`, `RemoverUsuario`.
  
- **Usuario.cs**
  - Classe `Usuario` com propriedades:
    - `Id` (int)
    - `Nome` (string)
    - `Email` (string)

---

## Tecnologias e Conceitos Aplicados

- Linguagem: **C#**
- Paradigma: **Orientação a Objetos**
- Estruturas utilizadas: **List**, **foreach**, **if/else**, **switch**
- Conceitos de CRUD: **Create, Read, Update, Delete**
- Validação de entrada e verificação de duplicidade
- Incremento automático de IDs

---

## Como Executar

1. Abra o projeto em um editor compatível com C# (ex.: Visual Studio, Visual Studio Code).
2. Compile e execute o `Program.cs`.
3. Siga o menu interativo no console para gerenciar os usuários.

---

## Próximos Passos

- Implementar **persistência em banco de dados** (ex.: PostgreSQL, SQL Server).
- Refatorar com **frameworks web** (ex.: ASP.NET Core).
- Melhorar a experiência do usuário com tratamento de erros mais detalhado e interface gráfica.
