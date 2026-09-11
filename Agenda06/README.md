# minhas-compras

**Repositório:** https://github.com/taisamedeirosarkanjo-code/minhas-compras

## MauiAppMinhasCompras - Agenda 6 (Finalização do Projeto)

## Tema: Regionalização, Pull to Refresh e Desafio 1 — Relatório de Compras por Categoria

Nesta agenda o aplicativo Minhas Compras foi finalizado com os ajustes de regionalização (cultura pt-BR),
o mecanismo de atualização por gesto (Pull to Refresh) e a implementação do **Desafio 1**: relatório de
gastos por categoria de produto.

## Arquivos desta Agenda

| Arquivo | Descrição |
|---|---|
| `App.xaml.cs` | Define `CurrentCulture` e `CurrentUICulture` como `pt-BR` |
| `Models/Produto.cs` | Adição do campo `Categoria` ao modelo de dados |
| `Models/CategoriaTotal.cs` | Model auxiliar usado no relatório (Categoria + Total) |
| `Views/ListaProduto.xaml(.cs)` | Picker de filtro por categoria, Pull to Refresh e valores formatados em moeda |
| `Views/NovoProduto.xaml(.cs)` | Picker para selecionar a categoria do produto ao cadastrar |
| `Views/EditarProduto.xaml(.cs)` | Picker para editar a categoria do produto já cadastrado |
| `Views/RelatorioCategoria.xaml(.cs)` | Tela nova com o total gasto por categoria e o total geral |

## Conceitos abordados

### Regionalização com CurrentCulture
```csharp
var cultura = new CultureInfo("pt-BR");
Thread.CurrentThread.CurrentCulture = cultura;
Thread.CurrentThread.CurrentUICulture = cultura;
```
- **CurrentCulture**: formatação de números, moedas e datas (ex: `R$ 1.234,56`, `20/03/2025`)
- **CurrentUICulture**: escolha de textos e mensagens localizadas
- Aplicado no construtor de `App.xaml.cs`, valendo para todo o aplicativo

### Currency Format (`:C`)
- Usado em `{Binding Preco, StringFormat='{0:C}'}` e no total geral do relatório
- Com a cultura `pt-BR` definida, o `:C` exibe automaticamente o símbolo **R$** e o separador decimal correto

### Pull to Refresh
```xml
<ListView x:Name="lst_produtos"
          IsPullToRefreshEnabled="True"
          Refreshing="lst_produtos_Refreshing">
</ListView>
```
```csharp
private async void lst_produtos_Refreshing(object sender, EventArgs e)
{
    try { await CarregarProdutos(); }
    catch (Exception ex) { await DisplayAlert("Ops", ex.Message, "OK"); }
    finally { lst_produtos.IsRefreshing = false; }
}
```
- O usuário puxa a lista para baixo para recarregar os produtos direto do SQLite
- `IsRefreshing = false` no `finally` encerra a animação de carregamento

## Desafio 1 — Relatório de Compras por Categoria

### 1. Novo campo no modelo de dados
```csharp
public class Produto
{
    ...
    public string Categoria { get; set; }
    ...
}
```

### 2. Filtro por categoria na lista principal
- Um `Picker` (`cmb_categoria`) com as opções Todas / Alimentos / Higiene / Limpeza / Outros
- Ao selecionar uma categoria, `AplicarFiltroCategoria()` filtra `listaCompleta` com LINQ e recria a `ObservableCollection` exibida

### 3. Relatório com o total gasto por categoria
- Nova tela `RelatorioCategoria`, acessível pelo botão **Relatório** na barra de ferramentas
- Os produtos são agrupados com `GroupBy(p => p.Categoria)` e somados com `Sum(p => p.Total)`
- Exibe uma lista com o total por categoria (ordenada do maior para o menor gasto) e o total geral no rodapé

## Fluxo completo
1. Usuário cadastra um produto informando também a **Categoria** em `NovoProduto`
2. Na lista principal, pode filtrar os produtos por categoria usando o `Picker`
3. Pode puxar a lista para baixo (Pull to Refresh) para buscar os dados mais recentes do SQLite
4. Ao tocar em **Relatório**, visualiza o total gasto em cada categoria e o total geral, tudo formatado em R$

## Referência do professor
- Vídeo: https://www.youtube.com/watch?v=T1BvGYBo-Jc
- Código original: https://github.com/tiagotas/MauiAppMinhasCompras/commit/8f49c267a4ea3f433273e146337cea80b798abe1

## Autora
Taísa Medeiros — Curso Técnico em Desenvolvimento de Sistemas / ETEC
