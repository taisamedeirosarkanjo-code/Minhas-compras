# MauiAppMinhasCompras - Agenda 3

## Tema: Inserção de Registros no SQLite com .NET MAUI

Nesta agenda foi implementada a interface gráfica para inserir produtos no banco de dados SQLite
e o padrão **Singleton** para gerenciar a instância única do banco de dados.

## Arquivos desta Agenda

| Arquivo | Descrição |
|---|---|
| `App.xaml.cs` | Padrão Singleton para acesso ao banco SQLite |
| `Views/NovoProduto.xaml` | Tela de cadastro de novo produto (XAML) |
| `Views/NovoProduto.xaml.cs` | Lógica de inserção no SQLite |
| `Views/ListaProduto.xaml` | Tela de listagem de produtos (XAML) |
| `Views/ListaProduto.xaml.cs` | Lógica de navegação para NovoProduto |

## Conceitos abordados

### Padrão Singleton
- Garante que apenas **uma instância** do banco de dados seja criada durante toda a execução do app
- Acesso centralizado via `App.Db`
- Uso eficiente de memória e recursos

### Arquivo .db3 do SQLite
- Arquivo binário com tabelas, índices, triggers e dados
- Portátil entre plataformas (Windows, macOS, Android, iOS)
- Armazenado em `LocalApplicationData` do dispositivo

### Fluxo de inserção
1. Usuário preenche Descrição, Quantidade e Preço em `NovoProduto`
2. Clica em **Salvar** (ToolbarItem)
3. Um objeto `Produto` é criado e inserido via `await App.Db.Insert(p)`
4. Exibe alerta de sucesso

## Referência do professor
- Vídeo: https://www.youtube.com/watch?v=cAd28OMf7PA
- Código original: https://github.com/tiagotas/MauiAppMinhasCompras/tree/9cdf2f376e5b896cf6ecc87ae6e2a63b86f268ab

## Autora
Taísa Medeiros — Curso Técnico em Desenvolvimento de Sistemas / ETEC
