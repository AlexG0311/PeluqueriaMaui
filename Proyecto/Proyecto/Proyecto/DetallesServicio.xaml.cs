namespace Proyecto;

using Microsoft.Maui.ApplicationModel.Communication;
using Proyecto.Model;
using System.Collections.ObjectModel;


public partial class DetallesServicio : ContentPage
{
    public Servicio detalleServicios { get; set; }
    public DetallesServicio(Servicio detalle)
    {
		InitializeComponent();

        this.detalleServicios = detalle;

        this.BindingContext = this;





    }


    private async void OnNavigateButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Agendar());
    }






}