# minhas-compras

**Repositório:** https://github.com/taisamedeirosarkanjo-code/minhas-compras

## MauiAppMinhasCompras - Agenda 4

## Tema: Manipulação de Interface — SearchBar, ListView, ObservableCollection e OnAppearing

Nesta agenda foi implementada a recuperação de dados do SQLite e a funcionalidade de **busca instantânea (Live Search)** usando `SearchBar` com o evento `TextChanged`.

## Arquivos desta Agenda

| Arquivo | Descrição |
|---|---|
| `Models/Produto.cs` | Model com propriedade `Total` calculada (Quantidade × Preço) |
| `Helpers/SQLiteDatabaseHelper.cs` | Helper SQLite com `GetAll`, `Search`, `Insert`, `Update`, `Delete` |
| `Views/ListaProduto.xaml` | Tela com SearchBar, ListView e ContextActions |
| `Views/ListaProduto.xaml.cs` | Lógica com ObservableCollection, OnAppearing, busca dinâmica e total |

## Conceitos abordados

### SearchBar e TextChanged
- **Placeholder**: texto exibido quando o campo está vazio
- **TextChanged**: evento disparado a cada letra digitada para busca em tempo real no SQLite
- **TextChangedEventArgs**: fornece `OldTextValue` e `NewTextValue`

### ListView
- **ItemsSource**: vincula a lista de produtos à exibição
- **ItemTemplate / TextCell**: define como cada item é renderizado
- **ContextActions**: ações ao deslizar (swipe) — ex: botão "Excluir"
- **ItemSelected / Refreshing**: eventos de seleção e atualização

### ObservableCollection<T>
- Notifica automaticamente a interface sobre adição, remoção ou modificação de itens
- Mais eficiente que `List<T>`: não exige reatribuição do `ItemsSource`

### Método OnAppearing()
- Chamado automaticamente quando a página se torna visível
- Usado para carregar os dados do SQLite toda vez que o usuário navega de volta à tela

## Fluxo da busca instantânea
1. Usuário digita na `SearchBar`
2. Evento `TextChanged` é disparado com `e.NewTextValue`
3. A lista é limpa (`lista.Clear()`)
4. `App.Db.Search(q)` executa `LIKE '%q%'` no SQLite
5. Resultados são adicionados à `ObservableCollection` e a UI atualiza automaticamente

## Referência do professor
- Vídeo: https://www.youtube.com/watch?v=A27W2281aNo
- Código original: https://github.com/tiagotas/MauiAppMinhasCompras/tree/c19f4d3356b2ebd02e5ea392e5e7a162dcb0893f

## Autora
Taísa Medeiros — Curso Técnico em Desenvolvimento de Sistemas / ETEC
