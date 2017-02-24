namespace Portal.Domain.Enum
{
    public enum ePermisos
    {
        God = 0,
        Mantenedor_Horas = 222,
        Personalizacion = 223,
        Permiso_Mantenedor_Cliente = 224,
        Glosario = 233,
        Asignar_Secretaria = 235,
        AdministrarPerfiles = 236,
        #region[Tab_mantenedor_Principal]
            Abogado_tabs = 237,
            Atenciones_tabs = 238,
            Cliente_tabs = 239,
            Datos_Cobro_tabs = 240,
            Datos_Facturacion_tabs = 241,
            Proyecto_tabs = 242,
            Secretaria_tabs = 243,
            Tarifa_tabs = 244,
            Tarifas_abogado_tabs = 245,
        #endregion
        Mantenedor_Especialidad = 246,
        Cambio_Fecha_Liquidacion = 247,
        Generacion_Folios = 248,
        TS_ABOGADO_TIPO = 250,
        TS_GRUPO = 251,
        TS_REPRESENTANTE = 252,
        TS_Tipo_Proyecto = 253,
        TS_TIPO_COBRO = 254
    }
}
