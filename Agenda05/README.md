# minhas-compras

**Repositório:** https://github.com/taisamedeirosarkanjo-code/minhas-compras

## MauiAppMinhasCompras - Agenda 5

## Tema: Menus de Contexto e ListView — Try-Catch, ItemSelected, ContextActions e EditarProduto

Nesta agenda o aplicativo Minhas Compras ganhou as funcionalidades completas de **exclusão com confirmação**, **navegação por item selecionado** e **edição de produtos** já cadastrados no banco SQLite.

## Arquivos desta Agenda

| Arquivo | Descrição |
|---|---|
| `Views/ListaProduto.xaml` | ListView com header (grade de colunas), SearchBar, ItemSelected e ContextActions (Remover) |
| `Views/ListaProduto.xaml.cs` | Lógica completa: try-catch, delete com confirmação, navegação para EditarProduto |
| `Views/EditarProduto.xaml` | Tela de edição com campos vinculados ao BindingContext do produto selecionado |
| `Views/EditarProduto.xaml.cs` | Recupera BindingContext, cria novo Produto com Id preservado, salva via Update e volta |
| `Views/NovoProduto.xaml.cs` | Inserção de produto com try-catch |

## Conceitos abordados

### Try-Catch
- Envolve cada operação crítica (banco, conversão, navegação)
- Exibe `DisplayAlert("Ops", ex.Message, "OK")` em caso de falha
- Evita que o app trave de forma inesperada

### ContextActions (Menu de Contexto)
- Definido dentro de `<ViewCell.ContextActions>` no XAML
- `MenuItem Text="Remover"` com evento `Clicked="MenuItem_Clicked"`
- No code-behind: `sender as MenuItem` → `BindingContext as Produto` para obter o item

### DisplayAlert com confirmação
```csharp
bool confirm = await DisplayAlert("Tem Certeza?", $"Remover {p.Descricao}?", "Sim", "Não");
if (confirm) { await App.Db.Delete(p.Id); lista.Remove(p); }
```
- Retorna `true` (Sim) ou `false` (Não)
- Só executa a ação se o usuário confirmar

### ItemSelected — Navegação com BindingContext
- Evento `lst_produtos_ItemSelected` captura o item tocado via `e.SelectedItem as Produto`
- Navega para `EditarProduto` passando o objeto como `BindingContext`
- A tela de edição recupera com: `Produto produto_anexado = BindingContext as Produto;`

### EditarProduto — Atualização no banco
- `BindingContext` preenche os campos automaticamente via Data Binding no XAML
- Preserva o `Id` original ao criar o novo objeto Produto
- Salva com `await App.Db.Update(p)` e volta com `Navigation.PopAsync()`

## Fluxo completo
1. Tela inicial carrega produtos no `OnAppearing` com try-catch
2. Usuário toca num item → `ItemSelected` navega para `EditarProduto`
3. Campos já preenchidos pelo BindingContext → usuário edita → clica "Salvar"
4. `Update` salva no SQLite → alerta de sucesso → volta para a lista
5. Usuário desliza um item → toca "Remover" → `DisplayAlert` pede confirmação
6. Se confirmar: `Delete` no banco + `lista.Remove(p)` remove da `ObservableCollection`

## Referência do professor
- Vídeo: https://www.youtube.com/watch?v=Zs4vlFkNtSI
- Código original: https://github.com/tiagotas/MauiAppMinhasCompras/tree/4ee543ada3a0411dbae3d3130db2403dcb024644

## Autora
Taísa Medeiros — Curso Técnico em Desenvolvimento de Sistemas / ETEC
