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

| Método   | Descrição                            |
|----------|--------------------------------------|
| Insert   | Insere um novo produto               |
| Update   | Atualiza um produto existente        |
| Delete   | Remove um produto pelo Id            |
| GetAll   | Retorna todos os produtos            |
| Search   | Busca produtos pela descrição (LIKE) |

## Pacotes necessários
```
sqlite-net-pcl
SQLitePCLRaw.bundle_green
```

## Referência do professor
Vídeo: https://www.youtube.com/watch?v=OZRofDwVB7c
Código-fonte original: https://github.com/tiagotas/MauiAppMinhasCompras/tree/c1ff29274690d6a15d85a67d4580c493a0aa39c8

## Autor
Aluna: Taísa Medeiros
Disciplina: Desenvolvimento Mobile / .NET MAUI
Agenda 2 – Persistência com SQLite
