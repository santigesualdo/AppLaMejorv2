using System;
using AppLaMejor.datamanager;
using AppLaMejor.entidades;

public class BaseEntity{

    private Nullable<DateTime> fechaBaja;

    [DataNames("id")]
    public int Id { get; set; }

    [DataNames("Usuario")]
    public int idUsuario{ get; set; }

    [DataNames("FechaBaja")]
    public Nullable<DateTime> FechaBaja
    {
        get 
        {
            return fechaBaja.HasValue ? (DateTime?)fechaBaja : null; 
        }
        set {fechaBaja = value; }
    }
}