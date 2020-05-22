using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AppAlmacen.Clases
{
    public class BultosApp
    {
        public object NombreCompleto { get; set; }
        public int? BltNumero { get; set; }
        public int? BltTipoServicio { get; set; }
        public string CteNumeroEps { get; set; }
        public string CteCedula { get; set; }
        public object CteEpsDestinado { get; set; }
        public object ProCodigo { get; set; }
        public object SupCodigo { get; set; }
        public object ProSuplidor { get; set; }
        public object ManGuia { get; set; }
        public object ManManifiesto { get; set; }
        public string BltGuiaHija { get; set; }
        public string BltCodigoBarra { get; set; }
        public object BltPonumber { get; set; }
        public string BltTrackingNumber { get; set; }
        public object OriCodigo { get; set; }
        public object BltDestino { get; set; }
        public object BltPiezas { get; set; }
        public object BltPeso { get; set; }
        public object BltPesoReal { get; set; }
        public object BltVolumen { get; set; }
        public string BltEstado { get; set; }
        public string BltUbicacion { get; set; }
        public object BltFechaRecepcion { get; set; }
        public object ResCodigo { get; set; }
        public object BltBolsaSuplidor { get; set; }
        public object BltFechaEntregado { get; set; }
        public object PtoCodigo { get; set; }
        public object BltTasa { get; set; }
        public object BltTasaCredito { get; set; }
        public object BltRecepSuplidor { get; set; }
        public object BltDespaSuplidor { get; set; }
        public object BltPesoSuplidor { get; set; }
        public object BltCarrier { get; set; }
        public object CouCodigo { get; set; }
        public object BltVentanilla { get; set; }
        public object BltPiezasSuplidor { get; set; }
        public object BltCounter { get; set; }
        public object BltViaSalida { get; set; }
        public object BltManifiestoSucursal { get; set; }
        public object BltBolsaSucursal { get; set; }
        public object BltLiquidador { get; set; }
        public string BltEntregar { get; set; }
        public object BltTipo { get; set; }
        public object BltHoraRecibido { get; set; }
        public object BltHoraEntregado { get; set; }
        public object UndCodigo { get; set; }
        public object UbiCodigo { get; set; }
        public object ConCodigo { get; set; }
        public object BltWarehouse { get; set; }
        public object TimCodigo { get; set; }
        public object BltMontoSellos { get; set; }
        public object BltOrigen { get; set; }
        public object BltPorcientoSello { get; set; }
        public object BltAduana { get; set; }
        public object AgeCodigo { get; set; }
        public object SucCodigo { get; set; }
        public object BltValorFob { get; set; }
        public object BltAlto { get; set; }
        public object BltLargo { get; set; }
        public object BltAncho { get; set; }
        public object BltEpsCambio { get; set; }
        public object ComCodigo { get; set; }
        public int? AlmCodigo { get; set; }
        public object BltObservacion { get; set; }
        public object BltAbiertoAduana { get; set; }
        public object BltRecibido { get; set; }
        public object BltFacturaSuplidor { get; set; }
        public object ConCodigo2 { get; set; }
        public object ConCodigo3 { get; set; }
        public object Destinatario { get; set; }
        public object Remitente { get; set; }
        public object DiasInventario { get; set; }
        public object Dias_tr { get; set; }
        public object Suplidor { get; set; }
        public object Destino { get; set; }
        public object Puerto { get; set; }
        public object Condicion { get; set; }
        public object NombreReclamante { get; set; }
        public object ApellidoReclamante { get; set; }
        public object TelReclamante { get; set; }
        public int? TIENE_RCL { get; set; }
        public int? Cantidad { get; set; }
        public object ProDescripcion { get; set; }
        public object LineaAerea { get; set; }
        public object Sucursal { get; set; }
        public int? Secuencia { get; set; }
        public object Fecha { get; set; }
        public string SucursalAlm { get; set; }
        public string AlmNombre { get; set; }
        public string CteTipo { get; set; }
        public object CteBloqueo { get; set; }
        public int? CompaniaAlm { get; set; }
        public string CteCredito { get; set; }
        public string GrpCodigo { get; set; }
        public object Hora { get; set; }
        public object FacFecha { get; set; }
        public object Factura { get; set; }
        public object CarCodigo { get; set; }
        public object CarDescripcion { get; set; }
        public object Valor { get; set; }
        public object Tipo { get; set; }
        public float Tasa { get; set; }
        public object Monto { get; set; }
        public object DescripcionTrans { get; set; }
        public object TransFecha { get; set; }
        public object Representante { get; set; }
        public int? TotalFilas { get; set; }
        public float BvaMontoLocal { get; set; }
        public float BvaMontoSalida { get; set; }
        public int? TotalFilasInventario { get; set; }
        public float TotalPesoReal { get; set; }
        public float TotalPesoSuplidor { get; set; }
        public float TotalPesoRealInventario { get; set; }
        public float TotalPesoSuplidorInventario { get; set; }
        public float TotalPagado { get; set; }
        public float TotalPagadoInventario { get; set; }
        public object Ubicacion { get; set; }
        public int? IdCorrespondencia { get; set; }
        public float Tarifa { get; set; }
        public float FacTotal { get; set; }
        public float Itbis { get; set; }
        public float TotalExento { get; set; }
        public float TotalGravado { get; set; }
        public object CodBarra { get; set; }
        public object Firma { get; set; }
        public object Contenidos { get; set; }
        public object Telefono { get; set; }
        public object FechaAlt { get; set; }
        public object Contenido { get; set; }
        public object RefDocto { get; set; }
        public object Cajero { get; set; }
        public object ComisionAduana { get; set; }
        public object PagoComisionUS { get; set; }
        public object PagoComisionRD { get; set; }
        public object DocCodigo { get; set; }
        public object CteNombre { get; set; }
        public object CteEmail { get; set; }
        public object Asunto { get; set; }
        public object Fecha_Envio { get; set; }
        public object Hora_Envio { get; set; }
        public object Tracking_Paquete { get; set; }
        public object Contenido_Paquete { get; set; }
        public object Codigo_Barra { get; set; }
        public object Eps { get; set; }
        public object blt_ubicacion { get; set; }
        public object Dias { get; set; }
        public object CteTelefonoCasa { get; set; }
        public object CteTelefonoOficina { get; set; }
        public object GuiaPadre { get; set; }
        public object CodigoPromocion { get; set; }
        public object COBValorDeclarado { get; set; }
    }

}