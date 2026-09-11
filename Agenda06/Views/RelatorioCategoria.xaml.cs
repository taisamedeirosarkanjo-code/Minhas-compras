using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class RelatorioCategoria : ContentPage
{
    public RelatorioCategoria()
    {
        InitializeComponent();
    }

    protected async override void OnAppearing()
    {
        try
        {
            List<Produto> todos = await App.Db.GetAll();

            List<CategoriaTotal> totaisPorCategoria = todos
                .GroupBy(p => string.IsNullOrEmpty(p.Categoria) ? "Sem Categoria" : p.Categoria)
                .Select(g => new CategoriaTotal
                {
                    Categoria = g.Key,
                    Total = g.Sum(p => p.Total)
                })
                .OrderByDescending(c => c.Total)
                .ToList();

            lst_relatorio.ItemsSource = totaisPorCategoria;

            double totalGeral = totaisPorCategoria.Sum(c => c.Total);
            lbl_total_geral.Text = $"Total Geral: {totalGeral:C}";
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}
