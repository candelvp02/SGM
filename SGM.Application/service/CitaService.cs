namespace SGM.Application.service
{
    public class CitaService : ICitaService
    {
        private readonly ICitaRepository _citaRepository;
        private readonly IMedicoRepository _medicoRepository;
        private readonly IPacienteRepository _pacienteRepository;
        private readonly INotificacionService _notificacionRepository;

        public async Task<OperationResult<Cita>> CrearCitaAsync(CrearCitaDto dto)
        {
            var medico = await _medicoRepository.GetByIdAsync(dto.MedicoId);
            var paciente = await _pacienteRepository.GetByIdAsync(dto.PacienteId);

            if (!medico.Disponibilidades.Contains(dto.Fecha, dto.Hora))
                return OperationResult<CitaService>.Fail(new[] { "El medico no esta disponible en ese horario" });

            var cita = new Cita
            {
                Fecha = dto.Fecha,
                Hora = dto.Hora,
                Estado = EstadoCita.Pendiente,
                MedicoId = dto.MedicoId,
                PacienteId = dto.PacienteId,
                Motivo = dto.Motivo,
            };

            await _citaRepository.AddAsync(cita);
            await _notificacionService.EnviarNotificacionAsync(
                new NotificacionDto
                {
                   Destinatario = paciente.Email,
                    Asunto = "Nueva Cita Creada",
                    Mensaje = $"Su cita con el Dr. {medico.Nombre} ha sido creada para el {cita.Fecha.ToShortDateString()} a las {cita.Hora}."
                });

            return OperationResult<cita>.Success(cita);
        }
    }
}
