# Projeto de Aprendizado sobre Threads e Multithreading

Este projeto é uma simulação simples para aprender sobre threads e multithreading em C#. O objetivo é demonstrar como criar e gerenciar threads para realizar transações simultâneas em contas bancárias e aprender sobre sincronização de acesso a recursos compartilhados.

## Descrição

O projeto simula transações bancárias em múltiplas contas, incluindo depósitos e saques realizados por várias threads em paralelo. A sincronização é garantida através do uso de um objeto `lock` para evitar condições de corrida.

## Funcionalidades

- **Criação de Threads:** Cria e gerencia threads para realizar operações bancárias simultâneas.
- **Sincronização:** Utiliza um objeto `lock` para garantir que apenas uma thread possa modificar o saldo da conta por vez.
- **Simulação de Transações:** Realiza depósitos e saques em contas bancárias com operações aleatórias.

## Estrutura do Projeto

### `Program.cs`

- **`Main`**: Cria uma lista de contas bancárias e inicializa múltiplas threads para realizar transações (depósitos e saques) em paralelo. Aguarda a conclusão de todas as threads e exibe as informações das contas ao final.
- **`RealizarTranzacoes`**: Método que realiza operações de depósito e saque aleatoriamente em uma conta bancária.

### `ContaBancaria.cs`

- **Propriedades**: Contém informações sobre a conta bancária, como número da conta, agência, banco, cidade, estado e saldo.
- **Métodos**:
  - **`Deposito`**: Adiciona uma quantia ao saldo da conta, com sincronização para evitar condições de corrida.
  - **`Saque`**: Retira uma quantia do saldo da conta se houver saldo suficiente, com sincronização.
  - **`ToString`**: Retorna uma representação em string da conta bancária.

## Requisitos

- [.NET SDK](https://dotnet.microsoft.com/download) 6.0 ou superior
- Ambiente de desenvolvimento C# (por exemplo, [Visual Studio](https://visualstudio.microsoft.com/) ou [Visual Studio Code](https://code.visualstudio.com/))
