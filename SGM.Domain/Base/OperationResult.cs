namespace SGM.Domain.Base
{
    public class OperationResult
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }
        public object? Datos { get; set; }
        public List<string> Errores { get; set; } = new();

        public static OperationResult() Exito(string mensaje = "Operación realizada con éxito.", object? datos = null) =>
            new() { Exitoso = true, Mensaje = mensaje, Datos = datos };
        public static OperationResult() Fallo(string mensaje = "La operación ha fallado.", List<string>? errores = null) =>
            new() { Exitoso = false, Mensaje = mensaje, Errores = errores ?? new List<string>() };

        public void AgregarError(string error) => Errores.Add(error);
    }
    public class OperationResult<T> : OperationResult
    {
        public new T? Datos { get; set; }
        public static new OperationResult<T> Exito(string mensaje = "Operación realizada con éxito.", T? datos = default) =>
            new() { Exitoso = true, Mensaje = mensaje, Datos = datos };
        public static new OperationResult<T> Fallo(string mensaje = "La operación ha fallado.", List<string>? errores = null) =>
            new() { Exitoso = false, Mensaje = mensaje, Errores = errores ?? new List<string>() };
    }
}