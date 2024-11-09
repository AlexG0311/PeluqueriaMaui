using Microsoft.Maui.ApplicationModel.Communication;
using Proyecto.Model;
using System.Collections.ObjectModel;

namespace Proyecto;

public partial class Servicios : ContentPage
{

    public ObservableCollection<Producto> ProductosCombos { get; set; }
    public ObservableCollection<Producto> ProductosIndividuales { get; set; }
    public Servicios()
	{
		InitializeComponent();

        // Inicializar las ObservableCollection con productos
        ProductosCombos = new ObservableCollection<Producto>
            {
                new Producto { Nombre = "Coloraci�n", Imagen = "coloracion.jpg", Calificacion = "\u2605\u2605\u2605\u2605\u2606" },
                new Producto { Nombre = "Corte y Peinado", Imagen = "corte_peinado.png", Calificacion = "\u2605\u2605\u2605\u2605\u2605" },
                new Producto { Nombre = "Manicure", Imagen = "manicure.jpg", Calificacion = "\u2605\u2605\u2605\u2605\u2606" },
                new Producto { Nombre = "Pedicure", Imagen = "cortebarba.jpg", Calificacion = "\u2605\u2605\u2605\u2605\u2606" },
                new Producto { Nombre = "Pedicure", Imagen = "cortebarba.jpg", Calificacion = "\u2605\u2605\u2605\u2605\u2606" }
            };

        ProductosIndividuales = new ObservableCollection<Producto>
            {
                new Producto { Nombre = "Coloraci�n", Imagen = "coloracion.jpg", Calificacion = "\u2605\u2605\u2605\u2605\u2605" }
            };

        // Asignar las ObservableCollection a los CollectionView
        CollectionViewCombos.ItemsSource = ProductosCombos;
        CollectionViewIndividuales.ItemsSource = ProductosIndividuales;
    }
  


}
