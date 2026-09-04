# MauiAppMinhasCompras - Agenda 2

Projeto .NET MAUI de lista de compras com persistência local usando **SQLite**.

## Conteúdo desta Agenda

### 1. Classe Model
**Arquivo:** `Models/Produto.cs`

Representa o produto no banco de dados com:
- `Id` (chave primária autoincremento)
- `Descricao`
- `Quantidade`
- `Preco`

### 2. Classe Helper (principal)
**Arquivo:** `Helpers/SQLiteDatabaseHelper.cs`

Classe responsável por todas as operações no banco SQLite:

| Método     | Descrição                                      |
|------------|------------------------------------------------|
| `Insert`   | Insere um novo produto                         |
| `Update`   | Atualiza um produto existente                  |
| `Delete`   | Remove um produto pelo Id                      |
| `GetAll`   | Retorna todos os produtos                      |
| `Search`   | Busca produtos pela descrição (LIKE)           |

**Observações importantes:**
- O campo `_conn` é `readonly` para garantir que a conexão não seja trocada.
- O construtor cria a tabela `Produto` se ela ainda não existir (`.Wait()` garante que isso aconteça antes de qualquer operação).
- `Insert` retorna o número de linhas afetadas.
- `Update` no material original retorna `List<Produto>` e usa `QueryAsync` (siga exatamente o que o material pede nesta etapa).
- `Delete` usa expressão lambda para filtrar pelo Id.
- `GetAll` é equivalente a `SELECT * FROM Produto`.
- `Search` usa `LIKE` com `%` para busca parcial na descrição.

### 3. Inicialização do banco

Exemplo típico (em `App.xaml.cs`):

```csharp
public static SQLiteDatabaseHelper Db { get; private set; }

public App()
{
    InitializeComponent();

    string path = Path.Combine(FileSystem.AppDataDirectory, "banco_sqlite_compras.db3");
    Db = new SQLiteDatabaseHelper(path);

    MainPage = new NavigationPage(new Views.ListaProduto());
}
```

## Pacotes necessários

No projeto MAUI, adicione o pacote NuGet:

```
sqlite-net-pcl
```

(e geralmente `SQLitePCLRaw.bundle_green` se necessário)

## Estrutura do projeto

```
MauiAppMinhasCompras/
├── Models/
│   └── Produto.cs
├── Helpers/
│   └── SQLiteDatabaseHelper.cs
├── Views/
│   └── (ListaProduto e outras páginas)
├── App.xaml.cs.exemplo
└── README.md
```

## Autor
Aluna: Taísa Medeiros  
Disciplina: Desenvolvimento Mobile / .NET MAUI  
Agenda 2 – Persistência com SQLite
